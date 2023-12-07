using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class SettingsManager
{
    public static int IsMobile { get; private set; } = 0;

    public static int CameraRotates { get; private set; } = 1;

    public static float MusicVolume { get; private set; } = 0f;

    public static float SFXVolume { get; private set; } = 0f;

    public static void InitSettings(AudioMixer audioMixer)
    {
        if (WebMobileChecker.CheckIfMobile())
        {
            IsMobile = 1;
            SavingManager.SaveSetting(SavingManager.SettingsKeys.IsMobile, IsMobile);
        }
        else 
        {
            IsMobile = SavingManager.GetIntSetting(SavingManager.SettingsKeys.IsMobile);
        }

        CameraRotates = SavingManager.GetIntSetting(SavingManager.SettingsKeys.CameraRotates, 1);

        MusicVolume = SavingManager.GetFloatSetting(SavingManager.SettingsKeys.MusicVolume, 1f);
        SFXVolume = SavingManager.GetFloatSetting(SavingManager.SettingsKeys.SoundsVolume, 1f);


        audioMixer.SetFloat("Music", Mathf.Log10(MusicVolume) * 20);
        audioMixer.SetFloat("Sounds", Mathf.Log10(SFXVolume) * 20);
    }
}
