using Minesweeper.Components;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.Tests.Components
{
    [TestFixture]
    public class StatisticsTrackerTests
    {
        public class StatisticsTrackerProxy : StatisticsTracker
        {
            protected override string EnterPlayerName(FieldConfiguration activeConfig, int currentScore, IWin32Window invoker)
            {
                return EnterPlayerNameProxy(activeConfig, currentScore, invoker);
            }

            public virtual string EnterPlayerNameProxy(FieldConfiguration activeConfig, int currentScore, IWin32Window invoker) => base.EnterPlayerName(activeConfig, currentScore, invoker);
        }

        [Test]
        public void ThrowsExceptionIfNullPlayerName()
        {
            var tracker = new Mock<StatisticsTrackerProxy>();
            tracker.Setup(x => x.NewHighscoreReached(It.IsAny<FieldConfiguration>(), It.IsAny<int>())).Returns(true);
            tracker.Setup(x => x.EnterPlayerNameProxy(It.IsAny<FieldConfiguration>(), It.IsAny<int>(), It.IsAny<IWin32Window>())).Returns("");
            Assert.Throws<Exception>(() => tracker.Object.TrySetPlayerNameOnNewHighscore(new FieldConfiguration(), 10, null));
        }
    }
}
