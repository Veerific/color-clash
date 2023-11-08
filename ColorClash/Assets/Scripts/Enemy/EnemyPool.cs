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

    public void SpawnEnemy(Vector2 spawnPos, Element element)
    {
        Enemy e = enemies[currentEnemy].GetComponent<Enemy>();
        e.element = element;
        e.transform.position = new(spawnPos.x, spawnPos.y, 0f);
        e.target = player;
        e.gameObject.SetActive(true);
        currentEnemy = currentEnemy == poolSize - 1 ? 0 : currentEnemy += 1;
    }

}
