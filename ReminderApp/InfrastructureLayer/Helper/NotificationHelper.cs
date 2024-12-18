using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ReminderApp.Infrastructure.Helper
{
    public class NotificationHelper : IDisposable
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly object _lock = new object();
        private bool _isDisposed = false;

        public NotificationHelper()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        public void ShowNotification(string title, string message, int duration = 6000)
        {
            
                if (_isDisposed)
                {
                    throw new ObjectDisposedException(nameof(NotificationHelper));
                }
                _notifyIcon.BalloonTipTitle = title;
                _notifyIcon.BalloonTipText = message;
                _notifyIcon.ShowBalloonTip(duration);
            
        }

        public void Dispose()
        {
            lock (_lock)
            {
                if (!_isDisposed)
                {
                    _notifyIcon.Dispose();
                    _isDisposed = true;
                }
            }
        }
    }
}
