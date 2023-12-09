using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOneManager : MonoBehaviour
{
    public LeverTriggerHandler leverTriggerHandler;
    public DistanceHandGrabInteractable doorLeft;
    public DistanceHandGrabInteractable doorRight;
    public Animator fadeInAnimator;
    // Start is called before the first frame update
    void Start()
    {
        doorLeft.enabled = false;
        doorRight.enabled = false;
        fadeInAnimator.SetTrigger("TrFadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        if (leverTriggerHandler.isLeverDown)
        {
            doorLeft.enabled = true;
            doorRight.enabled = true;
        }
    }
}
