using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    public GameObject prefabObject; // Ate� edilecek nesne
    [SerializeField] private float bulletSpeed = 1000f;
    GameObject bullet = null;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Sol fare d��mesine t�klama an�nda �al��acak kod buraya gelir
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // E�er t�klanan nokta bir UI eleman�n�n �zerinde de�ilse, ate� fonksiyonunu �a��r
                attack();
            }
        }
    }
    void attack()
    {
        Vector3 spawnPosition = transform.position + transform.forward + new Vector3(0, 1, 0);
        // Nesnenin olu�turulaca�� konum
        Quaternion rotation = Quaternion.LookRotation(transform.forward); // Nesnenin d�n���

        bullet = Instantiate(prefabObject, spawnPosition, rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 forceDirection = new Vector3(transform.forward.x, 0, transform.forward.z); // Yatay bir kuvvet vekt�r� olu�tur
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
