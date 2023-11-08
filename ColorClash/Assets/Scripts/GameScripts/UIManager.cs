using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI water, grass, fire;
    public PlayerMana mana;

    public Image explosion, tree, steam;

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
