using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHandler : MonoBehaviour
{
    public delegate void FadeFinishedEvent();
    public event FadeFinishedEvent OnFadeFinishedEvent;

    public void OnFadeFinished()
    {
        OnFadeFinishedEvent?.Invoke();
    }
}
