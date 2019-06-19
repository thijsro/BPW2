using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public string stringAnimation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        anim.Play(stringAnimation);
    }
}
