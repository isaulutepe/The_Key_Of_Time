using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject prefabObject; // Ateþ edilecek nesne
    [SerializeField] private float bulletSpeed = 1000f;
    GameObject bullet = null;
    private void Update()
    {
        if (Input.GetMouseButton(0)) //sol týk ateþ edecek
        {
            attack();
        }
    }
    void attack()
    {
        Vector3 spawnPosition = transform.position + transform.forward + new Vector3(0, 1, 0);
        // Nesnenin oluþturulacaðý konum
        Quaternion rotation = Quaternion.LookRotation(transform.forward); // Nesnenin dönüþü

        bullet = Instantiate(prefabObject, spawnPosition, rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 forceDirection = new Vector3(transform.forward.x, 0, transform.forward.z); // Yatay bir kuvvet vektörü oluþtur
            rb.AddForce(forceDirection * bulletSpeed);
        }
        else
        {
            Debug.Log("Rigidbody yok");
        }
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (bullet != null)
        {
            Destroy(bullet, 0.5f);
        }
    }

}
