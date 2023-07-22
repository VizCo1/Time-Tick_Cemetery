using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUI : MonoBehaviour
{
    public static DashUI Instance { get; private set; }

    [SerializeField] private GameObject _dashKeyImage;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        _dashKeyImage.SetActive(true);
    }

    public void Hide()
    {
        _dashKeyImage?.SetActive(false);
    }
}
