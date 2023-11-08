using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int waterMana;
    public int earthMana;
    public int fireMana;

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

    public void DecreaseMana(Element element)
    {
        switch (element)
        {
            case Element.Water:
                waterMana -= 10; break;
            case Element.Earth:
                earthMana -= 10; break;
            case Element.Fire:
                fireMana -= 10; break;
        }
    }
}
