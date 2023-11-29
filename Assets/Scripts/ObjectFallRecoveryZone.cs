using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallRecoveryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.tag);
        if (other.CompareTag("Grabbable")) {
            SpawnGrabbable spawnGrabbable = other.transform.parent.GetComponent<SpawnGrabbable>();
            if (spawnGrabbable == null)
            {
                Debug.LogWarning("pas de spoawngrabbable");
                return;
            }
            Debug.LogWarning("Devrait respawn");
            spawnGrabbable.Respawn();
        }
    }
}
