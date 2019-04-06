namespace Minesweeper.Components
{
	public sealed class FieldConfiguration
	{
		private static FieldConfiguration beginner;
		private static FieldConfiguration intermediate;
		private static FieldConfiguration advanced;

		private int width;
		private int height;
		private int minesCount;

		public int Width
		{
			get
			{
				return width;
			}

			set
			{
				if (ConfigurationName == CustomConfigString)
				{
					width = value;
				}
			}
		}

		public int Height
		{
			get
			{
				return height;
			}

			set
			{
				if (ConfigurationName == CustomConfigString)
				{
					height = value;
				}
			}
		}

		public int MinesCount
		{
			get
			{
				return minesCount;
			}

			set
			{
				if (ConfigurationName == CustomConfigString)
				{
					minesCount = value;
				}
			}
		}

		public string ConfigurationName { get; private set; }

		private FieldConfiguration(int width, int height, int minesCount, string configurationName)
		{
			this.width = width;
			this.height = height;
			this.minesCount = minesCount;
			ConfigurationName = configurationName;
		}

		public static string BeginnerConfigString
		{
			get
			{
				return "Beginner";
			}
		}

		public static string IntermediateConfigString
		{
			get
			{
				return "Intermediate";
			}
		}

		public static string AdvancedConfigString
		{
			get
			{
				return "Advanced";
			}
		}

		public static string CustomConfigString
		{
			get
			{
				return "Custom";
			}
		}

		public FieldConfiguration() :
			this(12, 12, 18, BeginnerConfigString)
		{
		}

		public FieldConfiguration(int width, int height, int minesCount) :
			this(width, height, minesCount, CustomConfigString)
		{
		}

		public FieldConfiguration(string width, string height, string minesCount)
		{
			bool parseResult =
				int.TryParse(width, out this.width) &&
				int.TryParse(height, out this.height) &&
				int.TryParse(minesCount, out this.minesCount);
			if (!parseResult)
			{
				Width = Intermediate.Width;
				Height = Intermediate.Height;
				MinesCount = Intermediate.MinesCount;
				ConfigurationName = IntermediateConfigString;
			}
			else
			{
				ConfigurationName = CustomConfigString;
			}
		}

		public static FieldConfiguration Beginner
		{
			get
			{
				if (beginner == null)
				{
					beginner = new FieldConfiguration(13, 13, 16, BeginnerConfigString);
				}

				return beginner;
			}
		}

		public static FieldConfiguration Intermediate
		{
			get
			{
				if (intermediate == null)
				{
					intermediate = new FieldConfiguration(18, 18, 50, IntermediateConfigString);
				}

				return intermediate;
			}
		}

		public static FieldConfiguration Advanced
		{
			get
			{
				if (advanced == null)
				{
					advanced = new FieldConfiguration(30, 16, 99, AdvancedConfigString);
				}

				return advanced;
			}
		}

		public static FieldConfiguration GetConfigurationByName(string configName)
		{
			if (configName == BeginnerConfigString)
			{
				return Beginner;
			}
			else if (configName == IntermediateConfigString)
			{
				return Intermediate;
			}
			else if (configName == AdvancedConfigString)
			{
				return Advanced;
			}
			else
			{
				return null;
			}
		}

		public override string ToString()
		{
			return ConfigurationName;
		}

		public override int GetHashCode()
		{
			return ConfigurationName.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj != null ? this.ToString() == obj.ToString() : false;
		}
	}
}