using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class TakeItem : MonoBehaviour
{

    public List<GameObject> items = new List<GameObject>(); //�tem listesi al�nanlar buraya eklenecek.
    public GameObject currentItem = null;
    private bool takeItem = false;
    private Invantory invantory;

    private void Awake()
    {
        invantory=GameObject.Find("Player").GetComponent<Invantory>();
    }
    private void Update()
    {
        if (takeItem && currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            takeItems();
        }
    }
    private void OnTriggerEnter(Collider other)//�tem alan�na girildiyse
    {
        // E butonu G�r�lecek. collider i�ine girince
        if (other.gameObject.CompareTag("item"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            takeItem = true;
            currentItem = other.gameObject; //Colldier alan�nda oldugumuz obje.
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void takeItems()
    {
        items.Add(currentItem);
        invantory.AddItem();
        currentItem.SetActive(false);
        currentItem = null;
        takeItem = false;
    }

}
