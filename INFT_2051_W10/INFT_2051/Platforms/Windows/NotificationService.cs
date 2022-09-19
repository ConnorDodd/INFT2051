using Microsoft.Maui;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT_2051.Services.PartialMethods
{
    static partial class NotificationService
    {
        static NotificationService()
        {

        }

        static partial void DoSendNotification(string title, string message, DateTime scheduleTime)
        {
            ToastButton button = new ToastButton()
                .SetContent("See More")
                .AddArgument("action", "seeMore")
                .SetAfterActivationBehavior(ToastAfterActivationBehavior.Default);

            new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText(title)
            .AddText(message)
            .AddButton(button)
            .Schedule(scheduleTime);
        }
    }
}
