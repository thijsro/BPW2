using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 10.0f;
    public bool doInput = false;
    [SerializeField] float startDelay = 10f;
    public Image planeIm;

    [FMODUnity.EventRef] public string VoiceOver1;

    bool isFading;
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(VoiceOver1, this.transform.position);
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

        }

        

    }

    IEnumerator startGame(float duration, Image image)
    {
        
        yield return new WaitForSeconds(duration);
        doInput = true;
    }
}
