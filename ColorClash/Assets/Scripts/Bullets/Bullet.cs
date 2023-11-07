using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    public PlayerElement element;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        switch(element)
        {
            case PlayerElement.Fire:
                spriteRenderer.color = Color.red; 
                break;
            case PlayerElement.Earth: 
                spriteRenderer.color = Color.green; 
                break;
            case PlayerElement.Water: 
                spriteRenderer.color = Color.blue;
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(direction.x, direction.y, 0f) * speed;
    }



    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
