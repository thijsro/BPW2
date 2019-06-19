using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public Material newMaterial;
    public Light pointLight;
    public Bridge bridge;
    public bool isOn = false;
    private bool isTurnedOn = false;
    [SerializeField] private GameObject lightCheckerCollider;

    [FMODUnity.EventRef] public string crystalHit;

    // Start is called before the first frame update
    void Start()
    {
        if(lightCheckerCollider.activeSelf == true)
        {
            lightCheckerCollider.SetActive(false);
        }
        

        //pointLight = GetComponentInChildren<Light>();
    }

    public void TurnOn(int crystalNumber)
    {
        if (!isTurnedOn)
        {
            if (crystalNumber == 1)
            {
                pointLight.gameObject.SetActive(true);
                this.GetComponent<MeshRenderer>().material = newMaterial;
                FMODUnity.RuntimeManager.PlayOneShot(crystalHit, this.gameObject.transform.position);
                lightCheckerCollider.SetActive(true);
                isTurnedOn = true;
            }
            else
            {
                pointLight.gameObject.SetActive(true);
                this.GetComponent<MeshRenderer>().material = newMaterial;
                FMODUnity.RuntimeManager.PlayOneShot(crystalHit, this.gameObject.transform.position);
                lightCheckerCollider.SetActive(true);
                isOn = true;
                isTurnedOn = true;
                bridge.checkCrystals();

            }
        }
    }

}
