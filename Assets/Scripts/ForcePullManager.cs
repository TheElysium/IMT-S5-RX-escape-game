using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction;

public class ForcePullManager : MonoBehaviour
{
    public DistanceHandGrabInteractor distanceHandGrabInteractor;

    public void PullGrabbable()
    {
        DistanceHandGrabInteractable interactable = distanceHandGrabInteractor.SelectedInteractable;
        if (interactable == null) return;

        interactable.InjectOptionalMovementProvider(interactable.gameObject.AddComponent<MoveTowardsTargetProvider>());
        distanceHandGrabInteractor.Unselect();
        distanceHandGrabInteractor.Select();
    }

    public void resetMovementProvider()
    {
        DistanceHandGrabInteractable interactable = distanceHandGrabInteractor.SelectedInteractable;
        if (interactable == null) return;

        interactable.InjectOptionalMovementProvider(interactable.gameObject.AddComponent<MoveFromTargetProvider>());
    }
}
