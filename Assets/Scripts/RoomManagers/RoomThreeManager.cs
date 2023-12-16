using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomThreeManager : MonoBehaviour
{
    public PlanetariumManager planetariumManager;
    public Animator doorAnimation;
    public EndGameTriggerHandler endGameTriggerHandler;
    public Animator fadeCanva;
    public FadeHandler fadeHandler;

    void Start()
    {
        planetariumManager.OnAllPlanetsSnappedEvent += HandlePlanetariumCompleted;
        endGameTriggerHandler.OnEnteredEndGameTriggerEvent += HandleEndGameTriggerEntered;
        fadeHandler.OnFadeFinishedEvent += HandleFadeOutFinished;
    }


    private void HandlePlanetariumCompleted()
    {
        doorAnimation.SetTrigger("TrDoorOpen");
    }

    private void HandleEndGameTriggerEntered()
    {
        fadeCanva.SetTrigger("TrFadeOut");
    }

    private void HandleFadeOutFinished()
    {
        Debug.LogWarning("gkjosdfg");
        SceneManager.LoadScene("End", LoadSceneMode.Single);
    }
}
