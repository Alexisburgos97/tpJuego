using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   
    public GameObject player;
    private float distanceToPlayer;
    public int numberOfDoor;
    
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < 3)
        {
            openToDoor();
        }
    }

    void openToDoor()
    {
        if (numberOfDoor == 1)
        {
            if (player.transform.GetComponent<Inventory>().key_1)
            {
                Destroy(this.gameObject);
            }
        }
        
        if (numberOfDoor == 2)
        {
            if (player.transform.GetComponent<Inventory>().key_2)
            {
                Destroy(this.gameObject);
            }
        }
        
        if (numberOfDoor == 3)
        {
            if (player.transform.GetComponent<Inventory>().key_3)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
