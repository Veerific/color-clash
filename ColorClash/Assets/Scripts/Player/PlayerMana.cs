using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int waterMana;
    public int earthMana;
    public int fireMana;
    public bool explo, steam, tree;
    //This feels really disgusting
    public UIManager manager;
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
        CheckSpellReadiness(fireMana, earthMana, waterMana);
    }

    public void DecreaseMana(Spell spell)
    {
        switch (spell)
        {
            case Spell.Tree:   
                waterMana -= 10; 
                earthMana -= 10; 
                break;
            case Spell.Explosion:
                earthMana -= 10; 
                fireMana -= 10;
                break;
            case Spell.Steam:
                fireMana -= 10; 
                waterMana -= 10;
                break;
        }
        CheckSpellReadiness(fireMana, earthMana, waterMana);
    }
    private void CheckSpellReadiness(int fire, int grass, int water)
    {
        if (fire >= 10 && grass >= 10) explo = true; else explo = false;
        if (grass >= 10 && water >= 10) tree = true; else tree = false;
        if (water >= 10 && fire >= 10) steam = true; else steam = false;

        manager.UpdateImages(explo, steam, tree);
    }
}

public enum Spell
{
    Tree,
    Explosion,
    Steam
}



