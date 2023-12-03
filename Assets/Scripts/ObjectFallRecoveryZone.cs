using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallRecoveryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable") || other.CompareTag("Card")) {
            SpawnGrabbable spawnGrabbable = other.transform.GetComponentInParent<SpawnGrabbable>();
            if (spawnGrabbable == null)
            {
                return;
            }
            spawnGrabbable.Respawn();
        }
    }
}
