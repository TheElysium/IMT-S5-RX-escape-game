using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePullSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public ForcePullManager forcePullManager;

    private void Start()
    {
        if (forcePullManager)
        {
            forcePullManager.OnForcePullStart += audioSource.Play;
        }
    }
}
