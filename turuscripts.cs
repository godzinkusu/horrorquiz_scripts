using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turuscripts : MonoBehaviour
{
    public GameObject player;

    private Animator turuanimator;

    private AudioSource aus;


    // Start is called before the first frame update
    void Start()
    {
        turuanimator = GetComponent<Animator>();

        aus = GetComponent<AudioSource>();

        aus.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z - this.transform.position.z < 15)
        {
            turuanimator.SetBool("start", true);
        }

        if (turuanimator.GetBool("start") == true)
        {
            aus.enabled = true;
        }
    }
}
