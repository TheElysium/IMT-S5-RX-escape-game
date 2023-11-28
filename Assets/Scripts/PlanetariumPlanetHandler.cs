using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetariumPlanetHandler : MonoBehaviour
{
    public SnapInteractor snapInteractor;
    public SnapInteractable snapInteractable;

    public delegate void SelectSnapPlanetEvent();
    public event SelectSnapPlanetEvent OnSelectSnapPlanetEvent;

    public delegate void UnselectSnapPlanetEvent();
    public event UnselectSnapPlanetEvent OnUnselectSnapPlanetEvent;

    public void OnSelectSnapPlanet()
    {
        if(snapInteractor.Interactable == snapInteractable)
        {
            Debug.LogWarning("Good planet !");
            OnSelectSnapPlanetEvent?.Invoke();
        }
    }

    public void OnUnselectSnapPlanet()
    {
        OnUnselectSnapPlanetEvent?.Invoke();
    }
}