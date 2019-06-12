using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject[] crystals;
    public GameObject winCrystal;

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
        winCrystal.GetComponentInChildren<CrystalScript>().TurnOn();
        Debug.Log("BRIDGE OPEN");
    }

    public void checkCrystals()
    {
        foreach (GameObject crystal in crystals)
        {
            if (crystal.GetComponentInChildren<CrystalScript>().isOn == false)
            {
                return;
            }
        }
        Open();
    }
}
