using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    

    List<GameObject> items; //�tem listesi al�nanlar buraya eklenecek.
    GameObject[] itemsObject;
    private bool takeItem = false;

    private void Awake()
    {
        itemsObject = GameObject.FindGameObjectsWithTag("item");
    }

    private void Update()
    {
        if (takeItem)
        {
            takeItems();
        }
    }
    private void OnTriggerEnter(Collider other)//�tem alan�na girildiyse
    {
        if (other.gameObject.CompareTag("item"))
        {
            takeItem= true;
        }
    }
    void takeItems()
    {
        
    }

}
