using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTwoManager : MonoBehaviour
{
    public CardReader cardReader;
    public GameObject smallDoor;

    private bool isSmallDoorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        cardReader.OnCardRead += HandleCardRead;
    }

    private void HandleCardRead()
    {
        if (isSmallDoorOpened) return;
        smallDoor.transform.Translate(new Vector3(0,10,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
