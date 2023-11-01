using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    public Material hoverOutlineMaterial;
    public Material selectOutlineMaterial;

    private MeshRenderer meshRenderer;
    private Material objectMaterial;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        objectMaterial = meshRenderer.material;
    }
    public void OnHover()
    {
        meshRenderer.materials = new Material[] { objectMaterial, hoverOutlineMaterial };
    }

    public void OnUnhover()
    {
        meshRenderer.materials = new Material[] { objectMaterial };
    }

    public void OnSelect()
    {
        meshRenderer.materials = new Material[] { objectMaterial, selectOutlineMaterial };
    }
    public void OnUnselect()
    {
        meshRenderer.materials = new Material[] { objectMaterial, hoverOutlineMaterial };
    }
}
