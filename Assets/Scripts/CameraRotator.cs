using UnityEngine;
public class CameraRotator : MonoBehaviour
{
    public Transform target; // Hedef obje
    public Camera mainCamera; // Ana kamera
    public float mouseRotateSpeed = 0.8f; // Fare hareketinin kamera d�n���ne duyarl�l���
    public float distance = 5f; // Kamera ile hedef aras�ndaki mesafe
    public float minDistance = 1f; // Kamera ile hedef aras�ndaki minimum mesafe

    private float rotX; // X ekseni etraf�nda d�n��
    private float rotY; // Y ekseni etraf�nda d�n��

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotX += -Input.GetAxis("Mouse Y") * mouseRotateSpeed; // X ekseni etraf�nda d�n��
            rotY += Input.GetAxis("Mouse X") * mouseRotateSpeed; // Y ekseni etraf�nda d�n��
        }
    }

    private void LateUpdate()
    {
        Quaternion newQ = Quaternion.Euler(rotX, rotY, 0); // Yeni d�n�� de�erleri
        Vector3 newPosition = target.position + newQ * Vector3.back * distance; // Kameran�n yeni pozisyonu

        // �arp��ma kontrol�
        RaycastHit hit;
        if (Physics.Linecast(target.position, newPosition, out hit))
        {
            newPosition = hit.point;
            float hitDistance = Vector3.Distance(target.position, newPosition);
            if (hitDistance < minDistance)
            {
                newPosition = target.position + (newPosition - target.position).normalized * minDistance;
            }
        }

        mainCamera.transform.position = newPosition;
        mainCamera.transform.LookAt(target.position); // Kameran�n hedefe bakmas�
    }
}

