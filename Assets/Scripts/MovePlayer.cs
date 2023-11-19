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

    public Teleportation teleportation; //Destination deðiþtirmek için.
    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        rg.drag = 1; //Yerçekimini simile etmek için gerçekçi düþüþ vermek için.
    }
    private void FixedUpdate()
    {
        movePlayer();
        if (jump)
        {
            Jumpaudio.Play();
            Debug.Log("Zýplanýyor.");
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
        //Animasyonlarý kontrol etmek için.
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

    private void OnCollisionEnter(Collision collision) //Karakter yerde mi kontrolü.
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
        moveDirection.y = 0; // Y eksenindeki hareketi sýfýrla

        rg.MovePosition(rg.position + moveDirection * speed * Time.deltaTime);

        if (moveDirection != Vector3.zero) // hareket varsa
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection); // karakteri hareket yönüne döndür
            rotation.x = 0; // X ekseni etrafýnda dönüþü sýfýrla
            rotation.z = 0; // Z ekseni etrafýnda dönüþü sýfýrla
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
