
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

    bool isDamage = false; //Hasar alýyor mu kontrolü için.

    private void Update()
    {
        if (isDamage) //Hasar alýyor.
        {
            DownHealth();
            Debug.Log("Can Durumu : " + health);
        }
        if (health <= 0)
        {
            manager.isDead = true; //Öldü
        }
    }
    private void OnTriggerEnter(Collider other) //Düþman collider içinde.
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            isDamage = true;
        }
    }
    private void OnTriggerExit(Collider other) //Düþman colldier içinden çýktý.
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            isDamage = false;
        }
    }

    void DownHealth() //Caný azalt
    {
        if (health > 0)
        {
            health = health - hit;
            //Bar deðeri azaltýlacak
        }
    }
}
