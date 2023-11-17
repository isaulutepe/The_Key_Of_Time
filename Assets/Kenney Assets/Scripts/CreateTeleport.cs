using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTeleport : MonoBehaviour
{

    private Rigidbody rg;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float closeTime = 2f;
    bool activeTeleport = false; //Aktif teleport yok.

    private void Awake()
    {
        distance = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z + 1);
        rg = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !activeTeleport) //Teleport Oluþtur. Ayný anda bir tane.
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
    void createTeleport()
    {
        Instantiate(teleportPrefab, rg.transform.position - distance, Quaternion.identity);
    }
}



