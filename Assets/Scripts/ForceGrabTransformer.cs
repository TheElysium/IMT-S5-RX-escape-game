using UnityEngine;
using Oculus.Interaction;

/// <summary>
/// A Transformer that moves the target with a 'Star Wars Force' feeling.
/// </summary>
public class ForceGrabTransformer : MonoBehaviour, ITransformer
{
    public float smoothRotationDelay = 5.0f;
    public float smoothPositionDelay = 0.25f;
    public bool isForceGrabbed = false;

    public Rigidbody grabbableRigidbody;

    private IGrabbable _grabbable;
    private Pose _grabDeltaInLocalSpace;
    private float elapsedTime = 0.0f;
    private Vector3 velocity = Vector3.zero;


    public void Initialize(IGrabbable grabbable)
    {
        _grabbable = grabbable;
    }

    public void BeginTransform()
    {
        Pose grabPoint = _grabbable.GrabPoints[0];
        Transform grabbableTransform = _grabbable.Transform;
        velocity = Vector3.zero;

        // From OculusIntegrationSDK.OneGrabFreeTransformer
        // Calculate offset (position and rotation) between hand and grabbable object
        _grabDeltaInLocalSpace = new Pose(
            grabbableTransform.InverseTransformVector(grabPoint.position - grabbableTransform.position),
            Quaternion.Inverse(grabPoint.rotation) * grabbableTransform.rotation
        );

        // Stop the rigidbody
        grabbableRigidbody.velocity = velocity;
        grabbableRigidbody.useGravity = false;
    }

    public void UpdateTransform()
    {
        // Add delay to movement
        if (elapsedTime < smoothPositionDelay)
        {
            elapsedTime += Time.deltaTime;
            return;
        }

        SmoothMovement(grabPoint: _grabbable.GrabPoints[0]);
    }

    private void SmoothMovement(Pose grabPoint)
    {
        if(isForceGrabbed)
        {
            grabbableRigidbody.Sleep();
            grabbableRigidbody.MoveRotation(Quaternion.Slerp(grabbableRigidbody.rotation, grabPoint.rotation * _grabDeltaInLocalSpace.rotation, Time.deltaTime * smoothRotationDelay));
            // Position is smoothed, following a curve (non-linear)  https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
            grabbableRigidbody.MovePosition(Vector3.SmoothDamp(grabbableRigidbody.position, grabPoint.position - grabbableRigidbody.transform.TransformVector(_grabDeltaInLocalSpace.position), ref velocity, smoothPositionDelay));
        }
        else
        {
            grabbableRigidbody.MoveRotation(grabPoint.rotation * _grabDeltaInLocalSpace.rotation);
            grabbableRigidbody.MovePosition(grabPoint.position - grabbableRigidbody.transform.TransformVector(_grabDeltaInLocalSpace.position));
        }
    }

    public void EndTransform()
    {
        grabbableRigidbody.useGravity = true;
        //Ensure continuous smooth movement
/*        grabbableRigidbody.velocity += velocity;
*/    }

    public void GrabbedByForce()
    {
        isForceGrabbed = true;
    }

    public void GrabbedByOther()
    {
        isForceGrabbed = false;
    }
}
