using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Invantory : MonoBehaviour
{
    public GameObject inventoryPanel;
    private List<GameObject> inventoryPanelList = new List<GameObject>();

    private TakeItem item;
    public int counter = 0;

    private bool isInventoryOpen = false;

    private void Awake()
    {
        item = GetComponent<TakeItem>();
        for (int i = 0; i < 6; i++)
        {
            inventoryPanelList.Add(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isInventoryOpen)
            {
                CloseInventory();
                isInventoryOpen = false;
            }
            else
            {
                OpenInventory();
                isInventoryOpen = true;
            }
        }
    }
    public void AddItem()
    {

        GameObject inventorySlot = inventoryPanelList[counter]; //0.Paneli alýr
        Image inventoryImage = inventorySlot.transform.GetChild(0).GetComponent<Image>(); // Panelin çocuk nesnesi olan Image bileþenini alýn
        Image itemImage = item.currentItem.GetComponent<Image>();

        inventoryImage.sprite = itemImage.sprite;
        counter++;

    }
    void OpenInventory()
    {
        inventoryPanel.SetActive(true);
    }
    void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }


}
