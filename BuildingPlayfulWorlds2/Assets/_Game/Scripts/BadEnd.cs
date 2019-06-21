using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject trigger;
    public string stringAnimation;


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<FirstPersonController>().doInput = false;
        trigger.SetActive(true);
        anim.Play(stringAnimation);
        StartCoroutine(WaitUntilLoadLevel());
        Debug.Log("play anim");
    }

    IEnumerator WaitUntilLoadLevel()
    {
        yield return new WaitForSeconds(54.5f);
        SceneManager.LoadScene(1);
    }
}
