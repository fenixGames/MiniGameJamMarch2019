﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDummy : MonoBehaviour
{
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weapon.Attack();
    }
}
