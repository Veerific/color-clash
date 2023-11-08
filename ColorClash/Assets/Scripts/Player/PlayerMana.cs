using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int waterMana;
    public int earthMana;
    public int fireMana;
    public bool didExplosion, didSteam, didTree;
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

    public void DecreaseMana(Spell spell)
    {
        switch (spell)
        {
            case Spell.Tree:
                didTree = true;
                waterMana -= 10; 
                earthMana -= 10; 
                break;
            case Spell.Explosion:
                didExplosion = true;
                earthMana -= 10; 
                fireMana -= 10;
                break;
            case Spell.Steam:
                didSteam = true;
                fireMana -= 10; 
                waterMana -= 10;
                break;
        }
    }
}

public enum Spell
{
    Tree,
    Explosion,
    Steam
}
