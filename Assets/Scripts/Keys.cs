using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{

    public GameObject player;
    private float distanceToPlayer;
    public int numberOfKey;
    
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < 1.5f)
        {
            pickUpKey();
        }
    }

    void pickUpKey()
    {
        if (numberOfKey == 1)
        {
            player.GetComponent<Inventory>().key_1 = true;
        }
        
        if (numberOfKey == 2)
        {
            player.GetComponent<Inventory>().key_2 = true;
        }
        
        if (numberOfKey == 3)
        {
            player.GetComponent<Inventory>().key_3 = true;
        }
        
        Destroy(this.gameObject);
    }
    
}
