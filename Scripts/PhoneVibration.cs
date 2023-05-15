using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneVibration : MonoBehaviour
{
    //public float vibrationDuration = 0.5f;
    //public float vibrationIntensity = 1f;

    //public void Vibrate()
    //{
    //    #if UNITY_ANDROID && !UNITY_EDITOR
    //    if (Application.platform == RuntimePlatform.Android)
    //    {
    //        if (AndroidPermissionsManager.CheckPermission("android.permission.VIBRATE"))
    //        {
    //            StartVibration();
    //        }
    //        else
    //        {
    //            AndroidPermissionsManager.RequestPermission("android.permission.VIBRATE", permissionGranted =>
    //            {
    //                if (permissionGranted)
    //                {
    //                    StartVibration();
    //                }
    //                else
    //                {
    //                    Debug.LogWarning("Vibration permission denied.");
    //                }
    //            });
    //        }
    //    }
    //    #endif
    //}

    //private void StartVibration()
    //{
    //    #if UNITY_ANDROID && !UNITY_EDITOR
    //    Handheld.Vibrate();
    //    StartCoroutine(StopVibration());
    //    #endif
    //}

    //private IEnumerator StopVibration()
    //{
    //    yield return new WaitForSeconds(vibrationDuration);
    //    Handheld.VibrateCancel();
    //}
}
