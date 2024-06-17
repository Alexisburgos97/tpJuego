using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    public float quantityCure;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<CodHealth>())
        {
            bool response = other.GetComponent<CodHealth>().recibeCure(quantityCure);

            if (response)
            {
                Destroy(gameObject);
            }
        }
    }
}
