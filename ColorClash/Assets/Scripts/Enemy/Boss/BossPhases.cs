using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class BossPhases : MonoBehaviour
{
    public bool shielded;
    public float shieldHealth;
    public float health;
    public Element currentElement;
    public EnemyBulletPool pool;
    public GameObject player;
    private int circleSize = 10;
    public Animator animator;
    public int counter;
    public bool dazed;
    public SpriteRenderer spriteRenderer;
    public bool inHotSteam;
    private float timer;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        currentElement = Element.Earth;
        player = GameObject.Find("Player");
        shielded = true;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (inHotSteam)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GetsHit(1);
                timer = .5f;
            }
        }
    }

    public void Attack()
    {
        pool.ShootBullet(player.transform.position, transform.position, currentElement);
    }

    public void Attack2()
    {
        Vector2 dir;
        for (int i = 0; i < circleSize; i++)
        {
            dir = Direction(i, circleSize);
            pool.ShootBullet(dir, transform.position, currentElement);
        }
    }

    public Vector2 Direction(int index, int totalSize)
    {
        float radians = (2 * Mathf.PI) / totalSize * index;
        float vertical = Mathf.Sin(radians);
        float horizontal = Mathf.Cos(radians);
        Vector2 dir = new(horizontal, vertical);

        return dir.normalized;
    }

    public void GetsHit(float damage)
    {
        if (shielded)
        {
            damage = 1;
            shieldHealth -= damage;
            if (shieldHealth <= 0) shielded = false;
        }
        else health -= damage;
        StartCoroutine(DamageAnim());
    }
    IEnumerator DamageAnim()
    {
        Color original = spriteRenderer.color;
        spriteRenderer.color = Color.yellow;

        yield return new WaitForSeconds(.1f);

        spriteRenderer.color = original;
    }

    public void Teleport(Vector2 pos)
    {
        //add animation of some sort, particle system
        transform.position = pos;
        spriteRenderer.flipX = transform.position.x > 0 ? true : false;
        SwitchColor();
    }
    public void SwitchColor()
    {
        Element newElement = (Element)UnityEngine.Random.Range(0, 2);
        if (newElement == currentElement) SwitchColor();
        else
        {
            currentElement = newElement;
            switch (currentElement)
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
    }

    public IEnumerator Dazed()
    {
        animator.SetBool("dazed", true);
        shielded = false;

        yield return new WaitForSeconds(2f);

        animator.SetBool("dazed", false);
        StartCoroutine(Recover());
    }
    public IEnumerator Recover()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        counter++;
        shielded = counter < 2 ? true : false;
        shieldHealth = 2;
    }
    public void Death()
    {
        animator.SetBool("Dead", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        manager.Win();
    }
}

