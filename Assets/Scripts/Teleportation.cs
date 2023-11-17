using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    GameObject player;
    [SerializeField] private Vector3 destinationPos;

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
            teleportation();
        }
    }
    void teleportation()
    {
        player.transform.position = destinationPos;
    }


}
