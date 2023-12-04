using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsManager
{
    public static int IsMobile { get; private set; } = 1;
    public static int CameraRotates {  get; private set; }

    private static bool _alreadyInit = false;

    public static void InitSettings()
    {
        if (_alreadyInit) 
            return;

#if UNITY_IOS || UNITY_ANDROID && !UNITY_EDITOR
            IsMobile = 1;
#else
        IsMobile = 0;
#endif
        CameraRotates = 1;

        //SavingManager.SaveSetting(SavingManager.SettingsKeys.IsMobile, IsMobile);
        //SavingManager.SaveSetting(SavingManager.SettingsKeys.CameraRotates, CameraRotates);

        _alreadyInit = true;
    }
}
