using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class HighscoreViewModelTests
    {
        [Test]
        public void DoesntAllowSavingHighscoreIfEmptyName()
        {
            HighscoreViewModel vm = new HighscoreViewModel() { CanEditPlayerName = true };

            vm.PlayerName = null;

            Assert.IsFalse(vm.CanSaveHighscore);
        }

        [Test]
        public void DoesntAllowSavingHighscoreIfWhitespaceName()
        {
            HighscoreViewModel vm = new HighscoreViewModel() { CanEditPlayerName = true };

            vm.PlayerName = "        ";

            Assert.IsFalse(vm.CanSaveHighscore);
        }

        [Test]
        public void AllowSavingHighscoreIfNonEmptyName()
        {
            HighscoreViewModel vm = new HighscoreViewModel() { CanEditPlayerName = true };

            vm.PlayerName = "blatta blatta";

            Assert.IsTrue(vm.CanSaveHighscore);
        }

        [Test]
        public void DoesntChangePlayerNameIfEditingDisabled()
        {
            HighscoreViewModel vm = new HighscoreViewModel() { CanEditPlayerName = true };

            string initialName = "blatta blatta";
            vm.PlayerName = initialName;

            vm.CanEditPlayerName = false;
            vm.PlayerName = "other";

            Assert.AreEqual(initialName, vm.PlayerName);
        }
    }
}
