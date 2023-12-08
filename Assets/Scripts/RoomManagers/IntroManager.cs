using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying) return;

        EndScene();
    }

    void EndScene()
    {
        FadeToBlack();
        SceneManager.LoadScene("EscapeRooms", LoadSceneMode.Single);
    }

    // (Not a reference to Metallica)
    void FadeToBlack()
    {
    }
}
