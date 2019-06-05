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
    public Transform LightTransform;

    public float maxLightDistance = 10;

    private void Start()
    {
        vignette = (Vignette)volume.profile.components[5];
        VignetteInt = vignette.intensity.value;
    }

    private void Update()
    {
        Debug.Log(vignette.intensity.value);
        // Je kan ook de lightransform public assignen dan hoef je hem niet te krijgen d.m.v. de trigger

        
        if (!inLight)
        {
            Debug.Log("NOTINLIGHT");
            TowardsDeath();
        }
        else
        {
            Debug.Log("INLIGHT");
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

        vignette.intensity.value = Mathf.Lerp(VignetteInt, 1f, Time.deltaTime / 0.5f);
    }

    public void TowardsLife()
    {
        vignette.intensity.value = 0.3f;
            //Mathf.Lerp(VignetteInt, 0.3f, Time.deltaTime * 0.01f);
    }
    

}
