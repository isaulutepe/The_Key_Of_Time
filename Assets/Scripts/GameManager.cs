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
            //Oyunu bitir ve gameOver ekran�n� y�kle.
            Debug.Log("�ld�n");
        }
    }
}
