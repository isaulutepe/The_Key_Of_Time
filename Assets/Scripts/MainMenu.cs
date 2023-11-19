using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(2);

    }

    public void CreditScene()
    {
        creditPanel.SetActive(true);

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Debug.Log("Oyundan cýkýs yapildi");
        Application.Quit();
    }
}
