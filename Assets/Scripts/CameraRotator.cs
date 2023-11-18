using UnityEngine;
public class CameraRotator : MonoBehaviour
{
    public Transform target; // Hedef obje
    public Camera mainCamera; // Ana kamera
    public float mouseRotateSpeed = 0.8f; // Fare hareketinin kamera dönüþüne duyarlýlýðý
    public float distance = 5f; // Kamera ile hedef arasýndaki mesafe
    public float minDistance = 1f; // Kamera ile hedef arasýndaki minimum mesafe

    private float rotX; // X ekseni etrafýnda dönüþ
    private float rotY; // Y ekseni etrafýnda dönüþ

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotX += -Input.GetAxis("Mouse Y") * mouseRotateSpeed; // X ekseni etrafýnda dönüþ
            rotY += Input.GetAxis("Mouse X") * mouseRotateSpeed; // Y ekseni etrafýnda dönüþ
        }
    }

    private void LateUpdate()
    {
        Quaternion newQ = Quaternion.Euler(rotX, rotY, 0); // Yeni dönüþ deðerleri
        Vector3 newPosition = target.position + newQ * Vector3.back * distance; // Kameranýn yeni pozisyonu

        // Çarpýþma kontrolü
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
        mainCamera.transform.LookAt(target.position); // Kameranýn hedefe bakmasý
    }
}

