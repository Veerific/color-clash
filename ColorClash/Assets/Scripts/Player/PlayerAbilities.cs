using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject explosion, steam, tree;
    public GameObject[] explosions, steamClouds, trees;
    private int currentE, currentS, currentT;
    public PlayerMana mana;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        //Initializing Spell Objects
        for (int i = 0; i < 3; i++)
        {
            explosions[i] = Instantiate(explosion);
            steamClouds[i] = Instantiate(steam);
            trees[i] = Instantiate(tree);

            explosions[i].SetActive(false);
            steamClouds[i].SetActive(false);
            trees[i].SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Fire Grass Mana
        if (Input.GetKeyDown(KeyCode.Alpha1) && mana.explo)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ExplosionSpell(mousePos);
        }
        //Fire Water Mana
        if (Input.GetKeyDown(KeyCode.Alpha2) && mana.steam)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SteamSpell(mousePos);
        }
        //Water Grass Mana
        if (Input.GetKeyDown(KeyCode.Alpha3) && mana.tree)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TreeSpell(mousePos);
        }
    }

    void SteamSpell(Vector2 pos)
    {
        GameObject obj = steamClouds[currentS];
        obj.SetActive(true);
        obj.transform.position = pos;
        currentS = currentS < 2 ? currentS += 1 : 0;
        mana.DecreaseMana(Spell.Steam);
    }
    void TreeSpell(Vector2 pos)
    {
        GameObject obj = trees[currentT];
        obj.SetActive(true);
        obj.transform.position = pos;
        currentT = currentT < 2 ? currentT += 1 : 0;
        mana.DecreaseMana(Spell.Tree);
    }
    void ExplosionSpell(Vector2 pos)
    {
        GameObject obj = explosions[currentE];
        obj.SetActive(true);
        obj.transform.position = pos;
        currentE = currentE < 2 ? currentE += 1 : 0;
        mana.DecreaseMana(Spell.Explosion);
    }
}
