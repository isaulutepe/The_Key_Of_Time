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
        if (Input.GetKeyDown(KeyCode.T)) // T tuþuna basýldýðýnda
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf); // Envanter panelini aç/kapat
            UpdateInventoryDisplay();
        }
    }

    void UpdateInventoryDisplay()
    {
        // Envanterdeki tüm item'larý temizle
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        // Envanterdeki tüm item'larý listele
        foreach (GameObject item in takeItemScript.items)
        {
            // Her bir item için bir UI elementi oluþtur
            GameObject newItemDisplay = new GameObject("ItemDisplay");
            newItemDisplay.transform.SetParent(inventoryPanel.transform);

            // UI elementine bir Text componenti ekle
            Text itemText = newItemDisplay.AddComponent<Text>();
            itemText.text = item.name; // Item'ýn adýný yazdýr

            // UI elementine bir Layout Element componenti ekle
            LayoutElement layoutElement = newItemDisplay.AddComponent<LayoutElement>();
            layoutElement.minHeight = 50; // Elementin yüksekliðini ayarla
        }
    }
}