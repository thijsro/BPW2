using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 10.0f;
    bool doInput = false;
    [SerializeField] float startDelay = 10f;
    [SerializeField] float fadeInTime = 3f;

    [FMODUnity.EventRef] public string VoiceOver1;

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(VoiceOver1, this.transform.position);
        StartCoroutine(startGame());
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

    IEnumerator startGame(duration)
    {
        float counter = 0f;

        while (counter < fadeInTime)
        {
            counter += Time.deltaTime;

            Light.intensity = Mathf.Lerp(startIntensity, newIntensity, counter / fadeInTime);

        }
        doInput = true;
        yield return new WaitForSeconds(10);
    }
}
