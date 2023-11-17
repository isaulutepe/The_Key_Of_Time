using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{


    [SerializeField] private float speed = 2f;
    private Rigidbody rg;
    [SerializeField] private float jumpForce = 5f;
    private Vector3 movement;
    private bool jump = false;
    private bool isGround = true; //Karekter yerde.

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        rg.drag = 1; //Yerçekimini simile etmek için gerçekçi düþüþ vermek için.
    }
    private void FixedUpdate()
    {
        if (jump)
        {
            Debug.Log("Sýplanýyor.");
            rg.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump= false;
        }
    }
    private void Update()
    {
        movePlayer();
        if (Input.GetKey(KeyCode.Space) && isGround == true)
        {
            jump = true;
            isGround = false; //Karekter havada
        }
    }

    private void OnCollisionEnter(Collision collision) //Karakter yerde mi kontrolü.
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalInput, 0f, verticalInput);
        rg.MovePosition(rg.position + movement * speed * Time.deltaTime);
    }
}
