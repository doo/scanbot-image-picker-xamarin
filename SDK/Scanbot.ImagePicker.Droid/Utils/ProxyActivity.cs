using System;
using System.Collections.Concurrent;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;

namespace Scanbot.ImagePicker.Droid.Utils
{
    [Activity]
    internal class ProxyActivity : Activity
    {
        private class HandlerData
        {
            public Action<ActivityResult> Callback;
            public Intent Intent;
        };

        static readonly ConcurrentDictionary<int, HandlerData> activityResultCallbacks =
            new ConcurrentDictionary<int, HandlerData>();

        volatile static int callbackCounter = 100;

        public static void StartProxyResultActivity(Context context, Intent intent, Action<ActivityResult> callback)
        {
            var handlerData = new HandlerData
            {
                Intent = intent,
                Callback = callback,
            };

            int requestCode = callbackCounter;
            while (!activityResultCallbacks.TryAdd(requestCode, handlerData))
            {
                requestCode = Interlocked.Increment(ref callbackCounter);
            }

            Interlocked.Increment(ref callbackCounter);

            var proxyIntent = new Intent(context, typeof(ProxyActivity));
            proxyIntent.PutExtra("requestCode", requestCode);
            proxyIntent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(proxyIntent);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var requestCode = Intent.GetIntExtra("requestCode", -1);

            HandlerData handlerData;
            if (activityResultCallbacks.TryGetValue(requestCode, out handlerData))
            {
                if (handlerData.Intent != null)
                {
                    this.StartActivityForResult(handlerData.Intent, requestCode);
                    handlerData.Intent = null;
                }
            }
            else
            {
                this.Finish();
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            HandlerData handlerData;

            if (activityResultCallbacks.TryRemove(requestCode, out handlerData))
            {
                handlerData.Callback(new ActivityResult
                {
                    Result = resultCode,
                    Intent = data,
                });
            }

            Finish();
        }
    }
}
