using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeaponsPlayer : MonoBehaviour
{

    [SerializeField] public TakeWeapons takeWeapons;
    [SerializeField] public int numberWeapon;
    
    void Start()
    {
        takeWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<TakeWeapons>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            takeWeapons.ActiveWeapon(numberWeapon);
            Destroy(gameObject);
        }
    }
}
