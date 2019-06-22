using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject[] crystals;
    public GameObject winCrystal;
    public GameObject objectEnable;
    [SerializeField] private bool isBridge = false;

    [FMODUnity.EventRef] public string deathBallSound;
    

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (GameObject crystal in crystals)
        {
            crystal.GetComponentInChildren<CrystalScript>().bridge = this;
        }
    }

    public void Open()
    {
        winCrystal.GetComponent<CrystalScript>().TurnOn(1);
        if (isBridge == false)
        {
            Debug.Log("play anim");
            objectEnable.GetComponent<animController>().PlayAnim();
            FMODUnity.RuntimeManager.PlayOneShot(deathBallSound);
        }
        else
        {
            objectEnable.SetActive(true);
            objectEnable.GetComponent<animController>().PlayAnim();
        }
        
    }

    public void checkCrystals()
    {
        bool canDoorOpen = true;
        for (int i = 0; i < crystals.Length; i++)
        {
            Debug.Log("isOn");
            canDoorOpen &= crystals[i].GetComponent<CrystalScript>().isOn;
        }
        if (canDoorOpen == true)
        {
            Debug.Log("Turn on");
            Open();
        }
        
    }
}
