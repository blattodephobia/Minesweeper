using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class HighscoreViewModel
    {
        private string _playerName;
        public virtual string PlayerName
        {
            get
            {
                return _playerName;
            }

            set
            {
                if (CanEditPlayerName)
                {
                    _playerName = value;
                    CanSaveHighscore = !string.IsNullOrWhiteSpace(_playerName);
                }
            }
        }

        public virtual bool CanEditPlayerName { get; set; }

        public virtual bool CanSaveHighscore { get; protected set; }
    }
}
