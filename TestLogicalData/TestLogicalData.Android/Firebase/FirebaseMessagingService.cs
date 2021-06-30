using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace TestLogicalData.Droid.Firebase
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "FirebaseMsgService";
        AndroidNotificationManager androidNotification = new AndroidNotificationManager();
        public override void OnMessageReceived(RemoteMessage message)
        {
            // Crea la notificacion local
            androidNotification.CrearNotificacionLocal(message.GetNotification().Title, message.GetNotification().Body);
        }
        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);

            Preferences.Set("TokenFirebase", token);
            SendRegisterToken(token);
        }
        public void SendRegisterToken(string token)
        {
            //Si se llegara a necesitar que el token se almacene en nuestro backend 
        }
    }
}