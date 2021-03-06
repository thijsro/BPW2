﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowManager : MonoBehaviour
{
    GameObject ball;
    Rigidbody rb;
    public Ball CurrentBall;
    public LayerMask ballLayer;
    public LayerMask crystalLayer;
    [SerializeField] private float hitDistanceBall = 10f;
    [SerializeField] private float hitDistanceCrystal = 5f;


    [SerializeField] GameObject attachPosition;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
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
            if (Physics.Raycast(ray, out hit, hitDistanceBall, ballLayer))
            {
                Ball ball = hit.collider.gameObject.GetComponent<Ball>();
                if (ball != null)
                {
                    CurrentBall = ball;
                    CurrentBall.OnPickup(attachPosition);
                }
                
            }
            if (Physics.Raycast(ray, out hit, hitDistanceCrystal, crystalLayer))
            {
                CrystalScript Crystal = hit.collider.gameObject.GetComponent<CrystalScript>();
                Crystal.TurnOn(0);
                
            }
        }

        //Throw
        if (Input.GetMouseButtonDown(0) && CurrentBall != null)
        {
            CurrentBall.transform.parent = null;
            CurrentBall.OnRelease();
            CurrentBall.AddForce();
            CurrentBall = null;
            
            
        }
    }
}
