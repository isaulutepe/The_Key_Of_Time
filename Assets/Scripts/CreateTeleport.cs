using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateTeleport : MonoBehaviour
{
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private float distance;
    [SerializeField] private float closeTime = 2f;
    bool activeTeleport = false; //Aktif teleport yok.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !activeTeleport) //Teleport Olu�tur. Ayn� anda bir tane.
        {
            createTeleport();
            activeTeleport = true; // Teleport aktif.
            StartCoroutine(CloseTeleport());
        }
    }
    IEnumerator CloseTeleport()
    {
        yield return new WaitForSeconds(closeTime);
        DestroyTeleport();
        activeTeleport = false;
    }
    void DestroyTeleport()
    {
        GameObject teleport = GameObject.FindGameObjectWithTag("teleport");
        if (teleport != null)
        {
            Destroy(teleport);
        }
    }
    void createTeleport() //Karakterin bakt���o y�nde nesneyi olu�tur.
    {
        Vector3 spawnPosition = transform.position + transform.forward * distance;
        Instantiate(teleportPrefab, spawnPosition, Quaternion.identity);
    }
}



