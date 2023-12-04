using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsManager
{
    public static int IsMobile { get; private set; } = 0;
    public static int CameraRotates { get; private set; } = 1;

    public static void InitSettings()
    {
        if (WebMobileChecker.CheckIfMobile())
        {
            IsMobile = 1;
            SavingManager.SaveSetting(SavingManager.SettingsKeys.IsMobile, IsMobile);
        }
        else
        {
            IsMobile = SavingManager.GetSetting(SavingManager.SettingsKeys.IsMobile);
        }

        CameraRotates = SavingManager.GetSetting(SavingManager.SettingsKeys.CameraRotates);
    }
}
