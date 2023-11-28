using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetariumManager : MonoBehaviour
{
    public PlanetariumPlanetHandler[] planetariumPlanetHandlers;
    private int snappedPlanetsCount;

    public delegate void AllPlanetsSnappedEvent();
    public event AllPlanetsSnappedEvent OnAllPlanetsSnappedEvent;

    private void Start()
    {
        foreach(PlanetariumPlanetHandler handler in planetariumPlanetHandlers)
        {
            handler.OnSelectSnapPlanetEvent += () => { snappedPlanetsCount++; };
            handler.OnUnselectSnapPlanetEvent += () => { snappedPlanetsCount--; };
        }
    }

    private void Update()
    {
        if(planetariumPlanetHandlers.Length == snappedPlanetsCount)
        {
            OnAllPlanetsSnappedEvent?.Invoke();
        }
    }
}
