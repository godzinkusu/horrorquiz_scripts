using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationCameraController : MonoBehaviour
{
    public GameObject AnimationCamera;

    public Animator AnimationCameraAnimator;

    public GameObject AnimationCamera2;

    public Animator AnimationCamera2Animator;

    public GameObject velotext;

    public GameObject seikaitext;

    public TextMeshProUGUI text;

    public GameObject textobj;

    public AudioSource aus;

    public AudioClip ac;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);

        AnimationCameraAnimator.SetBool("move", true);

        yield return new WaitForSeconds(6.5f);

        AnimationCamera.SetActive(false);

        AnimationCamera2Animator.SetBool("move", true);

        yield return new WaitForSeconds(1f);

        text.text = "敵から逃げろ！！";
        aus.PlayOneShot(ac);

        textobj.SetActive(true);

        yield return new WaitForSeconds(3f);

        textobj.SetActive(false);

        AnimationCamera2.SetActive(false);
        velotext.SetActive(true);
        seikaitext.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
