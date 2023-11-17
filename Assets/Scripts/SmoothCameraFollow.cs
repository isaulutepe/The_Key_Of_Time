using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform bile�enine referans
    public Vector3 offset; // Kamera ile oyuncu aras�ndaki mesafe
    public float smoothSpeed = 0.125f; // Takip h�z�
    private Vector3 velocity = Vector3.zero; // H�z referans�

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
