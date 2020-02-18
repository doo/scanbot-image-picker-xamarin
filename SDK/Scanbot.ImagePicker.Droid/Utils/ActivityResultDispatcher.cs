using System;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace Scanbot.ImagePicker.Droid.Utils
{
    public static class ActivityResultDispatcher
    {
        private static readonly MethodInfo register, unregister;

        static ActivityResultDispatcher()
        {
            Type registry = typeof(ActivityResultCallbackRegistry);

            var flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
            register = registry.GetMethod("RegisterActivityResultCallback", flags);
            unregister = registry.GetMethod("UnregisterActivityResultCallback", flags);
        }

        public static Task<ActivityResult> ReceiveMainActivityResult(Activity mainActivity, Intent intent)
        {
            var tcs = new TaskCompletionSource<ActivityResult>();

            object reqId = null;
            Action<Result, Intent> cb = (result, data) =>
            {
                unregister.Invoke(null, new[] { reqId });
                tcs.SetResult(new ActivityResult
                {
                    Intent = data,
                    Result = result,
                });
            };

            reqId = register.Invoke(null, new[] { cb });

            mainActivity.StartActivityForResult(intent, (int)reqId);

            return tcs.Task;
        }

        public static Task<ActivityResult> ReceiveProxyActivityResult(Android.Content.Context context, Intent intent)
        {
            var tcs = new TaskCompletionSource<ActivityResult>();
            ProxyActivity.StartProxyResultActivity(context, intent, tcs.SetResult);
            return tcs.Task;
        }
    }
}
