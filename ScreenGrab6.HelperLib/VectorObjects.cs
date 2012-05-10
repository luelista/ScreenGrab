using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ScreenGrab6.Vector {

  //---------------------------------------------------------------------------------------

  public interface IGradientObject {

    DrawingEx.ColorManagement.Gradients.Gradient Gradient { get; set; }
  }

  public abstract class VObject {

    public string name;

    public string created;

    public int ZIndex;
    private Rectangle m_bounds;
    private Rectangle m_rotatedBounds;
    protected Rectangle[] m_resizeBounds = new Rectangle[4];

    protected Rectangle[] m_resizeBoundsTransformed = new Rectangle[4];
    protected abstract void DrawObjectInternal(Graphics g);

    internal Rectangle moveTempRect;
    internal Rectangle moveOrigRect;
    internal bool isSelected;

    internal Pen borderPen = new Pen(Color.Black, 0);

    public static Pen selectionRectPen = new Pen(Color.Black, 1) { DashStyle = Drawing2D.DashStyle.Dash };
    public static int CommonDataOffset = 19;
    public static int ResizerWidth = 5;

    public static SolidBrush ResizerBrsh = new SolidBrush(Color.Gray);

    private int p_rotation;

    public Canvas Parent;
    //  Public HasAttachedArrows As Boolean --- optionale Optimierung

    public virtual int Rotation {
      get { return p_rotation; }
      set { p_rotation = value; }
    }

    public virtual void DrawMoveRect() {
      ControlPaint.DrawReversibleFrame(Parent.PicBox.RectangleToScreen(this.moveTempRect), Color.White, FrameStyle.Dashed);
    }

    public void DrawObject(Graphics g) {
      Matrix m = null;
      Matrix oldm = null;
      if (Rotation > 0) {
        m = new Matrix();
        m.RotateAt(Rotation, new PointF(this.bounds.X + this.bounds.Width / 2, this.bounds.Y + this.bounds.Height / 2));
        oldm = g.Transform;
        g.Transform = m;
      }
      DrawObjectInternal(g);
      if (Rotation > 0) {
        g.Transform = oldm;
        m.Dispose();
      }
      DrawSelection(g);
    }

    public RECT GetOuterBounds() {
      return new RECT((int)(Math.Min(bounds.Right, bounds.Left) - BorderWidth / 2), (int)(Math.Min(bounds.Bottom, bounds.Top) - BorderWidth / 2), (int)(Math.Max(bounds.Right, bounds.Left) + BorderWidth / 2), (int)(Math.Max(bounds.Bottom, bounds.Top) + BorderWidth / 2));
    }

    public Image GetAsImage() {
      RECT r = GetOuterBounds();
      Bitmap bmp = new Bitmap(r.Right - r.Left, r.Bottom - r.Top, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
      Graphics g = Graphics.FromImage(bmp);
      //g.Clear(Color.White)
      g.TranslateTransform(-r.Left, -r.Top);
      var oldSel = isSelected;
      isSelected = false;
      DrawObject(g);
      isSelected = oldSel;
      g.Dispose();
      return bmp;
    }

    public Rectangle bounds {
      get { return m_bounds; }
      set {
        m_bounds = value;
        OnBoundsChanged();
      }
    }

    private void OnBoundsChanged() {
      Matrix m = new Matrix();
      m.RotateAt(Rotation, new PointF(this.bounds.X + this.bounds.Width / 2, this.bounds.Y + this.bounds.Height / 2));
      Point[] pt = {
				new Point(m_bounds.X, m_bounds.Y),
				new Point(m_bounds.Right, m_bounds.Bottom)
			};
      m.TransformPoints(pt);
      m_rotatedBounds = new Rectangle(pt[0].X, pt[0].Y, pt[1].X - pt[0].X, pt[1].Y - pt[0].Y);
      m.Dispose();
      m_resizeBoundsTransformed = GetResizeBounds(m_rotatedBounds);
      m_resizeBounds = GetResizeBounds(m_bounds);
      OnContentChanged();
      if (Parent != null) {
        foreach (object v in Parent.objects) {
          if (v is VLine && (((VLine)v).startObject == name | ((VLine)v).endObject == name))
            ((VLine)v).EnforceDockPosition();
        }
      }
    }

    private Rectangle[] GetResizeBounds(Rectangle rct) {
      return new Rectangle[] {
				new Rectangle(rct.X - ResizerWidth, rct.Y - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2),
				new Rectangle(rct.Right - ResizerWidth, rct.Y - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2),
				new Rectangle(rct.X - ResizerWidth, rct.Bottom - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2),
				new Rectangle(rct.Right - ResizerWidth, rct.Bottom - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2)
			};
    }

    protected void OnContentChanged() {
      if (Parent != null)
        Parent.OnContentChanged(this);
    }

    public virtual Color Color1 {
      get { return borderPen.Color; }
      set {
        borderPen.Color = value;
        OnContentChanged();
      }
    }

    public virtual Color Color2 {

      get { }

      set { }
    }

    public float BorderWidth {
      get { return borderPen.Width; }
      set {
        borderPen.Width = value;
        OnContentChanged();
      }
    }

    #region "Left,Top,Width,Height Properties"
    public int Left {
      get { return m_bounds.X; }
      set {
        m_bounds.X = value;
        OnBoundsChanged();
      }
    }
    public int Top {
      get { return m_bounds.Y; }
      set {
        m_bounds.Y = value;
        OnBoundsChanged();
      }
    }
    public int Width {
      get { return m_bounds.Width; }
      set {
        m_bounds.Width = value;
        OnBoundsChanged();
      }
    }
    public int Height {
      get { return m_bounds.Height; }
      set {
        m_bounds.Height = value;
        OnBoundsChanged();
      }
    }
    #endregion

    public virtual string ToHtml() {
      return "<!-- " + Strings.Join(this.Serialize(), "##") + "## -->";
    }

    public static VObject FromHtml(string input) {
      if (string.IsNullOrEmpty(input))
        return null;
      int posIdx1 = 0;
      int posIdx2 = 0;
      posIdx1 = input.IndexOf("<!-- ##");
      if (posIdx1 == -1)
        return null;
      input = input.Substring(posIdx1);
      string[] para = Strings.Split(input, "##");
      switch (Strings.UCase(para[1])) {
        case "IMG":
        case "VIMAGE":
          VImage myobj = new VImage();
          myobj.Deserialize(para);
          posIdx1 = input.IndexOf("src=\"") + 5;
          posIdx2 = input.IndexOf("\"", posIdx1);
          if (posIdx1 < 5 | posIdx2 == -1 | posIdx2 < posIdx1)
            return null;
          dynamic img = Helper.Base64ToImage(new System.Text.StringBuilder(input.Substring(posIdx1, posIdx2 - posIdx1)));
          ((VImage)myobj).img = img;
          return myobj;
        case "RTF":
        case "VTEXTBOX":
          VTextbox myobj = new VTextbox();
          myobj.Deserialize(para);
          posIdx1 = input.IndexOf(Constants.vbNewLine) + 2;
          posIdx2 = input.LastIndexOf("</div>");
          if (posIdx1 < 2 | posIdx2 == -1 | posIdx2 < posIdx1)
            return null;
          ((VTextbox)myobj).Text = Helper.StripHtmlTags(input.Substring(posIdx1, posIdx2 - posIdx1).Replace("<br>", Constants.vbNewLine).Replace("<br/>", Constants.vbNewLine)).Replace("&lt;", "<").Replace("&gt;", ">");
          return myobj;
        case "VUMLCLASS":
          VUMLClass myobj = new VUMLClass();
          myobj.Deserialize(para);
          posIdx1 = input.IndexOf(Constants.vbNewLine) + 2;
          posIdx2 = input.LastIndexOf("</div>");
          if (posIdx1 < 2 | posIdx2 == -1 | posIdx2 < posIdx1)
            return null;
          myobj.ParseHtmlContent(input.Substring(posIdx1, posIdx2 - posIdx1));
          return myobj;
        case "VRECTANGLE":
          VRectangle myobj = new VRectangle();
          myobj.Deserialize(para);
          return myobj;
        case "VELIPSE":
          VElipse myobj = new VElipse();
          myobj.Deserialize(para);
          return myobj;
        case "VLINE":
          VLine myobj = new VLine();
          myobj.Deserialize(para);
          return myobj;
        default:
          return null;
      }
    }

    public string GetHtmlBorder() {
      if (this.borderPen != null)
        return " border: " + this.borderPen.Width + "px solid " + Helper.Color2HTMLString(this.borderPen.Color) + "; ";
      return "";
    }
    public string GetHtmlRotation() {
      if (this.Rotation != 0)
        return "transform: rotate(" + Rotation + "deg); -moz-transform: rotate(" + Rotation + "deg); -webkit-transform: rotate(" + Rotation + "deg); -o-transform: rotate(" + Rotation + "deg); ";
      return "";
    }

    public virtual string[] Serialize() {
      string[] data = new string[19];
      data[1] = this.GetType().Name;
      data[2] = bounds.X;
      data[3] = bounds.Y;
      data[4] = bounds.Width;
      data[5] = bounds.Height;
      data[6] = ZIndex;
      data[7] = name;
      data[8] = created;
      if (borderPen != null) {
        data[9] = borderPen.Width;
        data[10] = Helper.Color2String(borderPen.Color);
      }
      data[11] = "V2";
      //reserve
      data[12] = Rotation;
      data[13] = borderPen.DashStyle;
      //reserve
      data[14] = "";
      //reserve
      data[15] = "";
      //reserve
      data[16] = "";
      //reserve
      data[17] = "";
      //reserve
      data[18] = "";
      //reserve
      return data;
    }
    public virtual void Deserialize(string[] Data, ref int offset) {
      Array.Resize(ref Data, 20);
      m_bounds.X = Data[2];
      m_bounds.Y = Data[3];
      m_bounds.Width = Data[4];
      m_bounds.Height = Data[5];
      OnBoundsChanged();
      ZIndex = Data[6];
      name = Data[7];
      created = Data[8];
      if (Conversion.Val(Data[9]) > 0) {
        BorderWidth = Conversion.Val(Data[9]);
        borderPen.Color = Helper.String2Color(Data[10]);
      }
      if (Data[11] == "V2") {
        offset = 19;
        Rotation = Conversion.Val(Data[12]);
        borderPen.DashStyle = Conversion.Val(Data[13]);
      } else {
        offset = 11;
      }
    }
    public virtual void Deserialize(string[] Data) {
      Deserialize(Data, ref 0);
    }

    public virtual bool HitTest(Point pnt) {
      return bounds.Contains(pnt);
    }

    public virtual VResizeDirection HitTestResizer(Point pnt) {
      for (i = 0; i <= 3; i++) {
        if (m_resizeBounds[i].Contains(pnt))
          return i + 1;
      }
      return VResizeDirection.None;
    }

    public virtual bool HitTestRect(Rectangle rct) {
      return rct.Contains(bounds);
    }

    // Sub setBorder(ByVal width As Integer, ByVal color As Color)
    //   If width = 0 Then borderPen = Nothing : Exit Sub
    //   borderPen = New Pen(color, width)
    // End Sub

    public bool HasBorder() {
      return borderPen != null && borderPen.Width > 0;
    }

    public void DrawBorder(Graphics g) {
      if (HasBorder()) {
        g.DrawRectangle(borderPen, bounds);
      }
    }
    public virtual void DrawSelection(Graphics g) {
      if (isSelected) {
        g.DrawRectangle(selectionRectPen, bounds);
        for (i = 0; i <= 3; i++) {
          g.FillRectangle(ResizerBrsh, m_resizeBounds[i]);
        }
      }
      if (Parent.IsObjectBorderSelectionMode) {
        for (i = 0; i <= 9; i++) {
          g.DrawRectangle(Pens.Red, Convert.ToSingle(Left + Width * i / 10), Top + 1, 3, 3);
          g.DrawRectangle(Pens.Red, Convert.ToSingle(Left + Width * i / 10), bounds.Bottom - 4, 3, 3);
        }
        for (i = 0; i <= 9; i++) {
          g.DrawRectangle(Pens.Red, Left + 1, Convert.ToSingle(Top + Height * i / 10), 3, 3);
          g.DrawRectangle(Pens.Red, bounds.Right - 4, Convert.ToSingle(Top + Height * i / 10), 3, 3);
        }
      }
    }

  }

  //---------------------------------------------------------------------------------------

  public class VImage : VObject {
    public Image origimg;
    public Image img;

    public string source;
    protected override void DrawObjectInternal(System.Drawing.Graphics g) {
      g.DrawImage(img, bounds);
      // DrawBorder(g)
      //DrawSelection(g)
    }

    public void ApplyMatrix(ScreenGrab6.CSharpFilters.ConvMatrix m) {
      if (origimg == null)
        origimg = img;
      ScreenGrab6.CSharpFilters.BitmapFilter.Conv3x3(img, m);
    }

    public override string ToHtml() {
      dynamic base64 = Helper.ImageToBase64(this.img);
      return base.ToHtml() + "<img id=\"" + name + "\" alt=\"Screenshot\" style=\"position: absolute; " + GetHtmlRotation() + "z-index: " + this.ZIndex + "; margin-left: " + this.bounds.X + "px; margin-top: " + this.bounds.Y + "px; height: " + this.bounds.Height + "px; width: " + this.bounds.Width + "px; \"" + Constants.vbNewLine + "src=\"" + base64 + "\" />";
    }

    public override void Deserialize(string[] Data) {
      int rOffset = 0;
      base.Deserialize(Data, ref rOffset);
      Array.Resize(ref Data, rOffset + 2);
      source = Data[rOffset + 0];
    }

    public override string[] Serialize()
		{
			String[] data = base.Serialize();
			Array.Resize(ref data, CommonDataOffset + 2);
			data(CommonDataOffset + 0) = source;
			return data;
		}

  }

  //---------------------------------------------------------------------------------------

  public class VTextbox : VObject {
    private string p_text;
    private Font fnt;

    private SolidBrush brsh = new SolidBrush(Color.Black);
    public string Text {
      get { return p_text; }
      set {
        p_text = value;
        OnContentChanged();
      }
    }

    public Font Font {
      get { return fnt; }
      set {
        fnt = value;
        OnContentChanged();
      }
    }

    protected override void DrawObjectInternal(System.Drawing.Graphics g) {
      g.DrawString(Text, fnt, brsh, bounds);
      //, New StringFormat(StringFormatFlags.NoClip))
      //DrawBorder(g)
      //DrawSelection(g)
    }

    public override System.Drawing.Color Color1 {
      get {
        if (brsh is SolidBrush) {
          return ((SolidBrush)brsh).Color;
        } else {
          return null;
        }
      }
      set {
        if (brsh is SolidBrush) {
          ((SolidBrush)brsh).Color = value;
        } else {
          brsh = new SolidBrush(value);
        }
        OnContentChanged();
      }
    }
    public Brush Brush {
      get { return brsh; }
      set {
        brsh = value;
        OnContentChanged();
      }
    }

    public override string ToHtml() {
      dynamic fontInfo = "font: ";
      if (fnt.Italic)
        fontInfo += "italic ";
      if (fnt.Bold)
        fontInfo += "bold ";
      fontInfo += Strings.Replace(this.fnt.SizeInPoints, ",", ".") + "pt '" + this.fnt.FontFamily.Name + "'";
      if (fnt.Underline | fnt.Strikeout)
        fontInfo += "; text-decoration:";
      if (fnt.Underline)
        fontInfo += " underline";
      if (fnt.Strikeout)
        fontInfo += " line-through";
      fontInfo += ";";
      dynamic htmlText = this.Text;
      htmlText = Strings.Replace(htmlText, "<", "&lt;");
      htmlText = Strings.Replace(htmlText, ">", "&gt;");
      htmlText = Strings.Replace(htmlText, Constants.vbNewLine, "<br/>");
      htmlText = Strings.Replace(htmlText, Constants.vbNewLine, "<br/>");
      System.Text.RegularExpressions.Regex regx = new System.Text.RegularExpressions.Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
      dynamic matches = regx.Matches(htmlText);
      foreach (object match_loopVariable in matches) {
        match = match_loopVariable;
        htmlText = htmlText.Replace(match.Value, "<a href='" + match.Value + "'>" + match.Value + "</a>");
      }

      return base.ToHtml() + "<div id=\"" + name + "\" style=\"position: absolute; " + GetHtmlRotation() + "z-index: " + this.ZIndex + "; margin-left: " + this.bounds.X + "px; margin-top: " + this.bounds.Y + "px; height: " + this.bounds.Height + "px; width: " + this.bounds.Width + "px; " + "" + fontInfo + " color: " + Helper.Color2HTMLString(((SolidBrush)this.brsh).Color) + "; \">" + Constants.vbNewLine + htmlText + Constants.vbNewLine + "</div>";
    }

    public override void Deserialize(string[] Data) {
      int rOffset = 0;
      base.Deserialize(Data, ref rOffset);
      Array.Resize(ref Data, rOffset + 6);
      this.fnt = new Font(Data[rOffset + 0], Data[rOffset + 1], Data[rOffset + 2], GraphicsUnit.Point);
      this.brsh = new SolidBrush(Helper.String2Color(Data[rOffset + 3]));
    }

    public override string[] Serialize()
		{
			String[] data = base.Serialize();
			Array.Resize(ref data, CommonDataOffset + 6);
			data(CommonDataOffset + 0) = fnt.FontFamily.Name;
			data(CommonDataOffset + 1) = fnt.SizeInPoints;
			data(CommonDataOffset + 2) = Convert.ToInt32(fnt.Style);
			data(CommonDataOffset + 3) = Helper.Color2String(((SolidBrush)brsh).Color);
			return data;
		}


  }

  //---------------------------------------------------------------------------------------

  public abstract class VGradientObject : VObject, IGradientObject {

    protected SolidBrush fill = new SolidBrush(Color.Transparent);
    protected DrawingEx.ColorManagement.Gradients.Gradient mygradient;

    protected LinearGradientBrush gradientbrush;
    protected Brush GetDrawingBrush() {
      if (gradientbrush != null) {
        return gradientbrush;
      } else {
        return fill;
      }
    }

    public override System.Drawing.Color Color2 {
      get { return ((SolidBrush)fill).Color; }
      set {
        ((SolidBrush)fill).Color = value;
        OnContentChanged();
      }
    }
    public DrawingEx.ColorManagement.Gradients.Gradient Gradient {
      get { return mygradient; }
      set {
        mygradient = value;
        if (value == null) {
          gradientbrush = null;
        } else {
          LinearGradientBrush lnbrs = new LinearGradientBrush(bounds, Color.Transparent, Color.Black, LinearGradientMode.Vertical);
          lnbrs.InterpolationColors = mygradient;
          gradientbrush = lnbrs;
        }
        OnContentChanged();
      }
    }

  }


  public class VRectangle : VGradientObject {
    protected override void DrawObjectInternal(System.Drawing.Graphics g) {
      g.FillRectangle(GetDrawingBrush(), bounds);
      DrawBorder(g);
      //DrawSelection(g)
    }

    public override string ToHtml() {
      return base.ToHtml() + "<div id=\"" + name + "\" style=\"position: absolute; " + GetHtmlBorder() + GetHtmlRotation() + " background-color: " + Helper.Color2HTMLString(((SolidBrush)fill).Color) + "; " + "z-index: " + this.ZIndex + "; margin-left: " + this.bounds.X + "px; margin-top: " + this.bounds.Y + "px; height: " + this.bounds.Height + "px; width: " + this.bounds.Width + "px; " + "\">" + "</div>";
    }

    public override void Deserialize(string[] Data) {
      int rOffset = 0;
      base.Deserialize(Data, ref rOffset);
      Array.Resize(ref Data, rOffset + 2);
      this.fill = new SolidBrush(Helper.String2Color(Data[rOffset + 0]));
    }

    public override string[] Serialize()
		{
			String[] data = base.Serialize();
			Array.Resize(ref data, CommonDataOffset + 2);
			data(CommonDataOffset + 0) = Helper.Color2String(((SolidBrush)fill).Color);
			return data;
		}


  }

  //---------------------------------------------------------------------------------------

  public class VLine : VObject {

    private string _linesStartCap;

    private string _linesEndCap;
    public string startObject;
    public string endObject;
    public DockStyle startDock;
    public DockStyle endDock;
    public float startLocation;

    public float endLocation;
    public void EnforceDockPosition() {
      VObject so = Parent.GetObjectByID(startObject);
      if (so != null) {
        dynamic pnt = GetDockLocation(so, startDock, startLocation);
        SetStartLocation(pnt.X, pnt.Y);
      }
      VObject eo = Parent.GetObjectByID(endObject);
      if (eo != null) {
        dynamic pnt = GetDockLocation(eo, endDock, endLocation);
        SetEndLocation(pnt.X, pnt.Y);
      }
    }

    private Point GetDockLocation(VObject obj, DockStyle dock, float loc) {
      dynamic obounds = obj.bounds;
      if (obj is VLine) {
        // Dock an Linien
        switch (dock) {
          case DockStyle.Top:
          case DockStyle.Left:
            return obounds.Location;
          case DockStyle.Right:
          case DockStyle.Bottom:
            return obounds.Location + obounds.Size;
        }
      } else {
        //Dock an normalen Objekten
        switch (dock) {
          case DockStyle.Top:
            return new Point(obounds.Left + obounds.Width * loc, obounds.Top);
          case DockStyle.Bottom:
            return new Point(obounds.Left + obounds.Width * loc, obounds.Bottom);
          case DockStyle.Left:
            return new Point(obounds.Left, obounds.Top + obounds.Height * loc);
          case DockStyle.Right:
            return new Point(obounds.Right, obounds.Top + obounds.Height * loc);
        }
      }
    }

    public void SetStartLocation(int x, int y) {
      Width += Left - x;
      Height += Top - y;
      Left = x;
      Top = y;
    }
    public void SetEndLocation(int x, int y) {
      Width = -(Left - x);
      Height = -(Top - y);
    }

    public override int Rotation {
      get { return 0; }
      set { }
    }

    public string LinesStartCap {
      get { return _linesStartCap; }
      set {
        _linesStartCap = value;
        if (string.IsNullOrEmpty(value)) {
          borderPen.StartCap = LineCap.Flat;
        } else {
          borderPen.CustomStartCap = GetLineCapByString(value);
        }
      }
    }
    public string LinesEndCap {
      get { return _linesEndCap; }
      set {
        _linesEndCap = value;
        if (string.IsNullOrEmpty(value)) {
          borderPen.EndCap = LineCap.Flat;
        } else {
          borderPen.CustomEndCap = GetLineCapByString(value);
        }
      }
    }

    private CustomLineCap GetLineCapByString(string s) {
      GraphicsPath gp = new GraphicsPath();
      string[] lines = Strings.Split(s, "/");
      foreach (object line_loopVariable in lines) {
        line = line_loopVariable;
        string[] points = Strings.Split(line, ";");
        Array.Resize(ref points, 5);
        gp.AddLine(Convert.ToSingle(Conversion.Val(points[0])), Convert.ToSingle(Conversion.Val(points[1])), Convert.ToSingle(Conversion.Val(points[2])), Convert.ToSingle(Conversion.Val(points[3])));
      }
      return new Drawing2D.CustomLineCap(null, gp);
    }

    public override string ToHtml() {
      int len = Math.Sqrt((Math.Pow(Width, 2)) + (Math.Pow(Height, 2)));
      dynamic lineAngle = GetLineAngle();
      return base.ToHtml() + "<div id=\"" + name + "\" style=\"position: absolute; background-color: " + Helper.Color2HTMLString(borderPen.Color) + "; " + "z-index: " + this.ZIndex + "; margin-left: " + this.bounds.X + "px; margin-top: " + Convert.ToInt32(this.bounds.Y - (BorderWidth / 2)) + "px; height: " + borderPen.Width + "px; width: " + len + "px; " + "transform: rotate(" + lineAngle + "deg); -moz-transform: rotate(" + lineAngle + "deg); -webkit-transform: rotate(" + lineAngle + "deg); -o-transform: rotate(" + lineAngle + "deg); " + "transform-origin: left top; -moz-transform-origin: left top; -webkit-transform-origin: left top; -o-transform-origin: left top; \">" + "</div>";
    }

    public int GetLineAngle() {
      return Math.Atan2(Height, Width) * (180 / Math.PI);
      //Radiant->Grad

    }

    protected override void DrawObjectInternal(System.Drawing.Graphics g) {
      g.DrawLine(borderPen, bounds.X, bounds.Y, bounds.Right, bounds.Bottom);
      //DrawSelection(g)
      //  g.DrawString(GetLineAngle() & "°", FRM.Font, Brushes.Black, Left, Top)
    }

    public override void DrawSelection(Graphics g) {
      if (isSelected) {
        if (startDock == DockStyle.None) {
          g.FillRectangle(ResizerBrsh, m_resizeBounds[0]);
        } else {
          g.DrawRectangle(Pens.Black, m_resizeBounds[0]);
        }
        if (endDock == DockStyle.None) {
          g.FillRectangle(ResizerBrsh, m_resizeBounds[3]);
        } else {
          g.DrawRectangle(Pens.Black, m_resizeBounds[3]);
        }
      }
    }

    public override void DrawMoveRect() {
      dynamic mr = Parent.PicBox.RectangleToScreen(this.moveTempRect);
      ControlPaint.DrawReversibleLine(new Point(mr.Left, mr.Top), new Point(mr.Right, mr.Bottom), Color.White);
    }

    public override bool HitTest(System.Drawing.Point pnt) {

      if (Math.Min(bounds.Left, bounds.Right) - borderPen.Width < pnt.X & Math.Max(bounds.Left, bounds.Right) + borderPen.Width > pnt.X & Math.Min(bounds.Top, bounds.Bottom) - borderPen.Width < pnt.Y & Math.Max(bounds.Top, bounds.Bottom) + borderPen.Width > pnt.Y) {
        dynamic dist = DistancePointLine(pnt.X, pnt.Y, bounds.Left, bounds.Top, bounds.Right, bounds.Bottom);
        if (dist < 5)
          return true;
      }
    }

    public override VResizeDirection HitTestResizer(Point pnt) {
      if (startDock == DockStyle.None & m_resizeBounds[0].Contains(pnt))
        return 0 + 1;
      if (endDock == DockStyle.None & m_resizeBounds[3].Contains(pnt))
        return 3 + 1;
      return VResizeDirection.None;
    }

    public override void Deserialize(string[] Data) {
      int rOffset = 0;
      base.Deserialize(Data, ref rOffset);
      Array.Resize(ref Data, rOffset + 9);
      LinesStartCap = Data[rOffset + 0];
      LinesEndCap = Data[rOffset + 1];
      startObject = Data[rOffset + 2];
      startDock = Conversion.Val(Data[rOffset + 3]);
      startLocation = Data[rOffset + 4];
      endObject = Data[rOffset + 5];
      endDock = Data[rOffset + 6];
      endLocation = Data[rOffset + 7];
    }

    public override string[] Serialize()
		{
			String[] data = base.Serialize();
			Array.Resize(ref data, CommonDataOffset + 9);
			data(CommonDataOffset + 0) = LinesStartCap;
			data(CommonDataOffset + 1) = LinesEndCap;
			data(CommonDataOffset + 2) = startObject;
			data(CommonDataOffset + 3) = startDock;
			data(CommonDataOffset + 4) = startLocation;
			data(CommonDataOffset + 5) = endObject;
			data(CommonDataOffset + 6) = endDock;
			data(CommonDataOffset + 7) = endLocation;
			return data;
		}

    private int DistancePointLine(int px, int py, int lx0, int ly0, int lx1, int ly1) {
      return Math.Abs(((ly0 - ly1) * px + (lx1 - lx0) * py + (lx0 * ly1 - lx1 * ly0)) / (Math.Sqrt(Math.Pow((lx1 - lx0), 2) + Math.Pow((ly1 - ly0), 2))));
    }

  }

  //---------------------------------------------------------------------------------------

  public class VElipse : VGradientObject {

    public override string ToHtml() {
      dynamic img = GetAsImage();
      dynamic base64 = Helper.ImageToBase64(img);
      return base.ToHtml() + "<div style=\"position: absolute; " + "z-index: " + this.ZIndex + "; margin-left: " + this.bounds.X + "px; margin-top: " + this.bounds.Y + "px; height: " + this.bounds.Height + "px; width: " + this.bounds.Width + "px; \">" + Constants.vbNewLine + "<img src=\"" + base64 + "\" alt=\"VElipse Object\" />" + "</div>";
    }

    protected override void DrawObjectInternal(System.Drawing.Graphics g) {
      g.FillEllipse(GetDrawingBrush(), bounds);
      g.DrawEllipse(borderPen, bounds);
      //DrawSelection(g)
    }

    public override void Deserialize(string[] Data) {
      int rOffset = 0;
      base.Deserialize(Data, ref rOffset);
      Array.Resize(ref Data, rOffset + 2);
      this.fill = new SolidBrush(Helper.String2Color(Data[rOffset + 0]));
    }

    public override string[] Serialize()
		{
			String[] data = base.Serialize();
			Array.Resize(ref data, CommonDataOffset + 2);
			data(CommonDataOffset + 0) = Helper.Color2String(Color2);
			return data;
		}
  }

  //---------------------------------------------------------------------------------------

  //Public Class VBlur
  //  Inherits VObject
  //  Public Declare Function GetPixel Lib "gdi32" Alias "GetPixel" _
  //  (ByVal hdc As IntPtr, ByVal X As Int32, ByVal Y As Int32) As Int32

  //  Public Declare Function SetPixel Lib "gdi32" Alias "SetPixel" _
  //  (ByVal hdc As IntPtr, ByVal X As Int32, ByVal Y As Int32, ByVal c As Int32) As Int32

  //  Public Overrides Function ToHtml() As String
  //    Dim img = GetAsImage()
  //    Dim base64 = Helper.ImageToBase64(img)
  //    Return MyBase.ToHtml() + "<div style=""position: absolute; " & _
  //                      "z-index: " & Me.ZIndex & "; margin-left: " & Me.bounds.X & "px; margin-top: " & Me.bounds.Y & "px; height: " & Me.bounds.Height & "px; width: " & Me.bounds.Width & "px; "">" & _
  //    vbNewLine & "<img src=""" & base64 & """ alt=""VElipse Object"" />" & "</div>"
  //  End Function

  //  Protected Overrides Sub DrawObjectInternal(ByVal g As System.Drawing.Graphics)
  //    Dim dc = g.GetHdc

  //    'B << 16 or G << 8 or R
  //    g.ReleaseHdc(dc)
  //  End Sub

  //  Public Overrides Sub Deserialize(ByVal Data() As String)
  //    Dim rOffset As Integer
  //    MyBase.Deserialize(Data, rOffset)
  //    ReDim Preserve Data(rOffset + 1)
  //    Me.fill = New SolidBrush(Helper.String2Color(Data(rOffset + 0)))
  //  End Sub

  //  Public Overrides Function Serialize() As String()
  //    Dim data() = MyBase.Serialize()
  //    ReDim Preserve data(CommonDataOffset + 1)
  //    data(CommonDataOffset + 0) = Helper.Color2String(Color2)
  //    Return data
  //  End Function
  //End Class

  //---------------------------------------------------------------------------------------

  public enum VUMLVisibility {
    Public,
    Protected,
    Private
  }
  public class VUMLMethod {
    private bool p_IsShared;
    private string p_Name;
    private bool p_IsVoid;
    private string p_ReturnValue;
    private List<string[]> p_Parameters = new List<string[]>();
    private VUMLVisibility p_Visibility;
    public bool IsShared {
      get { return p_IsShared; }
      set { p_IsShared = value; }
    }

    public string Name {
      get { return p_Name; }
      set { p_Name = value; }
    }
    public bool IsVoid {
      get { return p_IsVoid; }
      set { p_IsVoid = value; }
    }
    public string ReturnValue {
      get { return p_ReturnValue; }
      set { p_ReturnValue = value; }
    }
    public List<string[]> Parameters {
      get { return p_Parameters; }
    }
    public VUMLVisibility Visibility {
      get { return p_Visibility; }
      set { p_Visibility = value; }
    }

    public string ParameterName {
      get { return Parameters[idx][0]; }
    }
    public string ParameterType {
      get { return Parameters[idx][1]; }
    }
    public int ParameterCount {
      get { return Parameters.Count; }
    }
    public override string ToString() {
      return Visibility == VUMLVisibility.Public ? "+" : Visibility == VUMLVisibility.Private ? "-" : "#" + " " + IsShared ? "$" : "  " + " " + IsVoid ? "!" : "?" + "  " + Name + " (" + GetParametersString() + ") " + IsVoid ? "" : " : " + ReturnValue;
    }
    public string GetParametersString() {
      string[] para = new string[Parameters.Count];
      for (i = 0; i <= para.Length - 1; i++) {
        para[i] = Strings.Join(Parameters[i], " : ");
      }
      return Strings.Join(para, ", ");
    }
    public static VUMLMethod FromString(string str)
		{
			dynamic d = System.Text.RegularExpressions.Regex.Match(str, "^\\s*([+#-])\\s*(\\$?)\\s*([\\!\\?])\\s*([a-zA-Z0-9_-]+)\\s*\\(([^)]*)\\)(\\s*:\\s*([a-zA-Z0-9_<>\\[\\]()-]+))?\\s*$");
			if (d.Success == false)
				return null;
			// For Each xxxx In d.Groups
			// Debug.Print(xxxx.index & " = " & xxxx.value)
			// Next
			VUMLMethod m = new VUMLMethod();
			switch (d.Groups(1).Value) {
				case "+":
					m.Visibility = VUMLVisibility.Public;
					break;
				case "#":
					m.Visibility = VUMLVisibility.Protected;
					break;
				case "-":
					m.Visibility = VUMLVisibility.Private;
					break;
			}
			m.Name = d.Groups(4).Value;
			if (d.Groups(3).Value == "?" & d.Groups(6).Success)
				m.ReturnValue = d.Groups(7).Value;
			else
				m.IsVoid = true;
			if (d.Groups(2).Value == "$")
				m.IsShared = true;
			string[] @params = Strings.Split(d.Groups(5).Value, ",");
			foreach (object para_loopVariable in @params) {
				para = para_loopVariable;
				String[] splitted = Strings.Split(para, ":");
				if (splitted.Length != 2)
					continue;
				splitted(0) = Strings.Trim(splitted(0));
				splitted(1) = Strings.Trim(splitted(1));
				m.Parameters.Add(splitted);
			}
			return m;
		}
  }
  public class VUMLAttribute {
    private bool p_IsShared;
    private string p_Name;
    private string p_Type;

    private VUMLVisibility p_Visibility;
    public bool IsShared {
      get { return p_IsShared; }
      set { p_IsShared = value; }
    }

    public string Name {
      get { return p_Name; }
      set { p_Name = value; }
    }
    public string Type {
      get { return p_Type; }
      set { p_Type = value; }
    }
    public VUMLVisibility Visibility {
      get { return p_Visibility; }
      set { p_Visibility = value; }
    }

    public override string ToString() {
      return Visibility == VUMLVisibility.Public ? "+" : Visibility == VUMLVisibility.Private ? "-" : "#" + " " + IsShared ? "$" : "  " + " " + Name + " : " + Type;
    }
    public static VUMLAttribute FromString(string str) {
      dynamic d = System.Text.RegularExpressions.Regex.Match(str, "^\\s*([+#-])\\s*(\\$?)\\s*([a-zA-Z0-9_()\\[\\]-]+)\\s*:\\s*([a-zA-Z0-9_<>\\[\\]()-]+)\\s*$");
      if (d.Success == false)
        return null;
      VUMLAttribute a = new VUMLAttribute();
      switch (d.Groups(1).Value) {
        case "+":
          a.Visibility = VUMLVisibility.Public;
          break;
        case "#":
          a.Visibility = VUMLVisibility.Protected;
          break;
        case "-":
          a.Visibility = VUMLVisibility.Private;
          break;
      }
      if (d.Groups(2).Value == "$")
        a.IsShared = true;
      a.Name = d.Groups(3).Value;
      a.Type = d.Groups(4).Value;
      return a;
    }
  }
  public class VUMLClass : VObject {

    public Brush fill = new SolidBrush(Color.Transparent);
    public VUMLVisibility Visibility;
    public string ClassName;
    public List<VUMLMethod> Methods = new List<VUMLMethod>();
    public List<VUMLAttribute> Attributes = new List<VUMLAttribute>();

    public string Subtitle;
    private static Font font1 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point);

    private static Font font2 = new Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point);
    protected override void DrawObjectInternal(System.Drawing.Graphics g) {
      int box1Height = 30 + string.IsNullOrEmpty(Subtitle) ? 0 : 15;
      g.FillRectangle(Brushes.White, bounds);
      g.FillRectangle(fill, Left, Top, Width, box1Height);

      if (HasBorder())
        g.DrawLine(borderPen, Left, Top + box1Height, bounds.Right, Top + box1Height);
      DrawBorder(g);

      g.DrawString(ClassName, font1, Brushes.White, Left + 3, Top + 3);
      g.DrawString(Subtitle, font2, Brushes.White, Left + 3, Top + 20);

      dynamic yy = Top + box1Height + 4;

      foreach (object v_loopVariable in Attributes) {
        v = v_loopVariable;
        Font fnt = new Font(font2, v.IsShared ? FontStyle.Underline : FontStyle.Regular);
        dynamic siz = g.MeasureString(v.ToString(), fnt, Width - 10);
        g.DrawString(v.ToString(), fnt, Brushes.Black, new Rectangle(Left + 3, yy, Width, siz.Height));
        yy += siz.Height + 3;
      }

      yy += 5;
      if (HasBorder())
        g.DrawLine(borderPen, Left, yy, bounds.Right, yy);
      yy += 5;

      foreach (object v_loopVariable in Methods) {
        v = v_loopVariable;
        Font fnt = new Font(font2, v.IsShared ? FontStyle.Underline : FontStyle.Regular);
        dynamic siz = g.MeasureString(v.ToString(), fnt, Width - 10);
        g.DrawString(v.ToString(), fnt, Brushes.Black, new Rectangle(Left + 3, yy, Width, siz.Height));
        yy += siz.Height + 3;
      }

      //DrawSelection(g)
    }

    public override System.Drawing.Color Color2 {
      get { return ((SolidBrush)fill).Color; }
      set {
        ((SolidBrush)fill).Color = value;
        OnContentChanged();
      }
    }

    public void ParseHtmlContent(string str)
		{
			String[] LINES = Strings.Split(str, Constants.vbNewLine);
			int block = 0;
			for (i = 0; i <= LINES.Length - 1; i++) {
				dynamic line = Helper.DecodeHtmlTags(Helper.StripHtmlTags(LINES(i)));

				if (LINES(i).Contains("<!--Attr-->"))
					block = 1;
				if (LINES(i).Contains("<!--Meth-->"))
					block = 2;

				if (string.IsNullOrEmpty(line))
					continue;

				if (LINES(i).Contains("<!--Class-->"))
					ClassName = line;
				if (LINES(i).Contains("<!--Subtitle-->"))
					Subtitle = line;


				if (block == 1) {
					dynamic a = VUMLAttribute.FromString(line);
					if (a != null)
						Attributes.Add(a);
				}
				if (block == 2) {
					dynamic m = VUMLMethod.FromString(line);
					if (m != null)
						Methods.Add(m);
				}

			}
		}

    public override string ToHtml() {
      System.Text.StringBuilder @out = new System.Text.StringBuilder();
      @out.Append(base.ToHtml());
      @out.AppendLine("<div id=\"" + name + "\" style=\"position: absolute; " + GetHtmlBorder() + GetHtmlRotation() + "  " + "z-index: " + this.ZIndex + "; margin-left: " + this.bounds.X + "px; margin-top: " + this.bounds.Y + "px; height: " + this.bounds.Height + "px; width: " + this.bounds.Width + "px; " + "\">");
      @out.AppendLine("<p class='title' style='color:white; background-color: " + Helper.Color2HTMLString(((SolidBrush)fill).Color) + ";'>");
      @out.AppendLine("<!--Class--><b>" + Helper.EncodeHtmlTags(ClassName) + "</b>");
      @out.AppendLine(!string.IsNullOrEmpty(Subtitle) ? "<!--Subtitle--><br/>" + Helper.EncodeHtmlTags(Subtitle) : "");
      @out.AppendLine("</p>");
      @out.AppendLine("<!--Attr--><hr />");

      foreach (object v_loopVariable in Attributes) {
        v = v_loopVariable;
        @out.AppendLine("<p>" + Helper.EncodeHtmlTags(v.ToString()) + "</p>");
      }

      @out.AppendLine("<!--Meth--><hr />");

      foreach (object v_loopVariable in Methods) {
        v = v_loopVariable;
        @out.AppendLine("<p>" + Helper.EncodeHtmlTags(v.ToString()) + "</p>");
      }
      @out.AppendLine("</div>");
      return @out.ToString();
    }

    public override void Deserialize(string[] Data) {
      int rOffset = 0;
      base.Deserialize(Data, ref rOffset);
      Array.Resize(ref Data, rOffset + 2);
      this.fill = new SolidBrush(Helper.String2Color(Data[rOffset + 0]));
    }

    public override string[] Serialize()
		{
			String[] data = base.Serialize();
			Array.Resize(ref data, CommonDataOffset + 2);
			data(CommonDataOffset + 0) = Helper.Color2String(((SolidBrush)fill).Color);
			return data;
		}


  }

}
