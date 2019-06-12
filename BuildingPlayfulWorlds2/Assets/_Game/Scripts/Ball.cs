using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust;
    GameObject lightSource;
    private Light mainLight;
    private int ballKind; //1 = ballbounce 2 = ballstick

    [SerializeField] float mainIntensity = 2000f;
    [SerializeField] float metalIntensity = 5000f;
    [SerializeField] float stoneIntensity = 3000f;
    [SerializeField] float woodIntensity = 4000f;
    [SerializeField] float fadeSpeedIn = 50f;
    [SerializeField] float fadeSpeedOut = 5f;
    private float newIntensity;
    private float currentIntensity;

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
        if(this.gameObject.tag == "ballbounce") { ballKind = 1; }
        else if (this.gameObject.tag == "ballstick") { ballKind = 2; }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mainLight.intensity);

    }

    public void OnPickup(GameObject newParent)
    {
        if (rb.isKinematic == false)
        {
            rb.isKinematic = true;
        }
        GetComponent<Collider>().enabled = false;
        transform.parent = newParent.transform;
        transform.position = newParent.transform.position;
        if(ballKind == 2)
        {
            StartCoroutine(fadeIn(mainLight, mainIntensity, durationOut));
        }
    }

    public void OnRelease()
    {
        transform.SetParent(null);
        GetComponent<Collider>().enabled = true;
        rb.isKinematic = false;
        //TODO wait for seconds
        
    }

    public void AddForce()
    {
        rb.AddForce(GameObject.FindGameObjectWithTag("MainCamera").transform.forward * thrust);
    }

    public void OnTriggerEnter(Collider collision)
    {  
        if(ballKind == 1)
        {
            Debug.Log("collided with " + collision.name);
            StopAllCoroutines();
            if (collision.gameObject.tag == "Metal")
            {
                isMetal = true;
                StartCoroutine(fadeIn(mainLight, metalIntensity, durationIn));
                //TODO Add sound

            }
            else if (collision.gameObject.tag == "Wood")
            {
                isWood = true;
                StartCoroutine(fadeIn(mainLight, woodIntensity, durationIn));
                //TODO Add sound
            }
            else if (collision.gameObject.tag == "Stone")
            {
                isStone = true;
                StartCoroutine(fadeIn(mainLight, stoneIntensity, durationIn));
                //TODO Add sound
            }
            else if (collision.gameObject.tag == "Crystal")
            {
                StartCoroutine(fadeIn(mainLight, stoneIntensity, durationIn));
                collision.gameObject.GetComponent<CrystalScript>().TurnOn();
            }
            else
            {
                StartCoroutine(fadeIn(mainLight, mainIntensity, durationOut));
            }
        }
        else if(ballKind == 2)
        {
            if (collision.gameObject.tag == "Metal")
            {
                rb.isKinematic = true;
                isMetal = true;
                StartCoroutine(fadeIn(mainLight, metalIntensity, durationIn));
                //TODO Add sound

            }
            else if (collision.gameObject.tag == "Wood")
            {
                rb.isKinematic = true;
                isWood = true;
                StartCoroutine(fadeIn(mainLight, woodIntensity, durationIn));
                //TODO Add sound
            }
            else if (collision.gameObject.tag == "Stone")
            {
                rb.isKinematic = true;
                isStone = true;
                StartCoroutine(fadeIn(mainLight, stoneIntensity, durationIn));
                //TODO Add sound
            }
            else if (collision.gameObject.tag == "Crystal")
            {
                rb.isKinematic = true;
                StartCoroutine(fadeIn(mainLight, stoneIntensity, durationIn));
                
            }
        }

    }


    IEnumerator fadeIn(Light Light, float newIntensity, float duration)
    {
        float startIntensity = Light.intensity;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            Light.intensity = Mathf.Lerp(startIntensity, newIntensity, counter / duration);

            yield return null;
        }
    }    
}
