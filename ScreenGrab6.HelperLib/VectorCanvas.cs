using System;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenGrab6.Vector
{

	public class Canvas
	{
		private List<VObject> p_objects = new List<VObject>();
		private int p_selectionCount = 0;

		public List<VObject> selectedObjects = new List<VObject>();
		public int ZIndexMin = 10000;

		public int ZIndexMax = 10000;
		public Point mouseDownPnt;
		public bool rubberBandActive;
		public Rectangle rubberBandRect;
		public bool isMoveMode = false;

		public VResizeDirection resizeDirection = VResizeDirection.None;
		private PictureBox withEventsField_box;
		private PictureBox box {
			get { return withEventsField_box; }
			set {
				if (withEventsField_box != null) {
					withEventsField_box.MouseDoubleClick -= box_MouseDoubleClick;
					withEventsField_box.MouseDown -= box_MouseDown;
					withEventsField_box.MouseMove -= box_MouseMove;
					withEventsField_box.MouseUp -= box_MouseUp;
					withEventsField_box.Paint -= box_Paint;
				}
				withEventsField_box = value;
				if (withEventsField_box != null) {
					withEventsField_box.MouseDoubleClick += box_MouseDoubleClick;
					withEventsField_box.MouseDown += box_MouseDown;
					withEventsField_box.MouseMove += box_MouseMove;
					withEventsField_box.MouseUp += box_MouseUp;
					withEventsField_box.Paint += box_Paint;
				}
			}
		}

		private Form ownerForm;
		private VCanvasLocalMessageFilter withEventsField_msgFilter = new VCanvasLocalMessageFilter();
		private VCanvasLocalMessageFilter msgFilter {
			get { return withEventsField_msgFilter; }
			set {
				if (withEventsField_msgFilter != null) {
					withEventsField_msgFilter.onKeyDown -= msgFilter_onKeyDown;
					withEventsField_msgFilter.onKeyUp -= msgFilter_onKeyUp;
				}
				withEventsField_msgFilter = value;
				if (withEventsField_msgFilter != null) {
					withEventsField_msgFilter.onKeyDown += msgFilter_onKeyDown;
					withEventsField_msgFilter.onKeyUp += msgFilter_onKeyUp;
				}
			}

		}
		private bool _isInsertionMode = false;
		private bool _isObjectBorderSelectionMode = false;
		public bool IsLineDrawingMode = false;

		public bool IsMultitouchMode = false;
		public bool isEditMode = false;
		public VTextbox EditObject;
		private TextBox withEventsField_EditTB;
		public TextBox EditTB {
			get { return withEventsField_EditTB; }
			set {
				if (withEventsField_EditTB != null) {
					withEventsField_EditTB.KeyUp -= EditTB_KeyUp;
					withEventsField_EditTB.TextChanged -= EditTB_TextChanged;
				}
				withEventsField_EditTB = value;
				if (withEventsField_EditTB != null) {
					withEventsField_EditTB.KeyUp += EditTB_KeyUp;
					withEventsField_EditTB.TextChanged += EditTB_TextChanged;
				}
			}

		}
		public event InsertElementEventHandler InsertElement;
		public delegate void InsertElementEventHandler(Rectangle rect);
		public event ObjectBorderClickedEventHandler ObjectBorderClicked;
		public delegate void ObjectBorderClickedEventHandler(VObject obj, DockStyle border, float location);
		public event SelectionChangedEventHandler SelectionChanged;
		public delegate void SelectionChangedEventHandler();
		public event ContextMenuEventHandler ContextMenu;
		public delegate void ContextMenuEventHandler();
		public event ContentChangedEventHandler ContentChanged;
		public delegate void ContentChangedEventHandler(VObject inElement);

		internal void OnContentChanged(VObject inElement)
		{
			if (ContentChanged != null) {
				ContentChanged(inElement);
			}
		}

		public System.Collections.ObjectModel.ReadOnlyCollection<VObject> objects {
			get { return p_objects.AsReadOnly(); }
		}
		public int SelectionCount {
			get { return p_selectionCount; }
		}

		public bool IsInsertionMode {
			get { return _isInsertionMode; }
			set {
				_isInsertionMode = value;
				if (value) {
					if (isEditMode)
						acceptEditMode();
					DeselectAll();
				}
			}
		}
		public bool IsObjectBorderSelectionMode {
			get { return _isObjectBorderSelectionMode; }
			set {
				_isObjectBorderSelectionMode = value;
				if (value) {
					if (isEditMode)
						acceptEditMode();
					DeselectAll();
				}
				Invalidate();
			}
		}

		public PictureBox PicBox {
			get { return box; }
			set {
				box = value;
				box.Image = null;
				box.BackgroundImage = null;
				Application.RemoveMessageFilter(msgFilter);
				if (box == null) {
					ownerForm = null;
				} else {
					ownerForm = box.FindForm();
					Application.AddMessageFilter(msgFilter);
				}
			}
		}

		public VObject GetObjectByID(string id)
		{
			if (string.IsNullOrEmpty(id))
				return null;
			for (int i = 0; i <= p_objects.Count - 1; i++) {
				if (p_objects[i].name == id) {
					return p_objects[i];
				}
			}
			return null;
		}

		public VObject GetObjectAt(Point pt)
		{
			for (int i = p_objects.Count - 1; i >= 0; i += -1) {
				if (p_objects[i].HitTest(pt)) {
					return p_objects[i];
				}
			}
			return null;
		}

		public VObject GetFirstSelectedObject()
		{
      if (selectedObjects.Count > 0)
        return selectedObjects[0];
      else
        return null;
		}

		public void OnSelectionChanged()
		{
			if (isEditMode)
				acceptEditMode();

			p_selectionCount = 0;
			selectedObjects.Clear();
			for (int i = 0; i <= p_objects.Count - 1; i++) {
				if (p_objects[i].isSelected){p_selectionCount += 1;selectedObjects.Add(p_objects[i]);}
			}

			if (SelectionChanged != null) {
				SelectionChanged();
			}
			this.Invalidate();
		}

		public void SelectObject(VObject obj)
		{
			for (int i = 0; i <= p_objects.Count - 1; i++) {
				p_objects[i].isSelected = false;
			}
			obj.isSelected = true;
			OnSelectionChanged();
			Invalidate();
		}

		public void startEditMode(VTextbox tb)
		{
			EditTB.Bounds = new Rectangle(tb.Left - 2, tb.Top + 28, tb.Width + 4, tb.Height + 4);
			//EditTB.Top += 28

			EditTB.Text = tb.Text;
			EditTB.Font = tb.Font;
			EditTB.Show();
			EditTB.Focus();
			EditObject = tb;
			isEditMode = true;
		}

		public void acceptEditMode()
		{
			if (!isEditMode)
				return;
			EditObject.Text = EditTB.Text;
			EditTB.Hide();
			isEditMode = false;
			if (string.IsNullOrEmpty(EditObject.Text))
				removeObject(EditObject);
		}

		public void cancelEditMode()
		{
			if (!isEditMode)
				return;
			EditTB.Hide();
			isEditMode = false;
		}

		private void box_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (IsInsertionMode | IsObjectBorderSelectionMode | IsLineDrawingMode)
				return;
			var selObj = GetFirstSelectedObject();
			if (selObj != null && selObj is VTextbox) {
				startEditMode(selObj);
			}
		}

		private void box_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (isEditMode)
				acceptEditMode();
			if (IsMultitouchMode)
				return;

			mouseDownPnt = e.Location;

			isMoveMode = false;
			resizeDirection = VResizeDirection.None;

			rubberBandActive = false;
			//rubberBandRect = null;

			if (IsInsertionMode | _isObjectBorderSelectionMode)
				return;

			var selObj = GetFirstSelectedObject();
			if (selObj != null) {
				var resize = selObj.HitTestResizer(e.Location);
				resizeDirection = resize;
				///'    frm_mdiViewer2.Text = resizeDirection.ToString
			}

			if (resizeDirection == VResizeDirection.None) {
				//wenn nicht resize, dann vielleicht verschieben???

				var clickObj = GetObjectAt(e.Location);
				//AndAlso clickObj.isSelected
				if (clickObj != null) {
					if (isKeyPressed(Keys.ControlKey)) {
						clickObj.isSelected = !clickObj.isSelected;
						OnSelectionChanged();
					} else {
						if (!clickObj.isSelected)
							SelectObject(clickObj);
						isMoveMode = true;
					}
				}
			}

		}

		private void box_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (IsMultitouchMode | _isObjectBorderSelectionMode)
				return;

			if (e.Button != MouseButtons.Left)
				return;

			if (isMoveMode) {
				for (int i = 0; i <= selectedObjects.Count - 1; i++) {
					var obj = selectedObjects[i];
					if (obj.moveTempRect != null) {
						obj.DrawMoveRect();
					}
					obj.moveTempRect = obj.bounds;
					obj.moveTempRect.Offset(e.Location - mouseDownPnt);
					obj.DrawMoveRect();
				}

			} else if (resizeDirection != VResizeDirection.None) {
				var obj = GetFirstSelectedObject();
				if (obj.moveTempRect != null) {
					obj.DrawMoveRect();
				}
				obj.moveTempRect = Helper.GetResizedRect(obj.bounds, resizeDirection, mouseDownPnt, e.Location);

				obj.DrawMoveRect();


			} else if (rubberBandActive || Helper.PointDistance(mouseDownPnt, e.Location) > 5) {
				rubberBandActive = true;
				if (rubberBandRect != null) {
					DrawRubberBand();
				}
				rubberBandRect = Helper.MakeRect(mouseDownPnt.X, mouseDownPnt.Y, e.X, e.Y, IsLineDrawingMode);
				DrawRubberBand();
			}
		}

		private void DrawRubberBand()
		{
			var rr = box.RectangleToScreen(rubberBandRect);
			if (IsLineDrawingMode) {
				ControlPaint.DrawReversibleLine(new Point(rr.Left, rr.Top), new Point(rr.Right, rr.Bottom), Color.White);
			} else {
				ControlPaint.DrawReversibleFrame(rr, Color.White, FrameStyle.Dashed);
			}
		}

		private void box_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (IsMultitouchMode)
				return;

      if (IsObjectBorderSelectionMode) {
        var obj = GetObjectAt(e.Location);
        if (obj != null) {
          var x = e.X - obj.Left;
          var y = e.Y - obj.Top;
          if (x < 10) {
            if (ObjectBorderClicked != null) {
              ObjectBorderClicked(obj, DockStyle.Left, y / obj.Height);
            }
            return;
          }
          if (y < 10) {
            if (ObjectBorderClicked != null) {
              ObjectBorderClicked(obj, DockStyle.Top, x / obj.Width);
            }
            return;
          }
          if (x > obj.Width - 10) {
            if (ObjectBorderClicked != null) {
              ObjectBorderClicked(obj, DockStyle.Right, y / obj.Height);
            }
            return;
          }
          if (y > obj.Height - 10) {
            if (ObjectBorderClicked != null) {
              ObjectBorderClicked(obj, DockStyle.Bottom, x / obj.Width);
            }
            return;
          }
        }
        return;
      }

			if (e.Button == MouseButtons.Left) {
				if (rubberBandActive) {
					rubberBandActive = false;
					if (rubberBandRect != null) {
						ControlPaint.DrawReversibleFrame(box.RectangleToScreen(rubberBandRect), Color.White, FrameStyle.Dashed);
					}

					Rectangle rct = rubberBandRect;

					if (IsInsertionMode) {
						if (InsertElement != null) {
							InsertElement(rct);
						}
						return;
					}

					for (int i = 0; i <= p_objects.Count - 1; i++) {
						p_objects[i].isSelected = p_objects[i].HitTestRect(rct);
					}
					OnSelectionChanged();

				} else if (isMoveMode) {
					for (int i = 0; i <= selectedObjects.Count - 1; i++) {
						var obj = selectedObjects[i];
						if (obj.moveTempRect != null) {
							obj.DrawMoveRect();
							obj.bounds = obj.moveTempRect;
							obj.moveTempRect = null;
						}
					}

				} else if (resizeDirection != VResizeDirection.None) {
					var obj = GetFirstSelectedObject();
					if (obj.moveTempRect != null) {
						obj.DrawMoveRect();
						obj.bounds = obj.moveTempRect;
						obj.moveTempRect = null;
					}



				} else {
					//For i = objects.Count - 1 To 0 Step -1
					//  If objects(i).isSelected = False AndAlso objects(i).HitTest(e.Location) Then
					//    SelectObject(objects(i))
					//    Exit For
					//  End If
					//Next

				}
			}

			if (e.Button == MouseButtons.Right) {
				if (ContextMenu != null) {
					ContextMenu();
				}
				//Dim obj = GetObjectAt(e.Location)
				//If obj IsNot Nothing Then
				//  SelectObject(obj)
				//  showProperties(obj, True)
				//End If
			}
			Invalidate();
		}

		public string GetSelectionType()
		{
			string selType = "";
			foreach (VObject item in selectedObjects) {
				var typeName = item.GetType().Name;
				if (!string.IsNullOrEmpty(selType) & selType != typeName)
					return "";
				if (string.IsNullOrEmpty(selType))
					selType = typeName;
			}
			return selType;
		}

		public void SetContext(ToolStripItemCollection items)
		{
			var selType = GetSelectionType();

			foreach (ToolStripItem item in items) {
				string tag = (string)item.Tag;
				if (string.IsNullOrEmpty(tag))
					continue;
				if (tag.StartsWith("%")){item.Visible = false;tag = tag.Substring(1);}
				else
					item.Enabled = false;

				if (tag == "Any" && SelectionCount > 0){item.Enabled = true;item.Visible = true;}
				if (tag == "Multi" && SelectionCount > 1){item.Enabled = true;item.Visible = true;}
				if (tag == "Single" && SelectionCount == 1){item.Enabled = true;item.Visible = true;}
				if (tag == "NoSel" && SelectionCount == 0){item.Enabled = true;item.Visible = true;}
				if (!string.IsNullOrEmpty(selType) && tag.Contains(selType)){item.Enabled = true;item.Visible = true;}

				if (item.Enabled & item.Visible & item is ToolStripMenuItem && ((ToolStripMenuItem)item).DropDownItems.Count > 0)
					SetContext(((ToolStripMenuItem)item).DropDownItems);
			}
		}

		public void showProperties(VObject obj)
		{ showProperties(obj, false); }

		public void showProperties(VObject obj, bool force)
		{
			if (force == true) {
				frm_paletteFile.Show();
				frm_paletteFile.Activate();
			} else if (force == false & frm_paletteFile.Visible == false) {
				return;
			}
			// frm_paletteFile.MyCanvas = Me
			frm_paletteFile.RefreshItemList();
			frm_paletteFile.SelectedObject = obj;
		}

		public void showTextEditor(VTextbox obj)
		{ showTextEditor(obj, true); }
		public void showTextEditor(VTextbox obj, bool allowFormat)
		{
			frm_textEditor f = new frm_textEditor();
			f.TextBox1.Text = obj.text;
			if (allowFormat)
				f.setTextboxObject(this, obj);
			if (f.ShowDialog == System.Windows.Forms.DialogResult.OK) {
				obj.text = f.TextBox1.Text;
				this.Invalidate();
			}
		}

		public void Invalidate()
		{
			box.Invalidate();

			//HACK
			frm_paletteCursor.Invalidate();

		}

		public void DeselectAll()
		{
			for (i = 0; i <= p_objects.Count - 1; i++) {
				p_objects[i].isSelected = false;
			}
			OnSelectionChanged();
		}

		private void box_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			for (i = 0; i <= p_objects.Count - 1; i++) {
				p_objects[i].DrawObject(e.Graphics);
			}
		}


		public void orderByZIndex()
		{
			int curMinIdx = 0;
			int curPos = 0;
			VObject curObj = default(VObject);

			while (curPos < p_objects.Count) {
				curObj = p_objects[curPos];

				if (curObj.ZIndex < curMinIdx) {
					p_objects.RemoveAt(curPos);
					for (i = curPos; i >= 0; i += -1) {
						if (p_objects[i].ZIndex < curObj.ZIndex) {
							p_objects.Insert(i, curObj);
							curObj = null;
							curPos = 0;
							continue;
						}
					}
				}

				curMinIdx = curObj.ZIndex;
				curPos += 1;
			}



		}

		public void addObject(VObject obj)
		{
			p_objects.Add(obj);
			obj.Parent = this;
			Invalidate();
			OnContentChanged(obj);
		}

		public void removeObject(VObject obj)
		{
			p_objects.Remove(obj);
			if (obj.isSelected)
				OnSelectionChanged();
			obj.Parent = null;
			Invalidate();
			OnContentChanged(null);
		}

		public void clearCanvas()
		{
			for (i = p_objects.Count - 1; i >= 0; i += -1) {
				removeObject(p_objects[i]);
			}
		}

		public void MoveObjectZ(VObject obj, bool dirUp, bool toEnd)
		{
			int curIdx = p_objects.IndexOf(obj);
			if (curIdx == 0 & dirUp == false)
				return;
			if (curIdx == p_objects.Count - 1 & dirUp == true)
				return;

			p_objects.RemoveAt(curIdx);
			if (toEnd) {
				if (dirUp) {
					p_objects.Add(obj);
				} else {
					p_objects.Insert(0, obj);
				}
			} else {
				if (dirUp) {
					p_objects.Insert(curIdx + 1, obj);
				} else {
					p_objects.Insert(curIdx - 1, obj);
				}
			}

			Invalidate();
			OnContentChanged(obj);
		}

		private void msgFilter_onKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (ownerForm == null || !object.ReferenceEquals(ownerForm, Form.ActiveForm))
				return;

			if (isEditMode) {
				if (e.KeyCode == Keys.Escape) {
					cancelEditMode();
				}
				return;
			}

			if (e.KeyCode == Keys.Delete) {
				dynamic obj = GetFirstSelectedObject();
				if (obj != null) {
					removeObject(obj);
				} else {
					Interaction.Beep();
				}
			}

			if ((e.Alt & e.KeyCode == Keys.Return) | (e.Control & e.KeyCode == Keys.P)) {
				dynamic obj = GetFirstSelectedObject();
				if (obj != null) {
					showProperties(obj);
				}
			}

			if (e.Control & e.KeyCode == Keys.D) {
				dynamic obj = GetFirstSelectedObject();
				if (obj != null && obj is VImage) {
					VImage vi = obj;
					//loadImage(vi.img)
				}
			}

			if (e.Control & e.KeyCode == Keys.X) {
				CutSelection();
			}

			if (e.Control & e.KeyCode == Keys.C) {
				CopySelection();
			}

			if (e.Control & e.KeyCode == Keys.V) {
				Paste();
			}

			//If (e.Control And e.KeyCode = Keys.E) Then
			//  Dim obj = GetFirstSelectedObject()
			//  If obj IsNot Nothing And TypeOf obj Is VTextbox Then
			//    showTextEditor(obj)
			//  End If
			//End If

			if (Helper.IsArrowKey(e.KeyCode)) {
				int deltaX = 0;
				int deltaY = 0;
				switch (e.KeyCode) {
					case Keys.Left:
						deltaX = -1;
						break;
					case Keys.Right:
						deltaX = +1;
						break;
					case Keys.Up:
						deltaY = -1;
						break;
					case Keys.Down:
						deltaY = +1;
						break;
				}
				if (e.Control == true){deltaX *= 10;deltaY *= 10;}
				for (i = 0; i <= p_objects.Count - 1; i++) {
					if (p_objects[i].isSelected) {
						if (e.Shift) {
							p_objects[i].Width += deltaX;
							p_objects[i].Height += deltaY;
						} else {
							p_objects[i].Left += deltaX;
							p_objects[i].Top += deltaY;
						}
					}
				}
				Invalidate();
			}
		}

		private void msgFilter_onKeyUp(System.Windows.Forms.KeyEventArgs e)
		{
			if (ownerForm == null || !object.ReferenceEquals(ownerForm, Form.ActiveForm))
				return;

			Debug.Print("keyUP" + e.KeyCode.ToString());

			if (e.KeyCode == Keys.PageUp) {
				MoveObjectZ(GetFirstSelectedObject(), true, e.Control | e.Alt);
			}

			if (e.KeyCode == Keys.PageDown) {
				MoveObjectZ(GetFirstSelectedObject(), false, e.Control | e.Alt);
			}


		}

		public void CopySelection()
		{
			Clipboard.Clear();
			if (SelectionCount == 0)
				return;
			DataObject cdo = new DataObject();

			int minX = 0;
			int minY = 0;
			int maxX = 0;
			int maxY = 0;
			string[] internalData = new string[SelectionCount + 1];
			minX = int.MaxValue;
			minY = int.MaxValue;
			foreach (object v_loopVariable in selectedObjects) {
				v = v_loopVariable;
				RECT r = v.GetOuterBounds();
				minX = Math.Min(minX, r.Left);
				minY = Math.Min(minY, r.Top);
				maxX = Math.Max(maxX, r.Right);
				maxY = Math.Max(maxY, r.Bottom);
			}
			Point minPoint = default(Point);
			Bitmap bmp = new Bitmap(maxX - minX, maxY - minY, Imaging.PixelFormat.Format32bppPArgb);
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			g.TranslateTransform(-minX, -minY);
			for (i = 0; i <= SelectionCount - 1; i++) {
				var _with1 = selectedObjects[i];
				_with1.isSelected = false;
				_with1.DrawObject(g);
				_with1.isSelected = true;
				internalData[i] = _with1.ToHtml();
			}
			g.Dispose();
			cdo.SetData("Bitmap", true, bmp.Clone);


			cdo.SetData("ScreenGrabCollageItemList", false, internalData);

			if (SelectionCount == 1) {
				switch (GetSelectionType()) {
					case "VTextbox":
						cdo.SetText(((VTextbox)GetFirstSelectedObject()).Text);
						break;
					case "VImage":
						cdo.SetImage(((VImage)GetFirstSelectedObject()).img);
						break;
				}
			}

			Clipboard.SetDataObject(cdo, true);
		}

		public void CutSelection()
		{
			CopySelection();
			//delete selected
		}

		public void Paste()
		{
			DeselectAll();
			if (Clipboard.ContainsData("ScreenGrabCollageItemList")) {
				string[] items = Clipboard.GetData("ScreenGrabCollageItemList");
				foreach (string item in items) {
					if (string.IsNullOrEmpty(item))
						continue;
					VObject v = VObject.FromHtml(item);
					if (v == null){Interaction.MsgBox("Invalid data item" + Constants.vbNewLine + item);continue;}
					v.isSelected = true;
					v.name = "paste_" + DateAndTime.Now.Ticks;
					addObject(v);
				}
			}
			OnSelectionChanged();

		}


		// experimentell!
		public void createPdfFile(string filespec)
		{
			iTextSharp.text.Document doc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(0, 0, box.Width, box.Height));
			dynamic writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(filespec, System.IO.FileMode.Create));
			dynamic bf = iTextSharp.text.pdf.BaseFont.CreateFont();
			doc.Open();
			iTextSharp.text.pdf.PdfContentByte over = writer.DirectContent;
			for (i = 0; i <= p_objects.Count - 1; i++) {
				RECT r = p_objects[i].GetOuterBounds;
				if (p_objects[i] is VTextbox) {
					VTextbox src = p_objects[i];

					//ColumnText can contain paraphraphs as well as be abolsutely positioned
					iTextSharp.text.pdf.ColumnText Col = new iTextSharp.text.pdf.ColumnText(over);

					//Set the x,y,width,height
					Col.SetSimpleColumn(r.Left, box.Height - r.Top, r.Right, box.Height - r.Bottom);

					//Create our paragraph
					iTextSharp.text.Paragraph P = new iTextSharp.text.Paragraph();
					//Create our base font, assumes you have arial installed in the normal location and that CP1252 works with it
					//Dim BF = BaseFont.CreateFont(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "Fonts\arial.ttf"), BaseFont.CP1252, False)
					//Add two chunks that will be placed side-by-side but with different font weights
					//P.Add(New iTextSharp.text.Chunk("BOLD TEXT: ", New iTextSharp.text.Font(bf, 10.0, iTextSharp.text.Font.BOLD)))
					string fontFilespec = Helper.GetFontFilespec(src.Font.FontFamily.Name);
					iTextSharp.text.Font fnt = default(iTextSharp.text.Font);
					if (!string.IsNullOrEmpty(fontFilespec)) {
						fnt = new iTextSharp.text.Font(iTextSharp.text.pdf.BaseFont.CreateFont(fontFilespec, iTextSharp.text.pdf.BaseFont.CP1252, false), src.Font.SizeInPoints, iTextSharp.text.Font.NORMAL);
					} else {
						fnt = new iTextSharp.text.Font(bf, src.Font.SizeInPoints, iTextSharp.text.Font.NORMAL);
					}
					P.Add(new iTextSharp.text.Chunk(src.Text, fnt));
					//Add the paragraph to the ColumnText
					Col.AddText(P);
					//Call to stupid Go() method which actually writes the content to the stream.
					Col.Go();

				//
				//Dim txtbox As New iTextSharp.text.pdf.PdfPCell()

				//Dim f = New iTextSharp.text.Font(bf)
				//f.SetColor(0, 0, 0)
				//over.SetFontAndSize(bf, 10)
				//over.BeginText()
				//over.ShowTextAligned(1, src.Text, r.Left, box.Height - r.Bottom, 0)
				//over.EndText()
				} else {
					dynamic img = iTextSharp.text.Image.GetInstance(p_objects[i].GetAsImage, System.Drawing.Imaging.ImageFormat.Png);
					img.SetAbsolutePosition(r.Left, box.Height - r.Bottom);
					img.SetDpi(72, 72);
					//doc.Add(img)
					over.AddImage(img);
				}
			}
			doc.Close();
		}

		public void createHtmlPage(string fileSpec)
		{
			//Dim fileName As String
			//Using sfd As New SaveFileDialog
			//  sfd.Filter = "HTML-Datei (*.html, *.html, *.htm)|*.html;*.htm"
			//  If sfd.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
			//  fileName = sfd.FileName
			//End Using


			System.IO.StreamWriter sw = new System.IO.StreamWriter(fileSpec);
			sw.WriteLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" " + "\"http://www.w3.org/TR/html4/loose.dtd\">");
			sw.WriteLine("<html>");
			sw.WriteLine("<head>");
			sw.WriteLine("\t<title>" + System.IO.Path.GetFileNameWithoutExtension(fileSpec) + "</title>");
			sw.WriteLine("\t<style type=\"text/css\">");
			sw.WriteLine("\tdiv { line-height: 120% !important; }");
			sw.WriteLine("\tp { margin: 0; padding: 0; font: 8pt 'Microsoft Sans Serif',sans-serif; }");
			sw.WriteLine("\tp.title { line-height: 120% !important; margin-bottom: -4px; }");
			sw.WriteLine("\tp.title b { font: bold 12pt 'Microsoft Sans Serif',sans-serif; }");
			sw.WriteLine("\thr { border: 1px solid black; margin: 4px 0; }");
			//  sw.WriteLine("	div:hover { outline: 2px dotted red; }")
			sw.WriteLine("\t</style>");
			sw.WriteLine("\t<meta name=\"generator\" content=\"ScreenShot 6 Collage\">");
			sw.WriteLine("\t<!-- Version: " + My.Application.Info.Version.ToString + " -->");
			sw.WriteLine("\t<meta name=\"author\" content=\"" + My.User.Name + "\" />");
			sw.WriteLine("\t<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
			sw.WriteLine("</head>");
			sw.WriteLine("<body bgcolor=\"#888888\">");
			sw.WriteLine("<!-- ##page##" + PicBox.Width + "##" + PicBox.Height + "##" + "##" + Helper.Color2String(PicBox.BackColor) + "## -->");
			sw.WriteLine("<div style=\"margin: 10px auto; overflow: hidden; " + "background-color: " + Helper.Color2HTMLString(PicBox.BackColor) + ";" + "border: 1px solid black; width: " + PicBox.Width + "px; height: " + PicBox.Height + "px; \">");

			foreach (object el_loopVariable in p_objects) {
				el = el_loopVariable;
				sw.WriteLine(el.ToHtml());
			}
			sw.WriteLine("</div></body></html>");
			sw.Close();
			//IO.File.WriteAllText(fileName, sb.ToString)
			//Process.Start(filespec)
		}

		public void readHtmlPage(string fileSpec)
		{
			dynamic sr = System.IO.File.OpenText(fileSpec);

			//clear All ???

			int lineNr = 0;
			int modusCounter = 0;
			string line = null;
			string modus = null;
			System.Text.StringBuilder contbuffer = null;
			VObject myObj = default(VObject);
			modus = "invalid";
			while (sr.EndOfStream == false) {
				lineNr += 1;
				modusCounter += 1;
				line = sr.ReadLine;
				if (line.Contains("ScreenShot 5 Collage") | line.Contains("ScreenShot 6 Collage")) {
					modus = "valid";
					modusCounter = 0;
				}
				if (modus == "invalid")
					continue;

				if (line.StartsWith("<!-- ##page##")) {
					string[] para = Strings.Split(line, "##");
					PicBox.BackColor = Helper.String2Color(para[5]);
					PicBox.Width = para[2];
					PicBox.Height = para[3];

					continue;
				}

				if (modus == "txt" & line == "</div>") {
					modus = "valid";
					modusCounter = 0;
					if (myObj is VTextbox) {
						((VTextbox)myObj).Text = Strings.Trim(contbuffer.ToString()).Replace("<br>", Constants.vbCrLf).Replace("<br/>", Constants.vbCrLf);
					} else if (myObj is VUMLClass) {
						((VUMLClass)myObj).ParseHtmlContent(Strings.Trim(contbuffer.ToString()));
					}
					addObject(myObj);
				}

				if (modus == "txt" & modusCounter >= 1) {
					contbuffer.AppendLine(line);
				}

				if (modus == "img" & modusCounter >= 1) {
					if (modusCounter == 1)
						line = line.Substring(5);
					//src="
					if (line.EndsWith("\" />")) {
						modus = "valid";
						modusCounter = 0;
						line = line.Substring(0, line.Length - 4);
					}
					contbuffer.AppendLine(line);
					//Bild fertig
					if (modus == "valid") {
						dynamic img = Helper.Base64ToImage(contbuffer);
						((VImage)myObj).img = img;
						addObject(myObj);
					}
				}


				if (line.StartsWith("<!-- ##img##") | line.StartsWith("<!-- ##VImage##")) {
					modus = "img";
					modusCounter = 0;
					string[] para = Strings.Split(line, "##");
					myObj = new VImage();
					myObj.Deserialize(para);
					contbuffer = new System.Text.StringBuilder();
				}

				if (line.StartsWith("<!-- ##rtf##") | line.StartsWith("<!-- ##VTextbox##")) {
					modus = "txt";
					modusCounter = 0;
					string[] para = Strings.Split(line, "##");

					myObj = new VTextbox();
					myObj.Deserialize(para);
					contbuffer = new System.Text.StringBuilder();
				}

				if (line.StartsWith("<!-- ##VUMLClass##")) {
					modus = "txt";
					modusCounter = 0;
					string[] para = Strings.Split(line, "##");

					myObj = new VUMLClass();
					myObj.Deserialize(para);
					contbuffer = new System.Text.StringBuilder();
				}

				if (line.StartsWith("<!-- ##VElipse##")) {
					modus = "valid";
					modusCounter = 0;
					string[] para = Strings.Split(line, "##");

					myObj = new VElipse();
					myObj.Deserialize(para);
					addObject(myObj);
				}

				if (line.StartsWith("<!-- ##VLine##")) {
					modus = "valid";
					modusCounter = 0;
					string[] para = Strings.Split(line, "##");

					myObj = new VLine();
					myObj.Deserialize(para);
					addObject(myObj);
				}

				if (line.StartsWith("<!-- ##VRectangle##")) {
					modus = "valid";
					modusCounter = 0;
					string[] para = Strings.Split(line, "##");

					myObj = new VRectangle();
					myObj.Deserialize(para);
					addObject(myObj);
				}


			}

			if (modus == "invalid") {
				Interaction.MsgBox("Ungültiges Dateiformat.", MsgBoxStyle.Critical);
			}

			sr.Close();
		}

		private void EditTB_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) {
				cancelEditMode();
			}
		}


		private void EditTB_TextChanged(object sender, System.EventArgs e)
		{
		}

	}


	public class VCanvasLocalMessageFilter : IMessageFilter
	{

		public event onKeyDownEventHandler onKeyDown;
		public delegate void onKeyDownEventHandler(System.Windows.Forms.KeyEventArgs e);
		public event onKeyUpEventHandler onKeyUp;
		public delegate void onKeyUpEventHandler(System.Windows.Forms.KeyEventArgs e);



		public VCanvasLocalMessageFilter()
		{
		}

		public bool PreFilterMessage(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == WindowsMessages.WM_KEYDOWN) {
				KeyEventArgs e = new KeyEventArgs(((Keys)Convert.ToInt32(Convert.ToInt64(m.WParam)) | Control.ModifierKeys));
				if (onKeyDown != null) {
					onKeyDown(e);
				}
			} else if (m.Msg == WindowsMessages.WM_KEYUP) {
				KeyEventArgs e = new KeyEventArgs(((Keys)Convert.ToInt32(Convert.ToInt64(m.WParam)) | Control.ModifierKeys));
				if (onKeyUp != null) {
					onKeyUp(e);
				}
			}
		}
	}

}

