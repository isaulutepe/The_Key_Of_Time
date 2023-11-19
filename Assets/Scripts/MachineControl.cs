using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MachineControl : MonoBehaviour
{
    private Invantory keyCount;
    public GameObject text;
    private bool finished = false;
    private void Awake()
    {
        keyCount = GameObject.Find("Player").GetComponent<Invantory>();
    }
    private void Update()
    {
        if (keyCount != null)
        {
            if (keyCount.counter >= 6 && Input.GetKey(KeyCode.E))
            {
                finish();
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }

    void finish()
    {

        text.SetActive(false);
        Debug.Log("Bitti");
        SceneManager.LoadScene(3);

        //Oyunu bitir.

    }
}

