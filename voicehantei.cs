using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;   //Windowsの音声認識で使用
using System.Linq;                  //listに使える
using UnityEngine.UI;



public class voicehantei : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    //private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    private Dictionary<string, int> keywords = new Dictionary<string, int>();

    public Button[] kaitou;
    public Image[]kaitouimage;

    // Start is called before the first frame update
    void Start()
    {
        //反応するキーワードを辞書に登録
        keywords.Add("いち",1);

        keywords.Add("わん", 1);

        keywords.Add("one", 1);

        keywords.Add("に", 2);

        keywords.Add("トゥー", 2);

        keywords.Add("two", 2);

        keywords.Add("さん", 3);

        keywords.Add("スリー", 3);

        keywords.Add("three", 3);

        keywords.Add("よん", 4);

        keywords.Add("four", 4);

        keywords.Add("フォー", 4);


        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());////List型を配列に変換する

        //キーワードを認識したら反応するOnPhraseRecognizedに「KeywordRecognizer_OnPhraseRecognized」処理を渡す
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        //音声認識開始
        keywordRecognizer.Start();
        Debug.Log("音声認識開始");
    }

    // Update is called once per frame


    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        int x;

        if (keywords.TryGetValue(args.text, out x) && kaitou[0].interactable == true && kaitou[3].interactable == true)
        {
            // keywordAction.Invoke();

            switch (x)
            {
                case 1:
                    kaitouimage[0].color = new Color(1, 0, 0, 1);
                    kaitou[0].onClick.Invoke();
                    break;

                case 2:
                    kaitouimage[1].color = new Color(1, 0, 0, 1);
                    kaitou[1].onClick.Invoke();
                    break;

                case 3:
                    kaitouimage[2].color = new Color(1, 0, 0, 1);
                    kaitou[2].onClick.Invoke();
                    break;

                case 4:
                    kaitouimage[3].color = new Color(1, 0, 0, 1);
                    kaitou[3].onClick.Invoke();
                    break;
            }


            Debug.Log("認識した");
        }
    }



}

