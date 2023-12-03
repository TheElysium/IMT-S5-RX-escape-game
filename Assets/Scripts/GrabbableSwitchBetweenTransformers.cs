using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableSwitchBetweenTransformers : MonoBehaviour
{
    public Grabbable grabbable;
    public OneGrabFreeTransformer defaultTransformer;
    public ForceGrabTransformer forceGrabTransformer;

    public void SwitchToDefaultTransformer()
    {
        grabbable.InjectOptionalOneGrabTransformer(defaultTransformer);
    }

    public void SwitchToForceGrabTransformer()
    {
        grabbable.InjectOptionalOneGrabTransformer(forceGrabTransformer);
    }
}
