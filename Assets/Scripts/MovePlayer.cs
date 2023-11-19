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
    public Camera mainCamera;
    private AudioSource audioSource;
    [SerializeField] private AudioSource Jumpaudio;
    [SerializeField] private AudioSource walkpaudio;

    public Teleportation teleportation; //Destination de�i�tirmek i�in.
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
            Jumpaudio.Play();
            Debug.Log("Z�plan�yor.");
            rg.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump = false;
        }
        if (jump == false)
        {
            animator.SetBool("isJumping", false);
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
            animator.SetBool("isJumping", true);
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
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = mainCamera.transform.TransformDirection(moveDirection);
        moveDirection.y = 0; // Y eksenindeki hareketi s�f�rla

        rg.MovePosition(rg.position + moveDirection * speed * Time.deltaTime);

        if (moveDirection != Vector3.zero) // hareket varsa
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection); // karakteri hareket y�n�ne d�nd�r
            rotation.x = 0; // X ekseni etraf�nda d�n��� s�f�rla
            rotation.z = 0; // Z ekseni etraf�nda d�n��� s�f�rla
            transform.rotation = rotation;
            walkpaudio.Play();
            isMove = true;
        }
        if (moveDirection == Vector3.zero)
        {
            isMove = false;
        }
    }
}
