using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public delegate void CardReaderHandler();
    public event CardReaderHandler OnCardRead;

    public Material okMaterial;
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.tag);
        if (!other.CompareTag("Card"))  return;

        OnCardRead?.Invoke();
        GetComponent<MeshRenderer>().material = okMaterial;
    }
}
