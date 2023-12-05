using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButtonSelector : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject _pauseButton;

    private void Start()
    {
        GameInputManager.Instance.OnPausePerformed += GameInputManager_OnPausePerformed;
    }

    private void GameInputManager_OnPausePerformed(object sender, System.EventArgs e)
    {
        _eventSystem.firstSelectedGameObject = _pauseButton;
    }
}
