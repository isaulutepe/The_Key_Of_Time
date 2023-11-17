using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{

    public List<GameObject> items = new List<GameObject>(); //�tem listesi al�nanlar buraya eklenecek.
    public GameObject[] itemsObject;
    private GameObject currentItem = null;
    private bool takeItem = false;

    private void Awake()
    {
        itemsObject = GameObject.FindGameObjectsWithTag("item");
    }
    private void Start()
    {
        for (int i = 0; i < itemsObject.Length; i++)
        {
            //�temlar �ocuk nesne olarak eklenecekler.
        }
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
            Debug.Log("E ile al");
            other.transform.GetChild(0).gameObject.SetActive(true);
            takeItem = true;
            currentItem = other.gameObject; //Colldier alan�nda oldugumuz obje.
        }
    }
    void takeItems()
    {
        items.Add(currentItem);
        // Destroy(currentItem); //Toplanan nesneyi oyun alan�dan kald�rd�k. Verimsiz.
        currentItem.SetActive(false);
        currentItem = null;
        takeItem = false;
    }

}
