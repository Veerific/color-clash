using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Forgive my non use of inheritance I have no more brain power
public class EnemyBulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private GameObject[] bullets;
    [SerializeField] private int poolSize;
    private int currentBullet;
    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        bullets = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            bullets[i] = Instantiate(bullet);
            bullets[i].transform.parent = transform;
            bullets[i].SetActive(false);

        }
        currentBullet = 0;
    }

    public void ShootBullet(Vector3 dir, Vector3 spawnPos, Element element)
    {
        Bullet b = bullets[currentBullet].GetComponent<Bullet>();
        b.element = element;
        b.gameObject.SetActive(true);
        b.gameObject.transform.position = spawnPos;
        Vector3 movement = dir;
        b.SetDirection(movement.normalized);
        currentBullet = currentBullet == poolSize - 1 ? 0 : currentBullet += 1;
    }
    public void CleanPool()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetActive(false);
        }
    }
}
