using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidController : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isStarted = false;

    private WaypointMover waypointMover;
    private Animator animator;

    public delegate void DroidStart();
    public event DroidStart OnDroidStart;

    public delegate void MovementEnded();
    public event MovementEnded OnMovementEnded;


    [Range(0f, 5f)]
    public float movementDelay = 1f;

    private void Start()
    {
        waypointMover = GetComponent<WaypointMover>();
        waypointMover.OnMovementEnded += HandleMovementEnded;
        animator = GetComponent<Animator>();
    }
    public void StartDroid()
    {
        if (isStarted) return;
        audioSource.Play();
        animator.SetTrigger("TrIdle");
        isStarted = true;
        OnDroidStart?.Invoke();
        Invoke("StartMovement", movementDelay);
    }

    private void StartMovement()
    {
        waypointMover.enabled = true;
    }

    private void HandleMovementEnded()
    {
        animator.SetTrigger("TrOpenArm");
    }

    private void HandleDroidHandAnimationEnded()
    {
        OnMovementEnded?.Invoke();
    }

    public void HandleUnlockEnded()
    {
        animator.SetTrigger("TrCloseArm");
    }
}
