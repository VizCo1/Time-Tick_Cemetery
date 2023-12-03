using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{

    public static LoaderCallback Instance { get; private set; }

    private bool _canLoadScene = false;

    private void Awake()
    {
        Instance = this;
        MusicManager.Instance.StopMusic();
    }

    private void Update()
    {
        if (_canLoadScene)
        {
            _canLoadScene = false;

            Loader.LoaderCallback();
        }   
    }

    public void CanLoadScene()
    {
        _canLoadScene = true;
    }
}
