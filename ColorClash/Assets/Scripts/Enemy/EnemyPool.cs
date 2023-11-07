using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private GameObject[] enemies;
    [SerializeField] private int poolSize;
    private int currentEnemy;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        enemies = new GameObject[poolSize];
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = Instantiate(enemy);
            enemies[i].transform.parent = transform;
            enemies[i].SetActive(false);
        }
    }

    //This could have parameters that determine the spawn of the enemy. 
    public void SpawnEnemy(Vector2 spawnPos)
    {
        GameObject e = enemies[currentEnemy];
        e.transform.position = new(spawnPos.x, spawnPos.y, 0f);
        e.GetComponent<Enemy>().target = player;
        e.SetActive(true);
        currentEnemy = currentEnemy == poolSize - 1 ? 0 : currentEnemy += 1;
    }

}
