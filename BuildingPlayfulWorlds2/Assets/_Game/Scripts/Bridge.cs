using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject[] crystals;
    public GameObject winCrystal;
    public GameObject objectEnable;
    [SerializeField] private bool isBridge;

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
            objectEnable.SetActive(false);
        }
        else
        {
            objectEnable.SetActive(true);
        }
        
        Debug.Log("BRIDGE OPEN");
    }

    public void checkCrystals()
    {
        bool canDoorOpen = true;
        for (int i = 0; i < crystals.Length; i++)
        {
            canDoorOpen &= crystals[i].GetComponent<CrystalScript>().isOn;
        }
        if (canDoorOpen == true)
        {   
            Open();
        }
        
    }
}
