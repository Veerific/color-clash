using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    public Element element;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        switch (element)
        {
            case Element.Fire:
                spriteRenderer.color = Color.red;
                break;
            case Element.Earth:
                spriteRenderer.color = Color.green;
                break;
            case Element.Water:
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
