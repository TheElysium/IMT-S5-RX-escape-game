using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Animator fadeOutAnimator;

    [SerializeField]
    private PromptStateHandler promptStateHandler;

    [SerializeField]
    private FadeHandler fadeHandler;

    private void Start()
    {
        promptStateHandler.OnPromptCloseToEndEvent += FadeToBlack;
        fadeHandler.OnFadeFinishedEvent += ChangeScene;
    }

    // (Not a reference to Metallica)
    private void FadeToBlack()
    {
        fadeOutAnimator.SetTrigger("TrFadeOut");
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("EscapeRooms", LoadSceneMode.Single);
    }
}
