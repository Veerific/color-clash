using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhases : MonoBehaviour
{
    bool shielded;
    Element currentElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Attack()
    {
        //Shoot a single elemental bullet, at random

    }
    
    void Attack2()
    {
        //Explode a circle of bullets from the enemy
    }
    void Idle()
    {
        //stand still for a few seconds
    }

    void Teleport()
    {
        //teleport to a new space
    }
    void SwitchColor()
    {
        //switch element
    }

    void Dazed()
    {
        //shield down, vulnerable and elemental resistances are up
    }
}

