using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform bileþenine referans
    public Vector3 offset; // Kamera ile oyuncu arasýndaki mesafe
    public float smoothSpeed = 0.125f; // Takip hýzý
    private Vector3 velocity = Vector3.zero; // Hýz referansý

    private void Start()
    {
        transform.Rotate(8.91f, 0, 0);
        offset= new Vector3(0, 2.26f, -3.98f);
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        // Çarpýþmayý kontrol et
        RaycastHit hit;
        if (Physics.Linecast(player.position, smoothedPosition, out hit))
        {
            // Eðer bir çarpýþma varsa, kamerayý çarpýþma noktasýna taþý
            smoothedPosition = hit.point;
        }

        transform.position = smoothedPosition;
    }


}

