using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapons : MonoBehaviour
{

    [SerializeField] public GameObject[] weapons;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ActiveWeapon(int number)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        
        weapons[number].SetActive(true);
    }
}
