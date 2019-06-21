using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [FMODUnity.EventRef] public string sound01;
    [FMODUnity.EventRef] public string sound02;
    public GameObject PlayerCamera;
    public bool turnOff;
    FMOD.Studio.EventInstance playerState1;
    FMOD.Studio.EventInstance playerState2;
    Rigidbody rb;

    private void Start()
    {
        playerState1 = FMODUnity.RuntimeManager.CreateInstance(sound01);    
        playerState2 = FMODUnity.RuntimeManager.CreateInstance(sound02);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!turnOff)
        {
            playerState1.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(PlayerCamera));
            playerState2.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(PlayerCamera));
        }
        else
        {
            playerState1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            playerState2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }


    }
}
