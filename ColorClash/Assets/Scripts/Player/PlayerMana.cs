using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int waterMana;
    public int earthMana;
    public int fireMana;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMana(Element enemy)
    {
        switch(enemy) {
            case Element.Water:
                waterMana++;
                break;
            case Element.Earth:
                earthMana++; 
                break;
            case Element.Fire:
                fireMana++; 
                break;    
        }
    }
}
