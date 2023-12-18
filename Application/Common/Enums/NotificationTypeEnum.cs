using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Enums
{
    public enum NotificationTypeEnum
    {
        EmailWithSMTP = 1,
        EmailWithCredentials,
        SMS,
        PushNotification
    }
    public enum SexEnum
    {
        Male,
        Female,
        Others
    }

}
