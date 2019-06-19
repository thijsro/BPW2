using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject newRespawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<DeathManager>().respawnPosition = newRespawnPosition;
            Debug.Log(newRespawnPosition);  
        }

    }
}
