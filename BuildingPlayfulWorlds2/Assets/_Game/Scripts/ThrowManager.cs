using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{
    GameObject ball;
    public GameObject ballManager;
    Rigidbody rb;
    private Ball CurrentBall;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponentInChildren<Ball>().gameObject;
        rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballManager = GetComponentInChildren<BallManager>().gameObject;

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //pickup ball
        if (Input.GetButton("Interaction"))
        {
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;     
            if (Physics.Raycast(ray, out hit, 10f))
            {
                Ball ball = hit.collider.gameObject.GetComponent<Ball>();
                if (ball != null)
                {
                    CurrentBall = ball;
                    CurrentBall.OnPickup();
                }
            }  
        }

        //Throw
        if (Input.GetMouseButtonDown(0) && CurrentBall != null)
        {
            CurrentBall.OnRelease();
            CurrentBall.AddForce();
            CurrentBall = null;
        }
    }
}
