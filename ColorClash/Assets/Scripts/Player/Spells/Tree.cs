using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Disappear", 5f);
    }
    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
