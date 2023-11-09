using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI water, grass, fire, health;
    public Player player;
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
        health.text = player.health.ToString();
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

    public void UpdateImages(bool e, bool s, bool t)
    {
        if(e) explosion.color = new(1, 1, 1, 1); else explosion.color = new(1, 1, 1, .3f);
        if (s) steam.color = new(1, 1, 1, 1); else steam.color = new(1, 1, 1, .3f);
        if (t) {
            Debug.Log("Water" + mana.waterMana);
            Debug.Log("Eart" + mana.earthMana);
            tree.color = new(1, 1, 1, 1); 
        }
        else tree.color = new(1, 1, 1, .3f);
    }
}
