using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    
    //Note to Self: decouple this system next time, might looks cleaner
    private Element Element;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Element = Element.Water;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            bulletPool.ShootBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, Element);
        }
        //Cycles through the available elements
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Element = Element == Element.Fire ? Element.Earth : Element-=1;
        }
        if (Input.GetKeyDown(KeyCode.E)){
            Element = Element == Element.Earth ? Element.Fire : Element+=1;
        }

        switch (Element)
        {
            case Element.Fire:
                spriteRenderer.color = Color.red; break;
            case Element.Earth: 
                spriteRenderer.color = Color.green; break;
            case Element.Water: 
                spriteRenderer.color = Color.blue; break;

        }
    }    
}

public enum Element
{
    Fire,
    Water,
    Earth
}
