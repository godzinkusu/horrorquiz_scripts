using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Enemy;
using UnityEngine.SceneManagement;

public class csvreader : MonoBehaviour
{
    private string[] bunsyou;//文章部分

    private string[] botan0;//ボタンテキスト部分
    private string[] botan1;
    private string[] botan2;
    private string[] botan3;

    public GameObject[] horrorbrock;

    private List<int> c;//どれが正解か?

    //public string filepass;//どのCSVを使うかの箱

    public Text bun;

    public Text[] buttontexts;

    private int a;//どの文章が

    private int g = 0;//加算

    public GameObject horrorenemy;
    public GameObject me;

    public Text velotext;
    private float velo;

    public Text seikaitext;

    private int[] m = {1024,1024,1024,1024,1024,1024,1024,1024,1024,1024,1024 };

    public AudioSource aus;

    public AudioClip[] acs;

    // Start is called before the first frame update
    void Start()
    {
        bunsyou = new string[1024];
        botan0 = new string[1024];
        botan1 = new string[1024];
        botan2 = new string[1024];
        botan3 = new string[1024];

        c = new List<int>(1024);
        
        ReadCSV();

        g = 0;


        velo = -me.transform.position.z + horrorenemy.transform.position.z;
        velo *= 2;
        velotext.text = "敵の距離:"+ velo.ToString("F0")+"[m]";
        seikaitext.text = "正解の数\n"+ g + "/10";

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Openbunsyou();
        velo = -me.transform.position.z + horrorenemy.transform.position.z;
        velo *= 2;
        velotext.text = "敵の距離:" + (velo-16).ToString("F0") + "[m]";
        seikaitext.text = "正解の数\n" + g + "/10";

        if (velo <= 16)
        {
            SceneManager.LoadScene("GAMEOVER");
        }

    }

    void ReadCSV()
    {
        //TextAsset csv = Resources.Load("CSV/sample",filepass) as TextAsset;CSVというファイル内にあるsampleというファイルを開く,Resourcesというフォルダを参照する
        TextAsset csv = Resources.Load(clickbutton.questionselect(clickbutton.d)) as TextAsset;//filepassという変数を使ってファイルの場所を開く


        Debug.Log(csv.text);//textが出るように
        StringReader reader = new StringReader(csv.text);//csvのテキストを読み込ませる

        int i = 0;
        while (reader.Peek() != -1)//読み込みできる文字がなくなるまで繰り返す
        {

            string line = reader.ReadLine();// ファイルを 1 行ずつ読み込む
            string[] values = line.Split(',');//,で分割

                bunsyou[i] = values[0];
                botan0[i] = values[1];
                botan1[i] = values[2];
                botan2[i] = values[3];
                botan3[i] = values[4];
                c.Add(int.Parse(values[5]));

            Debug.Log(line);
            Debug.Log(c);

            i++;
        }

        a = Random.Range(0, c.Count);

    }


    void Openbunsyou()
    {

        bun.text = bunsyou[a];
        buttontexts[0].text = botan0[a];
        buttontexts[1].text = botan1[a];
        buttontexts[2].text = botan2[a];
        buttontexts[3].text = botan3[a];

    }


    public void Onclick1()
    {
        if(c[a] == 0)
        {
            horrorbrock[g].GetComponent<BreakWall>().Clear();
            aus.PlayOneShot(acs[0]);

        }

        else
        {
            horrorbrock[g].GetComponent<BreakWall>().Out();
            moveenemy.enemyspeed += 1.5f;

            aus.PlayOneShot(acs[1]);
        }


    }

    public void Onclick2()
    {
        if (c[a] == 1)
        {
            horrorbrock[g].GetComponent<BreakWall>().Clear();
            aus.PlayOneShot(acs[0]);
        }

        else
        {
            horrorbrock[g].GetComponent<BreakWall>().Out();
            moveenemy.enemyspeed += 1.5f;
            aus.PlayOneShot(acs[1]);
        }
    }

    public void Onclick3()
    {
        if (c[a] == 2)
        {
            horrorbrock[g].GetComponent<BreakWall>().Clear();
            aus.PlayOneShot(acs[0]);

        }

        else
        {
            horrorbrock[g].GetComponent<BreakWall>().Out();
            moveenemy.enemyspeed += 1.5f;
            aus.PlayOneShot(acs[1]);
        }
    }

    public void Onclick4()
    {
        if (c[a] == 3)
        {
            horrorbrock[g].GetComponent<BreakWall>().Clear();
            aus.PlayOneShot(acs[0]);
        }

        else
        {
            horrorbrock[g].GetComponent<BreakWall>().Out();
            moveenemy.enemyspeed += 1.5f;
            aus.PlayOneShot(acs[1]);
        }
    }



    public void questionchange()
    {
        m[g] = a;

        g++;

        do
        {
            a = Random.Range(0, c.Count);
        }
        while (a == m[0] || a == m[1] || a == m[2] || a == m[3] || a == m[4] || a == m[5] || a == m[6] || a == m[7] || a == m[8]);

    }


}
