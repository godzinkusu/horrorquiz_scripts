using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baisoku : MonoBehaviour
{
    private Image im;

    public Sprite[] sp;


    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
        im.sprite = sp[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clickdown()
    {
        Time.timeScale = 3;
        im.sprite = sp[1];
    }

    public void Clickup()
    {
        Time.timeScale = 1;
        im.sprite = sp[0];
    }
}
