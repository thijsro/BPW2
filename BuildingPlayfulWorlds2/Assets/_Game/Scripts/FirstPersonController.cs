using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5f;
    public float originalSpeed = 5f;
    public float newSpeed = 10f;
    public bool doInput = false;
    public Image planeIm;
    public bool isRunning;

    [SerializeField] float startDelay = 10f;
    [SerializeField] float staminaSpeed = 0.1f;
    [SerializeField] private float maxStamina = 100f;


    private float lerpTime;
    private float currentStamina = 100f;
    private float minStamina = 0.0f;
    private bool staminaEmpty = false;
    private bool staminaFull = true;
    private bool canRun = true;

    //FMOD
    [FMODUnity.EventRef] public string VoiceOver1;
    [FMODUnity.EventRef] public string AmbientSound;

    bool isFading;
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(VoiceOver1, this.transform.position);
        FMODUnity.RuntimeManager.PlayOneShot(AmbientSound, this.transform.position);
        StartCoroutine(startGame(startDelay, planeIm));
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (doInput)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, 0, translation);

            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {

                if(currentStamina > minStamina)
                {
                    currentStamina -= staminaSpeed;
                    speed = newSpeed;
                    isRunning = true;
                }
                else if(currentStamina == minStamina)
                {
                    isRunning = false;
                    speed = originalSpeed;

                }
                if (currentStamina < minStamina)
                {
                    currentStamina = minStamina;
                }
                
            }
            else 
            {
                if(currentStamina <= maxStamina)
                {
                currentStamina += staminaSpeed;
                speed = originalSpeed;
                isRunning = false;
                }
                if (currentStamina > maxStamina)
                {
                    currentStamina = maxStamina;
                }
            }
            //Debug.Log(currentStamina);
        }
    }

    IEnumerator startGame(float duration, Image image)
    {
        yield return new WaitForSeconds(duration);
        doInput = true;
    }

}
