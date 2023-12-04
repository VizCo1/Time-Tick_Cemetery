using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WebMobileChecker
{
#if !UNITY_EDITOR && UNITY_WEBGL
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsMobile();
#endif

    public static bool CheckIfMobile()
    {
        var isMobile = false;

#if !UNITY_EDITOR && UNITY_WEBGL
        isMobile = IsMobile();
#endif

        return isMobile;
    }
}
