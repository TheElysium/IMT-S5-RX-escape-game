using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class ForceGrabSoundManager : MonoBehaviour
{
    public AudioSource loopAudioSource;
    public DistanceHandGrabInteractor interactor;
    public AudioClip loopSound;
    public float easeDuration = 0.5f;
    public ForcePullManager forcePullManager;


    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float fadeStartTime;
    private float fadeStartVolume;
    private bool _isPulling = false;

    private void Start()
    {
        forcePullManager.OnForcePullStart += SetIsPulling;
        forcePullManager.OnForcePullEnd += SetIsPulling;
    }

    private void SetIsPulling()
    {
        _isPulling = !_isPulling;
    }
   
    void Update()
    {
        bool isGrabbing = interactor.IsGrabbing;

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

        loopAudioSource.clip = loopSound;
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
            float targetVolume = 1f;
            loopAudioSource.volume = Mathf.Lerp(0f, 1f, elapsedTime / easeDuration);

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
