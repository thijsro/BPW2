using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class DeathManager : MonoBehaviour
{
    public bool inLight;

    public Volume volume;

    Vignette vignette;

    public float VignetteInt;

    public float maxLightDistance = 10;
    [SerializeField] float fadeSpeed = 2f;
    float lerpTime;


    private void Start()
    {
        vignette = (Vignette)volume.profile.components[5];
        VignetteInt = vignette.intensity.value;
    }

    private void Update()
    {
        //Debug.Log(vignette.intensity.value);

        
        if (!inLight)
        {
            //Debug.Log("NOTINLIGHT");
            //TowardsDeath();
        }
        else
        {
            //Debug.Log("INLIGHT");
            TowardsLife();  
            /*if (LightTransform != null)
            {
                VignetteInt = (Vector3.Distance(transform.position, LightTransform.position) / maxLightDistance);
                VignetteInt = Mathf.Clamp(VignetteInt, 0.3f, 1f);
                vignette.intensity.value = VignetteInt;
            }*/
        } 
    }
    
    public void TowardsDeath()
    {
        lerpTime += (Time.deltaTime / fadeSpeed);

        vignette.intensity.value = Mathf.Lerp(VignetteInt, 1f, lerpTime);
    }

    public void TowardsLife()
    {
        lerpTime += (Time.deltaTime / fadeSpeed);
        vignette.intensity.value = Mathf.Lerp(VignetteInt, 0.3f, lerpTime);
    }
    

}
