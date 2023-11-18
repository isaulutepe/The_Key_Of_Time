using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isDead = false;

    private void Update()
    {
        if (isDead)
        {
            //Oyunu bitir ve gameOver ekranýný yükle.
            Debug.Log("Öldün");
        }
    }
}
