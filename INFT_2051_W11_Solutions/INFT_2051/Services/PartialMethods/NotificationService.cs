﻿
namespace INFT_2051.Services.PartialMethods
{
    static partial class NotificationService
    {
        public static void SendNotification(string title, string message, DateTime scheduleTime)
        {
            DoSendNotification(title, message, scheduleTime);
        }
        static partial void DoSendNotification(string title, string message, DateTime scheduleTime);
    }
}
