using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public bool isDead = false;
    public GameObject gameOverVideoPanel;
    public VideoPlayer video;
    bool isActiveVideo = false;

    private void Start()
    {
        video = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if (isDead && isActiveVideo == false)
        {
            //Oyunu bitir ve gameOver ekranýný yükle.
            Debug.Log("Öldün");
            Dead();
        }
    }
    void Dead()
    {
        gameOverVideoPanel.SetActive(true);
        video.Play();
        isActiveVideo= true;
        Time.timeScale = 0.0f;
        //Healt bar ve pouse kan-pancak

    }
}
