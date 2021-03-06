﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChecker : MonoBehaviour
{

    SphereCollider sphere;



    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == 11)
        {
            FindObjectOfType<DeathManager>().InLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (FindObjectOfType<ThrowManager>().CurrentBall == null)
        {
            Debug.Log("NOTINLIGHT");
            FindObjectOfType<DeathManager>().InLight = false;
        }
    }
}
