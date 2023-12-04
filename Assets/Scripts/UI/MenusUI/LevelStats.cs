using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelStats : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _numberOfKeysText;
    [SerializeField] private SavingManager.RecordKeys _key;

    public int Record { get; set; } = 0;

    public void UpdateStats()
    {
        int newRecord = SavingManager.GetRecord(_key);
        if (newRecord > Record)
        {
            Record = newRecord;
        }
        _numberOfKeysText.SetText(Record.ToString());
    }
}