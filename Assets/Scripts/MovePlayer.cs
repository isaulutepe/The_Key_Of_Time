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
    public bool isMove = false;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
       
        rg.drag = 1; //Yer�ekimini simile etmek i�in ger�ek�i d���� vermek i�in.

    }
    private void FixedUpdate()
    {
        movePlayer();
        if (jump)
        {
            Debug.Log("Z�plan�yor.");
            rg.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump = false;
        }
    }
    private void Update()
    {
        //Animasyonlar� kontrol etmek i�in.
        if (isMove == false)
        {
            animator.SetBool("isMoving", false);
        }
        if (isMove == true)
        {
            animator.SetBool("isMoving", true);
        }

      
        if (Input.GetKey(KeyCode.Space) && isGround == true)
        {

            jump = true;
            isGround = false; //Karekter havada
        }
    }

    private void OnCollisionEnter(Collision collision) //Karakter yerde mi kontrol�.
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

        if (movement != Vector3.zero) // hareket varsa
        {
           // this.GetComponent<CapsuleCollider>().radius = 0.44f;
            transform.rotation = Quaternion.LookRotation(movement); // karakteri hareket y�n�ne d�nd�r
            isMove = true;
        }
        if (movement == Vector3.zero)
        {
            isMove = false;
        }

    }
}
