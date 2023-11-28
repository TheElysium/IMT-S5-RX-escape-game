using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThreeManager : MonoBehaviour
{
    public PlanetariumManager planetariumManager;

    void Start()
    {
        planetariumManager.OnAllPlanetsSnappedEvent += HandlePlanetariumCompleted;
    }


    private void HandlePlanetariumCompleted()
    {
        Debug.LogWarning("planetarium completed");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
