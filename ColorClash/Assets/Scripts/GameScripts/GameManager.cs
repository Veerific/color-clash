using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ob1, ob2;
    public void SwitchToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Win()
    {
        SceneManager.LoadScene(3);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    public void ToggleInstructions1()
    {
        ob1.SetActive(true);
    }
    public void ToggleIns2()
    {
        ob1.SetActive(false);
    }
    public void ToggleCredits()
    {
        ob2.SetActive(true);
    }
    public void ToggleCreds2()
    {
        ob2.SetActive(false);
    }
}
