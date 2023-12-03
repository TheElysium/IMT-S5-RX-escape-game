using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTwoManager : MonoBehaviour
{
    public CardReader cardReader;
    public GameObject smallDoor;
    public DroidController droidController;
    public DoorLockController doorLockController;
    public Animator doorAnimator;

    private bool isDroidStarted = false;

    private bool isSmallDoorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        cardReader.OnCardRead += HandleCardRead;
        droidController.OnDroidStart += HandleDroidStart;
        droidController.OnMovementEnded += HandleDroidMovementEnded;
        doorLockController.OnDoorUnlocked += HandleDoorUnlocked;
    }

    private void HandleCardRead()
    {
        if (isSmallDoorOpened) return;
        isSmallDoorOpened = true;
        Animator smallDoorAnimation = smallDoor.GetComponent<Animator>();
        smallDoorAnimation.enabled = true;
        smallDoorAnimation.Play("glass_door_open");
    }

    private void HandleDroidStart()
    {
        isDroidStarted = true;
    }

    private void HandleDroidMovementEnded()
    {
        doorLockController.startAnimation();
    }

    private void HandleDoorUnlocked()
    {
        droidController.HandleUnlockEnded();
        doorAnimator.SetTrigger("TrDoorOpen");
    }
}
