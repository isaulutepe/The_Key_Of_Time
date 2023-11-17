using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{

    public List<GameObject> items = new List<GameObject>(); //Ýtem listesi alýnanlar buraya eklenecek.
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
            //Ýtemlar çocuk nesne olarak eklenecekler.
        }
    }
    private void Update()
    {
        if (takeItem && currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            takeItems();
        }
    }
    private void OnTriggerEnter(Collider other)//Ýtem alanýna girildiyse
    {
        // E butonu Görülecek. collider içine girince
        if (other.gameObject.CompareTag("item"))
        {
            Debug.Log("E ile al");
            other.transform.GetChild(0).gameObject.SetActive(true);
            takeItem = true;
            currentItem = other.gameObject; //Colldier alanýnda oldugumuz obje.
        }
    }
    void takeItems()
    {
        items.Add(currentItem);
        // Destroy(currentItem); //Toplanan nesneyi oyun alanýdan kaldýrdýk. Verimsiz.
        currentItem.SetActive(false);
        currentItem = null;
        takeItem = false;
    }

}
