
using UnityEngine;

public class Damage : MonoBehaviour
{

    private float health = 100f;
    private float hit = 20f;
    private GameManager manager;
    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    bool isDamage = false; //Hasar al�yor mu kontrol� i�in.

    private void Update()
    {
        if (isDamage) //Hasar al�yor.
        {
            DownHealth();
            Debug.Log("Can Durumu : " + health);
        }
        if (health <= 0)
        {
            manager.isDead = true; //�ld�
        }
    }
    private void OnTriggerEnter(Collider other) //D��man collider i�inde.
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            isDamage = true;
        }
    }
    private void OnTriggerExit(Collider other) //D��man colldier i�inden ��kt�.
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            isDamage = false;
        }
    }

    void DownHealth() //Can� azalt
    {
        if (health > 0)
        {
            health = health - hit;
            //Bar de�eri azalt�lacak
        }
    }
}
