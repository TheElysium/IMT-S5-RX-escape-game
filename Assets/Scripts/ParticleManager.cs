using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHover()
    {
        ParticleSystem.Play();
    }

    public void OnUnhover()
    {
        ParticleSystem.Stop();
    }

    public void OnSelect()
    {

    }
    public void OnUnselect()
    {

    }
}
