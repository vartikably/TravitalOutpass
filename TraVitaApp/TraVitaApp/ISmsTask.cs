using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraVitaApp
{
    public interface ISmsTask
    {
        bool CanSendSms { get; }
        bool CanSendSmsInBackground { get; }
        void SendSms(string recipient, string message);
        void SendSmsInBackground(string recipient, string message);
    }
}
