using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoadingBarUI : MonoBehaviour
{

    [SerializeField] private Image _loadingBar;

    [SerializeField] private bool _autoStart = true;

    [Space]
    [Header("To value random between two values")]
    [SerializeField] [Tooltip("Initial value, usually 0")] private float _from = 0f;
    [SerializeField] private float _to1 = 0.5f;
    [SerializeField] private float _to2 = 0.8f;
    [Header("Duration value random between two values")]
    [SerializeField] private float _duration1 = 0.5f;
    [SerializeField] private float _duration2 = 1f;
    [Header("Restant duration value random between two values")]
    [SerializeField] private float _restantDuration1 = 0.5f;
    [SerializeField] private float _restantDuration2 = 1f;
    [Header("Ease type used to fill the loadin bar")]
    [SerializeField] private Ease _ease1;
    [SerializeField] private Ease _ease2;

    private void Start()
    {
        if (_autoStart)
        {
            StartLoadingBar();
        }
    }

    public void StartLoadingBar()
    {
        float to = Random.Range(_to1, _to2);
        float duration = Random.Range(_duration1, _duration2);

        float restantFrom = to;
        float restantTo = 1f;
        float restantDuration = Random.Range(_restantDuration1, _restantDuration2);

        Sequence loadingSequence = DOTween.Sequence()
            .Append(DOVirtual.Float(_from, to, duration, (float value) => _loadingBar.fillAmount = value).SetEase(_ease1))
            .Append(DOVirtual.Float(restantFrom, restantTo, restantDuration, (float value) => _loadingBar.fillAmount = value).SetEase(_ease2))
            .AppendCallback(() => LoaderCallback.Instance.CanLoadScene());
    }
}
