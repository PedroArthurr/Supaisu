#region Libraries
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
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
            panel.gameObject.GetComponent<RectTransform>().transform.position = new Vector3(539, GetKeyboardHeight(true) / 5f, 0);
#endif
            //panel.gameObject.transform.position = Vector3.zero;
        }
        #endregion

        #region Custom methods
        public static int GetKeyboardHeight(bool includeInput)
        {
#if UNITY_ANDROID
            using (var unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                var unityPlayer = unityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer");
                var view = unityPlayer.Call<AndroidJavaObject>("getView");
                var dialog = unityPlayer.Get<AndroidJavaObject>("mSoftInputDialog");

                if (view == null || dialog == null)
                    return 0;

                var decorHeight = 0;

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