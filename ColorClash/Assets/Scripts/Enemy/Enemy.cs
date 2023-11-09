using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Element element;
    public GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 dir;
    bool inHotSteam;
    float timer;

    private void Start()
    {
        timer = .5f;
    }

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

    private void Update()
    {
        if (inHotSteam)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {            
                Damage(1);
                timer = .5f;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet b = collision.GetComponent<Bullet>();
            
            b.gameObject.SetActive(false);
            Damage(CompareWeakness(b.element));
        }
        if (collision.CompareTag("Explosion"))
        {
            Death();
        }
        //scuffed solution oops
        if (collision.CompareTag("Steam"))
        {
            inHotSteam = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Steam"))
        {
            inHotSteam = false;
        }
    }

    void Damage(float damage)
    {
        StartCoroutine(DamageAnim());
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    IEnumerator DamageAnim()
    {
        Color original = spriteRenderer.color;
        spriteRenderer.color = Color.yellow;

        yield return new WaitForSeconds(.1f);

        spriteRenderer.color = original;
    }

    void Death()
    {
        target.GetComponent<PlayerMana>().UpdateMana(element);
        gameObject.SetActive(false);
    }

    float CompareWeakness(Element _Element)
    {
        //Calculates damage based on effectiveness chart
        switch (element)
        {
            case Element.Water:
                if (_Element == Element.Earth) return 2;
                if (_Element == Element.Fire) return .5f;
                break;
            case Element.Fire:
                if (_Element == Element.Water) return 2;
                if (_Element == Element.Earth) return .5f;
                break;
            case Element.Earth:
                if (_Element == Element.Fire) return 2;
                if (_Element == Element.Water) return .5f;
                break;
        }
        return 1;
    }
}
