using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;


public class Levels : MonoBehaviour
{
    public EnemyPool pool;
    float halfHeight, halfWidth;
    public int state;
    private bool finished;
    void Start()
    {
        //CameraView information
        Camera camera = Camera.main ?? throw new ArgumentNullException("Camera.main");
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0)
        {
            StartCoroutine(Level1());
            state++;
        }
        if(state == 1 && finished)
        {
            finished = false;
            StartCoroutine(Level2());
            state++;
        }if(state == 2 && finished)
        {
            finished = false;
            StartCoroutine(Level3());
            state++;
        }
        if (state == 3 && finished)
        {
            finished = false;
            //boss()
            state++;
        }
    }

    IEnumerator Level1()
    {
        yield return new WaitForSeconds(5f);

        Vector2 spawnPos;
        //Top
        for(int i = 0; i < 5; i++)
        {
            spawnPos = new(UnityEngine.Random.Range(-halfWidth, halfWidth), halfHeight + 1);
            pool.SpawnEnemy(spawnPos, Element.Fire);
            yield return new WaitForSeconds(1f);
        }
        //Left
        for(int i = 0; i< 3; i++)
        {
            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, Element.Fire);
            yield return new WaitForSeconds(1f);
        }
        //Right
        for(int i = 0; i<3; i++)
        {
            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, Element.Fire);
            yield return new WaitForSeconds(1f);
        }
        //Down
        for(int i = 0; i < 5; i++)
        {
            spawnPos = new(UnityEngine.Random.Range(-halfWidth, halfWidth), -halfHeight - 1);
            pool.SpawnEnemy(spawnPos, Element.Fire);
            yield return new WaitForSeconds(1f);
        }
        finished = true;
    }
    IEnumerator Level2()
    {
        yield return new WaitForSeconds(6f);
        Element element = Element.Fire;
        Vector2 spawnPos;
        for(int i = 0; i< 3; i++)
        {
            spawnPos = new(UnityEngine.Random.Range(-halfWidth, halfWidth), halfHeight + 1);
            pool.SpawnEnemy(spawnPos, element);
            element++;
            yield return new WaitForSeconds(2.5f);
        }

        element = Element.Fire;

        for (int i = 0; i<6; i++)
        {
            if (element == (Element)3) element = 0;
            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(1f);

            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            element++;
            yield return new WaitForSeconds(1f);
        }

        element = Element.Fire;

        for (int i = 0; i < 6; i++)
        {
            if (element == (Element)3) element = 0;
            spawnPos = new(UnityEngine.Random.Range(-halfWidth, halfWidth), -halfHeight - 1);
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(1f);

            spawnPos = new(UnityEngine.Random.Range(-halfWidth, halfWidth), -halfHeight - 1);
            pool.SpawnEnemy(spawnPos, element);
            element++;
            yield return new WaitForSeconds(1f);
        }

        finished = true;
    }
    IEnumerator Level3()
    {
        Element element = Element.Fire;
        Vector2 spawnPos;
        yield return new WaitForSeconds(6f);

        for (int i = 0; i < 6; i++)
        {
            if (element == (Element)3) element = 0;
            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(1f);

            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(1f);

            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(1f);

            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            element++;
            yield return new WaitForSeconds(1f);
        }

        for (int i = 0; i < 6; i++)
        {
            if (element == (Element)3) element = 0;
            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(.5f);

            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(.5f);

            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(.5f);

            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            element++;
            yield return new WaitForSeconds(.5f);
        }

        for (int i = 0; i < 6; i++)
        {
            if (element == (Element)3) element = 0;
            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(.3f);

            spawnPos = new(-halfWidth - 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(.3f);

            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            yield return new WaitForSeconds(.3f);

            spawnPos = new(halfWidth + 1, UnityEngine.Random.Range(-halfHeight, halfHeight));
            pool.SpawnEnemy(spawnPos, element);
            element++;
            yield return new WaitForSeconds(.3f);
        }

        finished = true;
    }
    void Boss(GameObject obj)
    {
        //obj.spawn or something
    }
}


