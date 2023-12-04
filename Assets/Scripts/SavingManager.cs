using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static log4net.Appender.ColoredConsoleAppender;

public static class SavingManager
{
    public enum Keys
    {
        Level1Record,
        Level2Record,
    }

    public static void SaveRecord(Keys key, int record)
    {
        PlayerPrefs.SetInt(key.ToString(), record);
    }

    public static int GetRecord(Keys key)
    {
        return PlayerPrefs.GetInt(key.ToString());
    }

    public static void ResetRecords()
    {
        foreach (string key in Enum.GetNames(typeof(Keys)))
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }
}
