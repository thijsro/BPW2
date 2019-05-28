using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust;
    GameObject lightSource;
    private Light mainLight;

    [SerializeField] float mainIntensity = 2000f;
    [SerializeField] float metalIntensity = 5000f;
    [SerializeField] float stoneIntensity = 3000f;
    [SerializeField] float woodIntensity = 4000f;
    [SerializeField] float fadeSpeedIn = 50f;
    [SerializeField] float fadeSpeedOut = 5f;
    [SerializeField] float newIntensity;
    [SerializeField] float currentIntensity;

    [SerializeField] float durationIn = 1f;
    [SerializeField] float durationOut = 5f;

    private bool isMetal = false;
    private bool isWood = false;
    private bool isStone = false;
    private bool isFadeOut = false;
    private bool gameStart = true;

    //TODO Add metal sound
    //TODO Add wood sound
    //TODO Add stone sound

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        lightSource = GetComponentInChildren<Light>().gameObject;
        mainLight = lightSource.GetComponent<Light>();
        mainLight.intensity = mainIntensity;
        currentIntensity = mainIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentIntensity);
        currentIntensity = mainLight.intensity;
    }

    public void OnPickup(GameObject newParent)
    {
        rb.isKinematic = true;
        GetComponent<Collider>().enabled = false;
        transform.parent = newParent.transform;
        transform.position = newParent.transform.position;
        lightSource.GetComponent<Light>().intensity = mainIntensity;
    }

    public void OnRelease()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
        //TODO wait for seconds
        GetComponent<Collider>().enabled = true;


    }

    public void AddForce()
    {
        rb.AddForce(GameObject.FindGameObjectWithTag("MainCamera").transform.forward * thrust);
        Debug.Log("gooi bal");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Metal")
        {
            isMetal = true;
            StartCoroutine(fadeIn(mainLight, isMetal, isWood, isStone, durationIn));
            //TODO Add sound
            
        }
        else if (collision.gameObject.tag == "Wood")
        {
            isWood = true;
            StartCoroutine(fadeIn(mainLight, isMetal, isWood, isStone, durationIn));
            //TODO Add sound
        }
        else if (collision.gameObject.tag == "Stone")
        {
            isStone = true;
            StartCoroutine(fadeIn(mainLight, isMetal, isWood, isStone, durationIn));
            //TODO Add sound
        }
        else
        {
            isMetal = false;
            isStone = false;
            isWood = false;
            isFadeOut = true;
            StartCoroutine(fadeOut(mainLight, isFadeOut, durationOut));
        }

    }

    IEnumerator fadeIn(Light mainLight, bool isMetal, bool isWood, bool isStone, float duration)
    {
        float counter = 0f;
        float a, b;

        if (isMetal) { newIntensity = metalIntensity; }
        else if (isWood) { newIntensity = woodIntensity; }
        else if (isStone) { newIntensity = stoneIntensity; }
        else { newIntensity = mainIntensity; }

        if (isMetal || isWood || isStone)
        {
            a = mainIntensity;
            b = newIntensity;
        }
        else
        {
            a = newIntensity;
            b = mainIntensity;
        }

        //float currentIntensity = mainLight.intensity;

        while (counter < durationIn)
        {
            counter += Time.deltaTime;

            mainLight.intensity = Mathf.Lerp(a, b, counter / durationIn);

            yield return null;
        }

    }

    IEnumerator fadeOut(Light mainLight, bool isFadeOut, float duration)
    {
        float counter = 0f;
        float a, b;
        //float startIntensity = 20;

        currentIntensity = mainLight.intensity;
        newIntensity = mainIntensity;

        if (isFadeOut)
        {
            a = currentIntensity;
            b = newIntensity;
        }
        else
        {
            a = currentIntensity;
            b = newIntensity;
        }

        //float currentIntensity = mainLight.intensity;

        while (counter < durationOut)
        {
            counter += Time.deltaTime;

            mainLight.intensity = Mathf.Lerp(a, b, counter / durationOut);

            yield return null;
        }
        yield return null;
    }
}
