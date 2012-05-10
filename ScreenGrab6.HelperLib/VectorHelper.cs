using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ScreenGrab6.Vector
{
	public enum VResizeDirection
	{
		None = 0,
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight,
		Top,
		Left,
		Bottom,
		Right
	}

  [StructLayout(LayoutKind.Sequential)]
  public struct RECT
  {
	  public int Left;
	  public int Top;
	  public int Right;

	  public int Bottom;
	  public RECT(int pLeft, int pTop, int pRight, int pBottom)
	  {
		  Left = pLeft;
		  Top = pTop;
		  Right = pRight;
		  Bottom = pBottom;
	  }
	  public RECT(Rectangle managedRect)
	  {
		  Left = managedRect.Left;
		  Top = managedRect.Top;
		  Right = managedRect.Right;
		  Bottom = managedRect.Bottom;
	  }
  }


	public class Helper
	{

		/// <summary>
		/// Gets the physical location of a font family from the registry
		/// </summary>
		/// <param name="fontName">Font family name</param>
		/// <returns>File path or String.Empty</returns>
		/// <remarks></remarks>
		public static string GetFontFilespec(string fontName)
		{
			string functionReturnValue = null;
			functionReturnValue = string.Empty;
			try {
				using (rkey == Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts", false)) {
					string fontFilespec = "";
					foreach (string d in rkey.GetValueNames) {
						if (d.StartsWith(fontName))
							fontFilespec = rkey.GetValue(d);
					}
					if (System.IO.File.Exists(fontFilespec) == false)
						fontFilespec = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("WINDIR"), fontFilespec);
					if (System.IO.File.Exists(fontFilespec))
						return fontFilespec;
				}
			} catch {
			}
			return functionReturnValue;
		}

		public static float PointDistance(Point pt1, Point pt2)
		{
			return Math.Sqrt((Math.Pow(Math.Abs(pt1.X - pt2.X), 2)) + (Math.Pow(Math.Abs(pt1.Y - pt2.Y), 2)));
		}

		public static string StripHtmlTags(string str)
		{
			return System.Text.RegularExpressions.Regex.Replace(str, "<(.|\\n)*?>", "");
		}

		public static string EncodeHtmlTags(string str)
		{
			return Strings.Replace(Strings.Replace(str, "<", "&lt;"), ">", "&gt;");
		}

		public static string DecodeHtmlTags(string str)
		{
			return Strings.Replace(Strings.Replace(str, "&lt;", "<"), "&gt;", ">");
		}

    public static Rectangle MakeRect(int x1, int y1, int x2, int y2) { MakeRect(x1, y1, x2, y2, false); }
		public static Rectangle MakeRect(int x1, int y1, int x2, int y2, bool DirectMode)
		{
			if (DirectMode)
				return new Rectangle(x1, y1, x2 - x1, y2 - y1);
			dynamic lx = Math.Min(x1, x2);
			dynamic ly = Math.Min(y1, y2);
			return new Rectangle(lx, ly, Math.Max(x1, x2) - lx, Math.Max(y1, y2) - ly);
		}

		public static bool IsArrowKey(Keys kc)
		{
			return kc >= 37 & kc <= 40;
		}

		public static Rectangle GetResizedRect(Rectangle sourceRect, VResizeDirection direction, Point startPoint, Point curPoint)
		{
			Rectangle functionReturnValue = default(Rectangle);
			dynamic deltaX = curPoint.X - sourceRect.X;
			dynamic deltaY = curPoint.Y - sourceRect.Y;
			functionReturnValue = sourceRect;
			//Dim resizes = ""
			if (direction == VResizeDirection.TopLeft | direction == VResizeDirection.TopRight) {
				//resizes += "TOP "        'top resize
				functionReturnValue.Y += deltaY;
				functionReturnValue.Height -= deltaY;
			}

			if (direction == VResizeDirection.TopLeft | direction == VResizeDirection.BottomLeft) {
				//resizes += "LEFT "     'left resize
				functionReturnValue.X += deltaX;
				functionReturnValue.Width -= deltaX;
			}

			if (direction == VResizeDirection.BottomLeft | direction == VResizeDirection.BottomRight) {
				//resizes += "BTM "     'bottom resize
				functionReturnValue.Height = deltaY;
			}

			if (direction == VResizeDirection.TopRight | direction == VResizeDirection.BottomRight) {
				//resizes += "RGT "    'right resize
				functionReturnValue.Width = deltaX;
			}
			return functionReturnValue;

			//Debug.Print(resizes)
		}


		public static string Color2String(Color c)
		{
			return string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", c.A, c.R, c.G, c.B);
		}

		public static string Color2HTMLString(Color c)
		{
			if (c.A < 255) {
				return string.Format(System.Globalization.CultureInfo.InvariantCulture.NumberFormat, "rgba({1},{2},{3},{0:0.00})", c.A / 255, c.R, c.G, c.B);
			} else {
				return string.Format("rgb({1},{2},{3})", c.A, c.R, c.G, c.B);
			}
		}

		public static Color String2Color(string c)
		{
			if (c.Length != 8)
				return Color.Black;
			return Color.FromArgb(Convert.ToByte(c.Substring(0, 2), 16), Convert.ToByte(c.Substring(2, 2), 16), Convert.ToByte(c.Substring(4, 2), 16), Convert.ToByte(c.Substring(6, 2), 16));
		}

		public static string ImageToBase64(Image img)
		{
			if (img == null)
				return "";
			System.IO.MemoryStream ms = new System.IO.MemoryStream();
			img.Save(ms, Imaging.ImageFormat.Png);
			//img.Save(ms, ImageFormat.Gif)

			ms.Seek(0, System.IO.SeekOrigin.Begin);
			byte[] buf = new byte[ms.Length];
			ms.Read(buf, 0, ms.Length);

			return "data:image/png;base64," + Convert.ToBase64String(buf, Base64FormattingOptions.None);
			//ImageToBase64 = "data:image/gif;base64," + Convert.ToBase64String(buf, Base64FormattingOptions.InsertLineBreaks)

		}

		public static Image Base64ToImage(System.Text.StringBuilder str)
		{
			Image functionReturnValue = default(Image);
			//abschneiden des Vorspanns und extrahieren des Datentyps ("data:" + type + ";base64,")
			int modus = 0;
			string datTyp = "";
			int abPos = 0;
			for (i = 0; i <= str.Length - 1; i++) {
				if (str[i] == ':'){modus = 1;continue;}
				if (str[i] == ';'){modus = 2;continue;}
				if (str[i] == ','){modus = 3;abPos = i + 1;break; // TODO: might not be correct. Was : Exit For
}
				if (modus == 1) {
					datTyp += str[i];
				}
			}
			dynamic img = str.ToString(abPos, str.Length - abPos);
			String[] byt = Convert.FromBase64String(img);
			System.IO.MemoryStream ms = new System.IO.MemoryStream(byt);
			functionReturnValue = Image.FromStream(ms);
			ms.Close();
			return functionReturnValue;
		}

	}
}
