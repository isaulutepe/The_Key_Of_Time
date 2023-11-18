using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform bile�enine referans
    public Vector3 offset; // Kamera ile oyuncu aras�ndaki mesafe
    public float smoothSpeed = 0.125f; // Takip h�z�
    private Vector3 velocity = Vector3.zero; // H�z referans�

    private void Start()
    {
        transform.Rotate(8.91f, 0, 0);
        offset= new Vector3(0, 2.26f, -3.98f);
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        // �arp��may� kontrol et
        RaycastHit hit;
        if (Physics.Linecast(player.position, smoothedPosition, out hit))
        {
            // E�er bir �arp��ma varsa, kameray� �arp��ma noktas�na ta��
            smoothedPosition = hit.point;
        }

        transform.position = smoothedPosition;
    }


}

