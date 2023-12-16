using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptStateHandler : MonoBehaviour
{
    public delegate void PromptCloseToEndEvent();
    public event PromptCloseToEndEvent OnPromptCloseToEndEvent;
    public void PromptCloseToEnd()
    {
        OnPromptCloseToEndEvent?.Invoke();
    }
}
