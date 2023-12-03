using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
