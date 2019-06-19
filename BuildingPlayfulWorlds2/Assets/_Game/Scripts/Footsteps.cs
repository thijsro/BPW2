using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef] public string inputSound;
    bool playerIsMoving;
    public float walkSpeed;

    private void Start()
    {
        InvokeRepeating("PlayFootsteps", 0, walkSpeed);
    }

    private void Update()
    {
        if(Input.GetAxis ("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            playerIsMoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            
            playerIsMoving = false;
        }

    }

    void PlayFootsteps()
    {
        if (playerIsMoving)
        {
            
            FMODUnity.RuntimeManager.PlayOneShot(inputSound, this.gameObject.transform.position);
        }
    }

    private void OnDisable()
    {
        playerIsMoving = false;
    }

}
