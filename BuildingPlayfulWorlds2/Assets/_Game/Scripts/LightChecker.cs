using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChecker : MonoBehaviour
{

    SphereCollider sphere;



    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == 11)
        {
            FindObjectOfType<DeathManager>().inLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DeathManager>().inLight = false;
    }
}
