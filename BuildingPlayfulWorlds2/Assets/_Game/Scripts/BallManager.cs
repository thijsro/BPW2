using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public bool isDetached = false;
    [SerializeField] GameObject[] balls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDetached == true)
        {
            Debug.Log("child detached");
        } 
    }

    void ThrowBall()
    {
        balls[0].transform.parent = null;
    }
}
