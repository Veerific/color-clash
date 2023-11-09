using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BossPhaseManager : MonoBehaviour
{
    public GameObject boss;
    private BossPhases phase;
    private bool phase2;
    private int dazeCounter;
    public BossState state;
    float halfHeight, halfWidth;
    int timesAttacked;
    private float idleTime = 2f;

    private void Start()
    {
        phase = boss.GetComponent<BossPhases>();
        //CameraView information
        Camera camera = Camera.main ?? throw new ArgumentNullException("Camera.main");
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;

    }
    private void Update()
    {
        UpdateState();
        if (!phase2)
        {
            Phase1();
        }
        else Phase2();
    }
    void UpdateState()
    {
        if (phase.shielded == false && state != BossState.Vulnerable && phase.counter < 2)
        {
            state = BossState.Dazed;
        }
        if (state == BossState.Vulnerable && phase.shielded
            || state == BossState.Vulnerable && phase.counter >= 2)
        {
            state = BossState.Attack;
            dazeCounter++;
        }
        if (phase.health <= 0)
        {
            state = BossState.Death;
        }
        if (state == BossState.Idle)
        {
            idleTime -= Time.deltaTime;
            if (idleTime <= 0)
            {
                idleTime = 2f;
                if (timesAttacked >= 2)
                {
                    state = BossState.Teleport;
                    timesAttacked = 0;
                }
                else if (phase2)
                {
                    state = BossState.Attack2;
                }
                else state = BossState.Attack;
            }
        }

    }
    void Phase1()
    {
        switch (state)
        {
            case BossState.Attack:

                phase.Attack();
                state = BossState.Idle;
                timesAttacked++;
                break;
            case BossState.Teleport:

                Vector2 spawnPos = new(UnityEngine.Random.Range(-halfWidth, halfWidth) / 2,
                    UnityEngine.Random.Range(-halfHeight, halfHeight) / 2);
                phase.Teleport(spawnPos);
                state = BossState.Idle;
                break;
            case BossState.Dazed:

                state = BossState.Vulnerable;
                dazeCounter++;
                StartCoroutine(phase.Dazed());
                if (dazeCounter >= 2) phase2 = true;
                print(dazeCounter);
                print(phase2);
                break;
        }
    }

    void Phase2()
    {
        switch (state)
        {
            case BossState.Attack:

                phase.Attack();
                state = BossState.Idle;
                timesAttacked++;
                break;
            case BossState.Attack2:

                phase.Attack2();
                state = BossState.Idle;
                timesAttacked++;
                break;
            case BossState.Teleport:

                Vector2 spawnPos = new(UnityEngine.Random.Range(-halfWidth, halfWidth) / 2,
                    UnityEngine.Random.Range(-halfHeight, halfHeight) / 2);
                phase.Teleport(spawnPos);
                state = BossState.Idle;
                break;
            case BossState.Dazed:

                state = BossState.Vulnerable;
                StartCoroutine(phase.Dazed());
                break;
            case BossState.Death:

                phase.Death();
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet b = collision.GetComponent<Bullet>();

      
            phase.GetsHit(CompareWeakness(b.element));
            b.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Explosion"))
        {
            phase.GetsHit(5f);
        }
        //scuffed solution oops
        if (collision.CompareTag("Steam"))
        {
            inHotSteam = true;
        }
    }

    float CompareWeakness(Element _Element)
    {
        //Calculates damage based on effectiveness chart
        switch (phase.currentElement)
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

public enum BossState
{
    Idle,
    Attack,
    Attack2,
    Teleport,
    Switch,
    Dazed,
    Vulnerable,
    Death
}
