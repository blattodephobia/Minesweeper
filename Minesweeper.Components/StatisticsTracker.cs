using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using Minesweeper.Extensions;

namespace Minesweeper.Components
{
	public static class StatisticsTracker
	{
		internal static RegistryKey AppRegistryKey
		{
			get
			{
				return ConfigurationManager.AppRegistryKey;
			}
		}

		private static string GetPlayerNameOnNewHighScore(FieldConfiguration activeConfig, int currentScore, IWin32Window invoker)
		{
			string result = null;
			if (NewHighscoreReached(activeConfig, currentScore))
			{
				using (HighscoresForm highscoreSelectionForm = new HighscoresForm(activeConfig, currentScore))
				{
					highscoreSelectionForm.ShowDialog(invoker);
					result = highscoreSelectionForm.PlayerName;
					if (string.IsNullOrEmpty(result))
					{
						result = "Anonymous";
					}
				}
			}
			return result;
		}

		private static HashSet<IMineField> bannedMineFields;
		public static HashSet<IMineField> BannedMineFields
		{
			get
			{
				if (bannedMineFields == null)
				{
					bannedMineFields = new HashSet<IMineField>();
				}

				return bannedMineFields;
			}
		}

		public static bool NewHighscoreReached(FieldConfiguration config, int currentScore)
		{
			bool newHighscoreReached = false;

			KeyValuePair<int, string> currentHighscore = GetHighscoreByConfigName(config);
			if (!string.IsNullOrEmpty(currentHighscore.Value))
			{
				newHighscoreReached = currentScore < currentHighscore.Key && currentScore > 0 && currentScore <= 999;
			}

			return newHighscoreReached;
		}

		public static KeyValuePair<int, string> HighscoreBeginner
		{
			get
			{
				int score = AppRegistryKey.GetValue("HScoreBegin", "999").ToString().ToInt32(999);
				string player = AppRegistryKey.GetValue("HScoreBeginName", "Anonymous").ToString();

				return new KeyValuePair<int, string>(score, player);
			}

			private set
			{
				AppRegistryKey.SetValue("HScoreBegin", value.Key.ToString());
				AppRegistryKey.SetValue("HScoreBeginName", string.IsNullOrEmpty(value.Value) ? "Anonymous" : value.Value);
			}
		}

		public static KeyValuePair<int, string> HighscoreIntermediate
		{
			get
			{
				int score = AppRegistryKey.GetValue("HScoreInterm", "999").ToString().ToInt32(999);
				string player = AppRegistryKey.GetValue("HScoreIntermName", "Anonymous").ToString();

				return new KeyValuePair<int, string>(score, player);
			}

			private set
			{
				AppRegistryKey.SetValue("HScoreInterm", value.Key.ToString());
				AppRegistryKey.SetValue("HScoreIntermName", string.IsNullOrEmpty(value.Value) ? "Anonymous" : value.Value);
			}
		}

		public static KeyValuePair<int, string> HighscoreAdvanced
		{
			get
			{
				int score = AppRegistryKey.GetValue("HScoreAdv", "999").ToString().ToInt32(999);
				string player = AppRegistryKey.GetValue("HScoreAdvName", "Anonymous").ToString();

				return new KeyValuePair<int, string>(score, player);
			}

			private set
			{
				AppRegistryKey.SetValue("HScoreAdv", value.Key.ToString());
				AppRegistryKey.SetValue("HScoreAdvName", string.IsNullOrEmpty(value.Value) ? "Anonymous" : value.Value);
			}
		}

		public static void TrySetPlayerNameOnNewHighscore(FieldConfiguration activeConfig, int currentScore, IWin32Window invoker)
		{
			string playerName = GetPlayerNameOnNewHighScore(activeConfig, currentScore, invoker);
			if (playerName != null)
			{
				KeyValuePair<int, string> newHighscore = new KeyValuePair<int, string>(currentScore, playerName);
				if (activeConfig.ConfigurationName == FieldConfiguration.BeginnerConfigString)
				{
					HighscoreBeginner = newHighscore;
				}
				else if (activeConfig.ConfigurationName == FieldConfiguration.IntermediateConfigString)
				{
					HighscoreIntermediate = newHighscore;
				}
				else if (activeConfig.ConfigurationName == FieldConfiguration.AdvancedConfigString)
				{
					HighscoreAdvanced = newHighscore;
				}
			}
		}

		public static int GamesWon
		{
			get
			{
				int gamesWon = AppRegistryKey.GetValue("Wins", "0").ToString().ToInt32(0);
				return gamesWon;
			}

			set
			{
				if (value < 0)
				{
					value = 0;
				}

				AppRegistryKey.SetValue("Wins", value.ToString());
			}
		}

		public static int GamesPlayed
		{
			get
			{
				int gamesPlayed = AppRegistryKey.GetValue("GamesPlayed", "0").ToString().ToInt32(0);
				return gamesPlayed;
			}

			set
			{
				if (value < 0)
				{
					value = 0;
				}

				AppRegistryKey.SetValue("GamesPlayed", value.ToString());
			}
		}

		public static int SuccessRate
		{
			get
			{
				int result = 0;
				if (GamesPlayed != 0)
				{
					double successRate = (double)GamesWon / GamesPlayed * 100;
					result = (int)successRate;
				}
				return result;
			}
		}

		public static KeyValuePair<int, string> GetHighscoreByConfigName(FieldConfiguration config)
		{
			return GetHighscoreByConfigName(config.ConfigurationName);
		}

		public static KeyValuePair<int, string> GetHighscoreByConfigName(string configName)
		{
			if (configName == FieldConfiguration.BeginnerConfigString)
			{
				return HighscoreBeginner;
			}
			else if (configName == FieldConfiguration.IntermediateConfigString)
			{
				return HighscoreIntermediate;
			}
			else if (configName == FieldConfiguration.AdvancedConfigString)
			{
				return HighscoreAdvanced;
			}
			else
			{
				return default(KeyValuePair<int, string>);
			}
		}

		public static void ShowLeaderboard(IWin32Window invoker)
		{
			HighscoresForm leaderboard = new HighscoresForm();
			if (invoker != null)
			{
				leaderboard.ShowDialog(invoker);
			}
			else
			{
				leaderboard.ShowDialog();
			}
		}

		public static void ShowStatistics(IWin32Window invoker)
		{
			string message = string.Format("Games won:\t{0}\nGames played:\t{1}\n----------------------------\nSuccess rate:\t{2}%", GamesWon, GamesPlayed, SuccessRate);
			MessageBox.Show(invoker, message, "Statistics", MessageBoxButtons.OK);
		}
	}
}
