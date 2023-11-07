using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Element element;
    public GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private int health;

    private void FixedUpdate()
    {
        Vector2 dir = (target.transform.position - transform.position).normalized;
        transform.position += new Vector3(dir.x, dir.y, 0) * speed;

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
        if (health <= 0) gameObject.SetActive(false);
    }

    int CompareWeakness(Element _Element)
    {
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
}
