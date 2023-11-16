using Oculus.Interaction;
using UnityEngine;

public class ForcePullSoundManager : MonoBehaviour
{
    public AudioSource audioSourceRight;
    public ForcePullManager forcePullManagerRight;

    public AudioSource audioSourceLeft;
    public ForcePullManager forcePullManagerLeft;

    private void Start()
    {
        forcePullManagerRight.OnForcePullStart += audioSourceRight.Play;
        forcePullManagerLeft.OnForcePullStart += audioSourceLeft.Play;
    }
}