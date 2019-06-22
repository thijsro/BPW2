using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [FMODUnity.EventRef] public string sound01;
    public GameObject PlayerCamera;
    public bool turnOff;
    FMOD.Studio.EventInstance playerState1;
    Rigidbody rb;
    bool turnedOn = false;

    private void Start()
    {
        playerState1 = FMODUnity.RuntimeManager.CreateInstance(sound01);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!turnOff)
        {
            if (!turnedOn)
            {
                playerState1.start();
                turnedOn = true;
            }
            
        }
        else
        {
            playerState1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
