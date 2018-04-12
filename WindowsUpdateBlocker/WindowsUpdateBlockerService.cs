using System;
using System.Collections.Generic;
using System.Threading;
using WindowsUpdateBlocker.Blockers;
using WindowsUpdateBlocker.Blockers.Support;
using WindowsUpdateBlocker.Extensions;

namespace WindowsUpdateBlocker
{
    public class WindowsUpdateBlockerService
    {
        private readonly List<IBlock> _blockers = new List<IBlock>();
        private Timer _intervalTimer;

        public void Start()
        {
            _blockers.Add(new WindowsUpdateServiceBlocker());

            _intervalTimer = new Timer(RunBlockers, null, TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
        }

        public void Stop()
        {
            try
            {
                _blockers.Clear();
                _intervalTimer.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Encountered exception while stopping service.\n    Message: {ex.Message}\n    StackTrace: {ex.StackTrace.Indent()}");
            }
        }

        private void QueueBlockers()
        {
            _intervalTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
        }

        private void RunBlockers(object state)
        {
            foreach (var blocker in _blockers)
            {
                blocker.Block();
            }

            QueueBlockers();
        }
    }
}