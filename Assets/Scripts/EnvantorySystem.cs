using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvantorySystem : MonoBehaviour
{
    public GameObject inventoryPanel; // Envanter panelini referans olarak ekleyin
    public TakeItem takeItemScript; // TakeItem scriptini referans olarak ekleyin

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // T tu�una bas�ld���nda
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf); // Envanter panelini a�/kapat
            UpdateInventoryDisplay();
        }
    }

    void UpdateInventoryDisplay()
    {
        // Envanterdeki t�m item'lar� temizle
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        // Envanterdeki t�m item'lar� listele
        foreach (GameObject item in takeItemScript.items)
        {
            // Her bir item i�in bir UI elementi olu�tur
            GameObject newItemDisplay = new GameObject("ItemDisplay");
            newItemDisplay.transform.SetParent(inventoryPanel.transform);

            // UI elementine bir Text componenti ekle
            Text itemText = newItemDisplay.AddComponent<Text>();
            itemText.text = item.name; // Item'�n ad�n� yazd�r

            // UI elementine bir Layout Element componenti ekle
            LayoutElement layoutElement = newItemDisplay.AddComponent<LayoutElement>();
            layoutElement.minHeight = 50; // Elementin y�ksekli�ini ayarla
 �������}
    }
}