using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject[] crystals;
    public GameObject winCrystal;
    public GameObject objectEnable;

    // Start is called before the first frame update
    void Start()
    {
        objectEnable. SetActive(true);
        foreach (GameObject crystal in crystals)
        {
            crystal.GetComponentInChildren<CrystalScript>().bridge = this;
        }
    }

    public void Open()
    {
        winCrystal.GetComponentInChildren<CrystalScript>().TurnOn();
        objectEnable.SetActive(false);
        Debug.Log("BRIDGE OPEN");
    }

    public void checkCrystals()
    {
        for (int i = 0; i < crystals.Length; i++)
        {
            if (crystals[i].GetComponentInChildren<CrystalScript>().isOn == false)
            {
                
            }
            else
            {
                Open();
            }
        }
        
    }
}
