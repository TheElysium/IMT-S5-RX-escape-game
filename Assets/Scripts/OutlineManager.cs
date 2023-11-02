using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    public Outline outline;

    public void Start()
    {
        outline.enabled = false;
    }

    public void OnHover()
    {
        outline.enabled = true;
        outline.OutlineColor = new Color(.55f, .63f, 1, 1);
    }

    public void OnUnhover()
    {
        outline.enabled = false;
    }

    public void OnSelect()
    {
        outline.OutlineColor = new Color(.184f, .391f, 1, 1);
    }
    public void OnUnselect()
    {
        outline.OutlineColor = new Color(.55f, .63f, 1, 1);
    }
}
