using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public Material newMaterial;
    public Light pointLight;

    // Start is called before the first frame update
    void Start()
    {
        //pointLight = GetComponentInChildren<Light>();
        if (pointLight.GetComponent<Light>().isActiveAndEnabled == true)
        {
            pointLight.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TurnOn()
    {
        pointLight.gameObject.SetActive(true);
        this.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
