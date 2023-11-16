using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class ForceGrabSoundManager : MonoBehaviour
{
    public AudioSource loopAudioSource;
    public DistanceHandGrabInteractable interactable;
    public float easeDuration = 0.5f;
    public ActiveStateGroup forcePullActiveState;

    [Range(0.0f, 1.0f)]
    public float targetVolume = 1f;

    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float fadeStartTime;
    private float fadeStartVolume;
    private bool _isPulling = false;

    private void SetIsPulling(bool isPulling)
    {
        _isPulling = isPulling;
    }
   
    void Update()
    {
        SetIsPulling(forcePullActiveState.Active);
        bool isGrabbing = interactable.SelectingInteractors.Count != 0;

        if (isGrabbing && !_isPulling && !isFadingIn && !loopAudioSource.isPlaying)
        {
            StartFadeIn();
        }
        else if (!isGrabbing && !_isPulling && !isFadingOut && loopAudioSource.isPlaying)
        {
            StartFadeOut();
        }
    }


    void StartFadeIn()
    {
        Debug.LogWarning("Start fade in");
        isFadingIn = true;
        fadeStartTime = Time.time;
        fadeStartVolume = 0f;

        loopAudioSource.Play();
    }

    void StartFadeOut()
    {
        isFadingOut = true;
        fadeStartTime = Time.time;
        fadeStartVolume = loopAudioSource.volume;
    }

    void FixedUpdate()
    {
        if (isFadingIn)
        {
            float elapsedTime = Time.time - fadeStartTime;
            loopAudioSource.volume = Mathf.Lerp(0f, targetVolume, elapsedTime / easeDuration);

            if (elapsedTime > easeDuration)
            {
                loopAudioSource.volume = targetVolume;
                isFadingIn = false;
            }
        }

        if (isFadingOut)
        {
            float elapsedTime = Time.time - fadeStartTime;
            float targetVolume = 0f;
            loopAudioSource.volume = Mathf.Lerp(fadeStartVolume, 0f, elapsedTime / easeDuration);

            if (elapsedTime > easeDuration)
            {
                loopAudioSource.volume = targetVolume;
                isFadingOut = false;
                loopAudioSource.Stop();
            }
        }
    }
}
