using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetariumManager : MonoBehaviour
{
    public PlanetariumPlanetHandler[] planetariumPlanetHandlers;
    private Dictionary<int, bool> planetariumPlanetsDict;

    public delegate void AllPlanetsSnappedEvent();
    public event AllPlanetsSnappedEvent OnAllPlanetsSnappedEvent;

    private void Start()
    {
        planetariumPlanetsDict = new Dictionary<int, bool>();

        for (int i = 0; i < planetariumPlanetHandlers.Length; i++)
        {
            PlanetariumPlanetHandler handler = planetariumPlanetHandlers[i];
            handler.OnSelectSnapPlanetEvent += HandlePlanetSelect;
            handler.OnUnselectSnapPlanetEvent += HandlePlanetUnselect;
            handler.SetId(i);
            planetariumPlanetsDict[i] = false;
        }
    }

    private void HandlePlanetSelect(int id)
    {
        planetariumPlanetsDict[id] = true;
        CheckAllPlanetsSnapped();
    }

    private void HandlePlanetUnselect(int id)
    {
        planetariumPlanetsDict[id] = false;
    }

    private void CheckAllPlanetsSnapped()
    {
        if (planetariumPlanetsDict.Values.All(value => value))
        {
            OnAllPlanetsSnappedEvent?.Invoke();
        }
    }
}
