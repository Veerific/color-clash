using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Element element;
    public GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 dir;


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
        dir = (target.transform.position - transform.position).normalized;
        transform.position += new Vector3(dir.x, dir.y, 0) * speed;
        if(dir.x > 0)
        {
            spriteRenderer.flipX = false;
        } else spriteRenderer.flipX = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet b = collision.GetComponent<Bullet>();
            
            b.gameObject.SetActive(false);
            Damage(CompareWeakness(b.element));
        }
    }

    void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            target.GetComponent<PlayerMana>().UpdateMana(element);
            gameObject.SetActive(false);
        }
    }

    int CompareWeakness(Element _Element)
    {
        //Calculates damage based on effectiveness chart
        switch (element)
        {
            case Element.Water:
                if (_Element == Element.Earth) return 2;
                if (_Element == Element.Fire) return 0;
                break;
            case Element.Fire:
                if (_Element == Element.Water) return 2;
                if (_Element == Element.Earth) return 0;
                break;
            case Element.Earth:
                if (_Element == Element.Fire) return 2;
                if (_Element == Element.Water) return 0;
                break;
        }
        return 1;
    }

    public void PushAway()
    {

    }
}
