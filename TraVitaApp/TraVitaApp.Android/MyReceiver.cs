using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;

namespace TraVitaApp.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED"}, Priority =(int)IntentFilterPriority.HighPriority)]
    public class MyReceiver : BroadcastReceiver
    {
        public static readonly string INTENT_ACTION = "android.provider.Telephony.SMS_RECEIVED";
        protected string message, address = "";

        public override void OnReceive(Context context, Intent intent)
        {
            if(intent.HasExtra("pdus"))
            {
                var smsArray = (Java.Lang.Object[])intent.Extras.Get("pdus");
                foreach(var item in smsArray)
                {
                    var sms = SmsMessage.CreateFromPdu((byte[])item);
                    address = sms.OriginatingAddress;
                    message = sms.MessageBody;
                    Toast.MakeText(context, "Received message!", ToastLength.Short).Show();
                    if(sms.MessageBody == "Yes")
                    {
                        Toast.MakeText(context, "Received message!", ToastLength.Short).Show();
                    }
                }
            }
            
        }
    }
}