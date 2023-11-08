using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI water, grass, fire;
    public PlayerMana mana;
    public Sprite waterSprite, grassSprite, fireSprite;

    public Image explosion, tree, steam, icon;

    private void Start()
    {
        explosion.color = new(1, 1, 1, .3f);
        tree.color = new(1, 1, 1, .3f);
        steam.color = new(1, 1, 1, .3f);
    }

    // Update is called once per frame
    void Update()
    {
        water.text = mana.waterMana.ToString();
        grass.text = mana.earthMana.ToString();
        fire.text = mana.fireMana.ToString();
        UpdateImages();
    }

    public void UpdateIcon(Element element)
    {
        switch (element)
        {
            case Element.Earth:
                icon.sprite = grassSprite;
                break;
            case Element.Water: 
                icon.sprite = waterSprite;
                break;
            case Element.Fire:
                icon.sprite = fireSprite;
                break;
        }
    }

    //It would probably useful to instead of update this every frame, to call whenever its needed in a different script
    void UpdateImages()
    {
        //Fire Grass Mana
        if (mana.fireMana >= 10 && mana.earthMana >= 10)
        {
            explosion.color = new(1, 1, 1, 1);
        }
        //Fire Water Mana
        if (mana.fireMana >= 10 && mana.waterMana >= 10)
        {
            steam.color = new(1, 1, 1, 1);
        }
        //Water Grass Mana
        if (mana.waterMana >= 10 && mana.earthMana >= 10)
        {
            tree.color = new(1, 1, 1, 1);
        }
        
        if (mana.didExplosion)
        {
            mana.didExplosion = false;
            explosion.color = new(1, 1, 1, .3f);
        }
        if (mana.didSteam)
        {
            mana.didSteam = false;
            steam.color = new(1, 1, 1, .3f);
        }

        if (mana.didTree) {
            mana.didTree = false;
            tree.color = new(1, 1, 1, .3f);
        }
    }
}
