using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public Material newMaterial;
    public Light pointLight;
    public Bridge bridge;
    public bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        //pointLight = GetComponentInChildren<Light>();
        if (pointLight.GetComponent<Light>().isActiveAndEnabled == true)
        {
            pointLight.gameObject.SetActive(false);
        }
    }

    public void TurnOn()
    {
        pointLight.gameObject.SetActive(true);
        this.GetComponent<MeshRenderer>().material = newMaterial;
        isOn = true;
        bridge.checkCrystals();
        
    }

}
