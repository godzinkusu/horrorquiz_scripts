using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class touchitem : MonoBehaviour
{
    public GameObject Buttonrenda;

    public GameObject[] turus;

    private int g = 0;

    private int x = 0;

    public TextMeshProUGUI text;

    public GameObject textobj;

    public GameObject textnumberobj;

    public Text textnumber;

    public Image button1;

    public Sprite[] buttonsp;

    public GameObject eff;

    public GameObject explosion;

    public AudioSource aus;

    public AudioClip[] auc;

    // Start is called before the first frame update
    void Start()
    {
        g = 0;
        textobj.SetActive(false);
        Buttonrenda.SetActive(false);
        textnumberobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textnumber.text = x + "/15";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "turu")
        {
            textobj.SetActive(true);
            text.text = "ボタンを連打しろ！！";

            Buttonrenda.SetActive(true);

            textnumberobj.SetActive(true);
            textnumber.text = x + "/15";
        }
    }

    public void clickrenda()
    {
        x++;
        var c = Instantiate(eff, new Vector3(turus[g].transform.position.x, turus[g].transform.position.y-1, turus[g].transform.position.z+0.2f), Quaternion.identity);

        Destroy(c, 1f);

        if (x < 15)button1.sprite = buttonsp[1];


        if (x == 15)
        {
            textobj.SetActive(false);
            Buttonrenda.SetActive(false);
            textnumberobj.SetActive(false);
            button1.sprite = buttonsp[0];
            aus.PlayOneShot(auc[2]);

            StartCoroutine(clickrendafinish());
        }

        if (x == 5)
        {
            aus.PlayOneShot(auc[0]);
        }

        if (x == 10)
        {
            aus.PlayOneShot(auc[1]);
        }
    }

    public void clickrendaup()
    {
        button1.sprite = buttonsp[0];
    }


    IEnumerator clickrendafinish()
    {
        yield return new WaitForSeconds(0.2f);

        var k = Instantiate(explosion, new Vector3(turus[g].transform.position.x, turus[g].transform.position.y - 2, turus[g].transform.position.z + 0.2f), Quaternion.identity);

        Destroy(k, 0.5f);

        Destroy(turus[g]);


        yield return new WaitForSeconds(0.1f);

        x = 0;
        g++;
    }
}
