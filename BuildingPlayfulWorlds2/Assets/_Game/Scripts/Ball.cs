using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPickup()
    {
        rb.isKinematic = true;
    }

    public void OnRelease()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
    }

    public void AddForce()
    {

    }
}
