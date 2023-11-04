using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction;

public class ForcePullManager : MonoBehaviour
{
    public DistanceHandGrabInteractor distanceHandGrabInteractor;

    public void ManageMovementProvider<T>() where T : MonoBehaviour, IMovementProvider
    {
        DistanceHandGrabInteractable interactable = distanceHandGrabInteractor.SelectedInteractable;
        if (interactable == null) return;

        T existingProvider = interactable.gameObject.GetComponent<T>();
        if (existingProvider == null)
        {
            interactable.InjectOptionalMovementProvider(interactable.gameObject.AddComponent<T>());
        }
        else
        {
            interactable.InjectOptionalMovementProvider(existingProvider);
        }
    }

    public void PullGrabbable()
    {
        ManageMovementProvider<ForcePullMovementProvider>();
        distanceHandGrabInteractor.Unselect();
        distanceHandGrabInteractor.Select();
    }

    public void ResetMovementProvider()
    {
        ManageMovementProvider<MoveFromTargetProvider>();
    }
}
