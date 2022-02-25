using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changemode : MonoBehaviour
{
    public GameObject baisoku;

    public GameObject[] turus;

    public enum Change
    {
        quiz, horror
    }

    public static Change change;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (change == Change.quiz)
        {
            baisoku.SetActive(true);
            turus[0].SetActive(false);
            turus[1].SetActive(false);
        }

        if (change == Change.horror)
        {
            baisoku.SetActive(false);
            turus[0].SetActive(true);
            turus[1].SetActive(true);
        }
    }
}
