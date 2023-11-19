using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateTeleport : MonoBehaviour
{
    [SerializeField] private List<GameObject> teleportPrefabs;
    [SerializeField] private float distance;
    [SerializeField] private float closeTime = 2f;
    bool activeTeleport = false; //Aktif teleport yok.
    bool a = true;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !activeTeleport) //Teleport Oluþtur. Ayný anda bir tane.
        {
            if (a)
            {
                createTeleport();
                activeTeleport = true; // Teleport aktif.
                StartCoroutine(CloseTeleport());
            }
            else
            {
                createTeleport2();
                activeTeleport = true; // Teleport aktif.
                StartCoroutine(CloseTeleport());
            } 
        }
    }
    IEnumerator CloseTeleport()
    {
        yield return new WaitForSeconds(closeTime);
        DestroyTeleport();
        activeTeleport = false;
        a = !a;

    }
    void DestroyTeleport()
    {
        GameObject teleport = GameObject.FindGameObjectWithTag("teleport");
        if (teleport != null)
        {
            Destroy(teleport);
        }
    }
    void createTeleport() //Karakterin baktýðýo yönde nesneyi oluþtur.
    {
        Vector3 spawnPosition = transform.position + transform.forward * distance;
        Instantiate(teleportPrefabs[0], spawnPosition, Quaternion.identity);
    }
    void createTeleport2() //Karakterin baktýðýo yönde nesneyi oluþtur.
    {
        Vector3 spawnPosition = transform.position + transform.forward * distance;
        Instantiate(teleportPrefabs[1], spawnPosition, Quaternion.identity);
    }
}



