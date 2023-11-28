using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThreeManager : MonoBehaviour
{
    public PlanetariumManager planetariumManager;
    public Animator doorAnimation;

    void Start()
    {
        planetariumManager.OnAllPlanetsSnappedEvent += HandlePlanetariumCompleted;
    }


    private void HandlePlanetariumCompleted()
    {
        doorAnimation.SetTrigger("TrDoorOpen");
    }
}
