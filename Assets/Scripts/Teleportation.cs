using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    GameObject player;
    [SerializeField] private Vector3 destinationPos;
    float dissolveAmount = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destinationPos = new Vector3(2, 2, 2);
    }

    private void Update()
    {
        Debug.Log(player);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ýþýnlanma baþladý");
            player.GetComponent<MovePlayer>().enabled = false;
            teleportation();
        }
    }
    void teleportation()
    {
        player.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", false);
        StartCoroutine(DissolveMaterial()); //Shader çaðýr
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
            dissolveAmount += Time.deltaTime * 0.5f; // Bu deðeri ayarlayarak çözülme hýzýný kontrol edebilirsiniz.
            player.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.SetFloat("_DissolveAmount", dissolveAmount);
            yield return null;
        }
    }
    IEnumerator AppearMaterial()
    {
        while (dissolveAmount > 0)
        {
            dissolveAmount = 0;// Bu deðeri ayarlayarak görünme hýzýný kontrol edebilirsiniz.
            player.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.SetFloat("_DissolveAmount", dissolveAmount);
            yield return null;
        }
    }
    IEnumerator waitTeleport()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AppearMaterial());
        player.GetComponent<MovePlayer>().enabled = true;

    }


}
