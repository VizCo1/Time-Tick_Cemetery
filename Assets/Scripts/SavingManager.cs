using System;
using UnityEngine;

public static class SavingManager
{
    public enum RecordKeys
    {
        Level1Record,
        Level2Record,
    }

    public enum SettingsKeys
    {
        IsMobile,
        CameraRotates,
        MusicVolume,
        SoundsVolume,
    }

    public static void SaveRecord(RecordKeys key, int record)
    {
        PlayerPrefs.SetInt(key.ToString(), record);
    }

    public static int GetRecord(RecordKeys key)
    {
        return PlayerPrefs.GetInt(key.ToString(), 0);
    }

    public static void SaveSetting(SettingsKeys key, int status)
    {
        PlayerPrefs.SetInt(key.ToString(), status);
    }
    
    public static void SaveSetting(SettingsKeys key, float value)
    {
        PlayerPrefs.SetFloat(key.ToString(), value);
    }

    public static void SaveSetting(SettingsKeys key, bool status)
    {
        int value = status ? 1 : 0;
        PlayerPrefs.SetInt(key.ToString(), value);
    }

    public static int GetIntSetting(SettingsKeys key, int defaultVal = 0)
    {
        return PlayerPrefs.GetInt(key.ToString(), defaultVal);
    }
    
    public static float GetFloatSetting(SettingsKeys key, float defaultVal = 0f)
    {
        return PlayerPrefs.GetFloat(key.ToString(), defaultVal);
    }

    public static void ResetRecords()
    {
        foreach (string key in Enum.GetNames(typeof(RecordKeys)))
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }
}
