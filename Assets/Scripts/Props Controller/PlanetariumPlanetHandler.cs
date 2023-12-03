using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetariumPlanetHandler : MonoBehaviour
{
    public SnapInteractor snapInteractor;
    public SnapInteractable snapInteractable;
    private int id;

    public void SetId(int id)
    {
        this.id = id;
    }

    public delegate void SelectSnapPlanetEvent(int id);
    public event SelectSnapPlanetEvent OnSelectSnapPlanetEvent;

    public delegate void UnselectSnapPlanetEvent(int id);
    public event UnselectSnapPlanetEvent OnUnselectSnapPlanetEvent;

    public void OnSelectSnapPlanet()
    {
        if(snapInteractor.Interactable == snapInteractable)
        {
            Debug.LogWarning("Good planet !");
            OnSelectSnapPlanetEvent?.Invoke(id);
        }
    }

    public void OnUnselectSnapPlanet()
    {
        OnUnselectSnapPlanetEvent?.Invoke(id);
    }
}