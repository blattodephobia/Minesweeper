using System.Collections.Generic;
using Microsoft.Win32;
using Minesweeper.Extensions;

namespace Minesweeper.Components
{
	public static class ConfigurationManager
	{
		private static RegistryKey appRegKey;
		internal static RegistryKey AppRegistryKey
		{
			get
			{
				if (appRegKey == null)
				{
					appRegKey = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("Insectophobia\\Minesweeper");
				}

				return appRegKey;
			}
		}
		
		public static FieldConfiguration MostRecentFieldConfiguration
		{
			get
			{
				string mostRecentConfigName = AppRegistryKey.GetValue("ConfigID", "Beginner").ToString();
				FieldConfiguration result = FieldConfiguration.GetConfigurationByName(mostRecentConfigName);
				if (result == null)
				{
					int width = AppRegistryKey.GetValue("MostRecentConfigWidth", "13").ToString().ToInt32(13);
					int height = AppRegistryKey.GetValue("MostRecentConfigHeight", "13").ToString().ToInt32(13);
					int bombs = AppRegistryKey.GetValue("MostRecentConfigBombs", "18").ToString().ToInt32(18);
					result = new FieldConfiguration(width, height, bombs);
				}
				return result;
			}

			set
			{
				AppRegistryKey.SetValue("ConfigID", value.ConfigurationName);
				if (value.ConfigurationName == FieldConfiguration.CustomConfigString)
				{
					CustomConfigWidth = value.Width;
					CustomConfigHeight = value.Height;
					CustomConfigBombs = value.MinesCount;
				}
			}
		}

		public static int CustomConfigWidth
		{
			get
			{
				int width = AppRegistryKey.GetValue("MostRecentConfigWidth", "13").ToString().ToInt32(13);
				return width;
			}

			set
			{
				AppRegistryKey.SetValue("MostRecentConfigWidth", value.ToString());
			}
		}

		public static int CustomConfigHeight
		{
			get
			{
				int height = AppRegistryKey.GetValue("MostRecentConfigHeight", "13").ToString().ToInt32(13);
				return height;
			}

			set
			{
				AppRegistryKey.SetValue("MostRecentConfigHeight", value.ToString());
			}
		}

		public static int CustomConfigBombs
		{
			get
			{
				int bombs = AppRegistryKey.GetValue("MostRecentConfigBombs", "16").ToString().ToInt32(13);
				return bombs;
			}

			set
			{
				AppRegistryKey.SetValue("MostRecentConfigBombs", value.ToString());
			}
		}
	}
}