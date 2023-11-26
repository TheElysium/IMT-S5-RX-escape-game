using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidController : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isStarted = false;

    public delegate void DroidStart();
    public event DroidStart OnDroidStart;

    public WaypointMover waypointMover;
    private Animator animator;

    public delegate void MovementEnded();
    public event MovementEnded OnMovementEnded;

    [Range(0f, 5f)]
    public float movementDelay = 1f;

    private void Start()
    {
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
        Invoke("startMovement", movementDelay);
    }

    private void startMovement()
    {
        Debug.LogWarning("startmvmt");
        waypointMover.enabled = true;
    }

    private void HandleMovementEnded()
    {
        animator.SetTrigger("TrOpenArm");

    }
}
