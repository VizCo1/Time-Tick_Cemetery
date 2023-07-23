using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{

    [SerializeField] private Image _loadingBar;

    private void Start()
    {
        float from = 0f;
        float to = Random.Range(0.5f, 0.8f);
        float duration = Random.Range(0.5f, 1f);

        float restantFrom = to;
        float restantTo = 1f;
        float restantDuration = Random.Range(0.5f, 1f);

        Sequence loadingSequence = DOTween.Sequence();

        loadingSequence
            .Append(DOVirtual.Float(from, to, duration, (float value) => _loadingBar.fillAmount = value))
            .Append(DOVirtual.Float(restantFrom, restantTo, restantDuration, (float value) => _loadingBar.fillAmount = value))
            .AppendCallback(() => LoaderCallback.Instance.CanLoadScene());      
    }
}
