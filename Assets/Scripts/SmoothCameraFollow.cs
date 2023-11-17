using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform bileþenine referans
    public Vector3 offset; // Kamera ile oyuncu arasýndaki mesafe
    public float smoothSpeed = 0.125f; // Takip hýzý
    private Vector3 velocity = Vector3.zero; // Hýz referansý

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
