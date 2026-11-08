using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryLearnShip.Common
{
    /// <summary>
    /// Defines a notification delivery mechanism.
    /// </summary>
    public interface INotification
    {
        /// <summary>
        /// Sends the specified message through the notification channel.
        /// </summary>
        void Send(string message);

        /// <summary>
        /// Returns the name of the notification channel.
        /// </summary>
        string ChannelName { get; }
    }
}
