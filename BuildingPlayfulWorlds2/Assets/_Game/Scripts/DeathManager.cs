using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class DeathManager : MonoBehaviour
{
    private bool inLight = false;
    public bool InLight
    {
        get
        {
            return inLight;
        }
        set
        {
            if(value != inLight)
            {
                UpdateVignette(value);
            }
            inLight = value;
        }
    }

    public Volume volume;
    [SerializeField] private float VignetteIntensity = 0;
    [SerializeField] private float fadeInSpeed = 2f;
    [SerializeField] private float fadeOutSpeed = 2f;

    private float lerpTime;
    private Vignette vignette;
    private Coroutine deathRoutine;

    [SerializeField] private GameObject deathUI;
    public GameObject respawnPosition;


    private void Start()
    {
        vignette = (Vignette)volume.profile.components[5];
        VignetteIntensity = vignette.intensity.value;
    }

    private void UpdateVignette(bool isInlIght)
    {
        if(deathRoutine != null)
        {
            StopCoroutine(deathRoutine);
        }
        if (isInlIght)
        {
            deathRoutine = StartCoroutine(VignetteIn(0.3f, fadeOutSpeed));
        }
        else
        {
            deathRoutine = StartCoroutine(VignetteIn(1f, fadeInSpeed));

            
        }
    }

    IEnumerator VignetteIn(float targetValue, float fadeSpeed)
    {
        lerpTime = 0;
        float startValue = vignette.intensity.value;
        float step = Time.deltaTime / fadeSpeed;
        while (lerpTime < 1)
        {
            yield return null;
            lerpTime += step;
            vignette.intensity.value = Mathf.Lerp(startValue, targetValue, lerpTime);
        }
        deathRoutine = null;
        if (vignette.intensity.value >= 1f)
        {
            StartCoroutine(DeathUI());
        }
    }

    IEnumerator DeathUI()
    {
        deathUI.SetActive(true);
        Debug.Log("DeathUI ON");
        Invoke("DeathRespawn", 2);
        return null;
    }

    void DeathRespawn()
    {
        this.gameObject.transform.position = respawnPosition.transform.position;
        deathUI.SetActive(false);
        StartCoroutine(VignetteIn(0.3f, fadeOutSpeed));
    }
}
