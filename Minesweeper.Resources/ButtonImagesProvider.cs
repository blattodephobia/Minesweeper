using System.Drawing;

namespace Minesweeper.Resources
{
	public static class ButtonImagesProvider
	{
		private static Bitmap smiley_angel;
		private static Bitmap smiley_cool;
		private static Bitmap smiley_frown;
		private static Bitmap smiley_happy;
		private static Bitmap smiley_devil_laugh;
		private static Bitmap smiley_devil_normal;
		private static Bitmap smiley_devil_frown;
		private static Bitmap button_bg_normal;
		private static Bitmap buttong_bg_pressed;

		public static Bitmap SmileyAngel
		{
			get
			{
				if (smiley_angel == null)
				{
					smiley_angel = Smileys.smiley_angel;
				}

				return smiley_angel;
			}
		}

		public static Bitmap SmileyCool
		{
			get
			{
				if (smiley_cool == null)
				{
					smiley_cool = Smileys.smiley_cool;
				}

				return smiley_cool;
			}
		}

		public static Bitmap SmileyDevilLaugh
		{
			get
			{
				if (smiley_devil_laugh == null)
				{
					smiley_devil_laugh = Smileys.smiley_devil_laugh;
				}

				return smiley_devil_laugh;
			}
		}

		public static Bitmap SmileyDevilNormal
		{
			get
			{
				if (smiley_devil_normal == null)
				{
					smiley_devil_normal = Smileys.smiley_devil_normal;
				}

				return smiley_devil_normal;
			}
		}

		public static Bitmap SmileyDevilFrown
		{
			get
			{
				if (smiley_devil_frown == null)
				{
					smiley_devil_frown = Smileys.smiley_devil_frown;
				}

				return smiley_devil_frown;
			}
		}

		public static Bitmap SmileyFrown
		{
			get
			{
				if (smiley_frown == null)
				{
					smiley_frown = Smileys.smiley_frown;
				}

				return smiley_frown;
			}
		}

		public static Bitmap SmileyHappy
		{
			get
			{
				if (smiley_happy == null)
				{
					smiley_happy = Smileys.smiley_happy;
				}

				return smiley_happy;
			}
		}

		public static Bitmap ButtonBackgroundNormal
		{
			get
			{
				if (button_bg_normal == null)
				{
					button_bg_normal = ButtonBackgrounds.button_bg;
				}

				return button_bg_normal;
			}
		}

		public static Bitmap ButtonBackgroundPressed
		{
			get
			{
				if (buttong_bg_pressed == null)
				{
					buttong_bg_pressed = ButtonBackgrounds.button_bg_pressed;
				}

				return buttong_bg_pressed;
			}
		}
	}
}
