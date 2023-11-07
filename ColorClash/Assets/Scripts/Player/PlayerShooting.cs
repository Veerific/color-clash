using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    private PlayerElement playerElement;
    // Start is called before the first frame update
    void Start()
    {
        playerElement = PlayerElement.Water;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletPool.ShootBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, playerElement);
        }
        //Cycles through the available elements
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerElement = playerElement == PlayerElement.Fire ? PlayerElement.Earth : playerElement-=1;
        }
        if (Input.GetKeyDown(KeyCode.E)){
            playerElement = playerElement == PlayerElement.Earth ? PlayerElement.Fire : playerElement+=1;
        }
        Debug.Log(playerElement.ToString());
    }

    
}

public enum PlayerElement
{
    Fire,
    Water,
    Earth
}
