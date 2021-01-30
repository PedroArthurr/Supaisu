#region Libraries

using System;
using UnityEngine;
#endregion
namespace PedroArthur
{
    public class KeyboardScreenAdjustment : MonoBehaviour
    {
        #region Variables
        [SerializeField] GameObject panel;
        #endregion

        #region MonoBehaviour methods
        void LateUpdate()
        {
#if UNITY_ANDROID
            try
            {
                panel.gameObject.GetComponent<RectTransform>().transform.position = new Vector3(539, GetKeyboardHeight(true) / 5f, 0);
            } catch {}
#endif
        }
        #endregion

        #region Custom methods
        public static int GetKeyboardHeight(bool includeInput)
        {
#if UNITY_ANDROID
            using (AndroidJavaObject unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject unityPlayer = unityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer");
                AndroidJavaObject view = unityPlayer.Call<AndroidJavaObject>("getView");
                AndroidJavaObject dialog = unityPlayer.Get<AndroidJavaObject>("mSoftInputDialog");

                if (view == null || dialog == null)
                    return 0;

                int decorHeight = 0;

                if (includeInput)
                {
                    var decorView = dialog.Call<AndroidJavaObject>("getWindow").Call<AndroidJavaObject>("getDecorView");

                    if (decorView != null)
                        decorHeight = decorView.Call<int>("getHeight");
                }

                using (var rect = new AndroidJavaObject("android.graphics.Rect"))
                {
                    view.Call("getWindowVisibleDisplayFrame", rect);
                    return Display.main.systemHeight - rect.Call<int>("height") + decorHeight;
                }
            }
#else
        var height = Mathf.RoundToInt(TouchScreenKeyboard.area.height);
        return height >= Display.main.systemHeight ? 0 : height;
#endif
        }
    }
    #endregion
}