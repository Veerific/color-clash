using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public EnemyPool pool;
    float _halfHeight, _halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        //CameraView information
        Camera camera = Camera.main ?? throw new ArgumentNullException("Camera.main");
        _halfHeight = camera.orthographicSize;
        _halfWidth = camera.aspect * _halfHeight;
        InvokeRepeating("Level1", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Level1()
    {
        Vector2 spawnPos = new(_halfWidth, _halfHeight);
        pool.SpawnEnemy(spawnPos, Element.Fire);
        //3 waves of single type enemies
    }
    void Level2()
    {
        //3 waves of multi type enemies
    }
    void Level3()
    {
        //5 waves of multi type enemies
    }
    void Boss(GameObject obj)
    {
        //obj.spawn or something
    }
}
