using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockController : MonoBehaviour
{
    private Animator animator;

    public delegate void DoorUnlocked();
    public event DoorUnlocked OnDoorUnlocked;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleAnimationEnd()
    {
        OnDoorUnlocked?.Invoke();
    }

    public void startAnimation()
    {
        animator.SetTrigger("TrUnlockDoor");
    }
}
