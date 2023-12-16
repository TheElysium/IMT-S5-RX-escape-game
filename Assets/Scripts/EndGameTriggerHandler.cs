using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTriggerHandler : MonoBehaviour
{

    public delegate void EnteredEndGameTriggerEvent();
    public event EnteredEndGameTriggerEvent OnEnteredEndGameTriggerEvent;

    private bool isEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player") && !isEntered)
        {
            isEntered = true;
            OnEnteredEndGameTriggerEvent?.Invoke();
        }
    }
}
