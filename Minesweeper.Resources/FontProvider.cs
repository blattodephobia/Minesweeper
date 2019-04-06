using System;
using System.Drawing;
using System.Drawing.Text;

namespace Minesweeper.Resources
{
	public static class FontProvider
	{
		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
		   IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

		unsafe private static void AddFont(byte[] fontData)
		{
			unsafe
			{
				fixed (byte* pFontData = fontData)
				{
					uint dummy = 0;
					MinesweeperFontCollection.AddMemoryFont((IntPtr)pFontData, fontData.Length);
					AddFontMemResourceEx((IntPtr)pFontData, (uint)fontData.Length, IntPtr.Zero, ref dummy);
				}
			}
		}

		private static FontFamily GetFontFamilyByName(string name)
		{
			foreach (FontFamily fontFamily in MinesweeperFontCollection.Families)
			{
				if (fontFamily.Name == name)
				{
					return fontFamily;
				}
			}

			throw new InvalidOperationException(string.Format("There is no registered font family with the name '{0}'", name));
		}

		private static PrivateFontCollection minesweeperFontCollection;
		public static PrivateFontCollection MinesweeperFontCollection
		{
			get
			{
				if (minesweeperFontCollection == null)
				{
					minesweeperFontCollection = new PrivateFontCollection();
				}

				return minesweeperFontCollection;
			}
		}

		private static FontFamily digital7;
		public static FontFamily Digital7
		{
			get
			{
				if (digital7 == null)
				{
					AddFont(FontDigital7.digital_7);
					digital7 = GetFontFamilyByName("Digital-7");
				}

				return digital7;
			}
		}

		private static FontFamily lcdDot;
		public static FontFamily LcdDot
		{
			get
			{
				if (lcdDot == null)
				{
					AddFont(FontLcdDot.lcddot_tr);
					lcdDot = GetFontFamilyByName("LCDDot TR");
				}

				return lcdDot;
			}
		}

		private static FontFamily sevenSegmentedDigital;
		public static FontFamily SevenSegmentedDigital
		{
			get
			{
				if (sevenSegmentedDigital == null)
				{
					AddFont(FontSegmentedDigits._7SDD);
					sevenSegmentedDigital = GetFontFamilyByName("7 SEGMENTAL DIGITAL DISPLAY");
				}

				return sevenSegmentedDigital;
			}
		}
	}
}
