using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class HighscoresForm
    {
        private class HighscoreViewModelImpl : HighscoreViewModel
        {
            private readonly HighscoresForm _form;
            private readonly TextBox _playerTb;

            public HighscoreViewModelImpl(HighscoresForm form, TextBox playerTb)
            {
                _form = form;
                if (playerTb != null)
                {
                    _playerTb = playerTb;
                    _playerTb.TextChanged += _playerTb_TextChanged;
                }
            }

            private void _playerTb_TextChanged(object sender, EventArgs e)
            {
                PlayerName = (sender as TextBox).Text;
            }

            public override bool CanSaveHighscore
            {
                get
                {
                    return base.CanSaveHighscore;
                }

                protected set
                {
                    base.CanSaveHighscore = _form.acceptButton.Enabled = value;
                }
            }

            public override bool CanEditPlayerName
            {
                get
                {
                    return base.CanEditPlayerName;
                }
                
                set
                {
                    base.CanEditPlayerName = value;
                    if (_playerTb != null)
                    {
                        _playerTb.Enabled = value;
                    }
                }
            }

            public override string PlayerName
            {
                get
                {
                    return base.PlayerName;
                }

                set
                {
                    base.PlayerName = _playerTb.Text = value;
                }
            }
        }
    }
}
