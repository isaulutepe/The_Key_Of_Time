using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation2 : MonoBehaviour
{

    GameObject player;
    [SerializeField] public Vector3 destinationPos;
    float dissolveAmount = 0;
    public GameObject spawnPointA;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destinationPos = spawnPointA.transform.position;   //A ya d�n gidecek.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teleportation();
        }
    }
    void teleportation()
    {
        player.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", false);
        StartCoroutine(DissolveMaterial()); //Shader �a��r
        StartCoroutine(goTeleport()); //Bekle ve isinla
        StartCoroutine(waitTeleport()); //Telepor kapat.
    }
    IEnumerator goTeleport()
    {
        yield return new WaitForSeconds(0.5f);
        player.transform.position = destinationPos;
    }
    IEnumerator DissolveMaterial()
    {
        while (dissolveAmount < 1)
        {
            dissolveAmount += Time.deltaTime * 0.5f; // Bu de�eri ayarlayarak ��z�lme h�z�n� kontrol edebilirsiniz.
            player.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.SetFloat("_DissolveAmount", dissolveAmount);
            yield return null;
        }
    }
    IEnumerator AppearMaterial()
    {

        while (dissolveAmount > 0)
        {
            dissolveAmount = 0;// Bu de�eri ayarlayarak g�r�nme h�z�n� kontrol edebilirsiniz.
            player.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.SetFloat("_DissolveAmount", dissolveAmount);
            yield return null;
        }
    }
    IEnumerator waitTeleport()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AppearMaterial());
    }
}

