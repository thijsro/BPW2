using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChecker : MonoBehaviour
{

    SphereCollider sphere;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<DeathManager>().inLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DeathManager>().inLight = false;
    }
}
