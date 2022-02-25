using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BreakWall : MonoBehaviour
{
    public GameObject huseikai;

    public GameObject seikai;

    public GameObject gamemanaer;

    public Button[] buttons;

    public GameObject explosion;

    public AudioSource aus;

    public AudioClip ac;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()//問題を正解した場合
    {
        StartCoroutine(Break());
    }

    IEnumerator Break()
    {
        var k = Instantiate(explosion, new Vector3(this.transform.position.x,this.transform.position.y-2,this.transform.position.z), Quaternion.identity);

        Destroy(k, 3);


        gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r =>
        {
            r.constraints = RigidbodyConstraints.FreezePosition;
        });

        for(int x = 0; x < buttons.Length; x++)
        {
            buttons[x].interactable = false;
            yield return new WaitForSeconds(0.001f);
        }

        seikai.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r =>
        {
            r.isKinematic = false;

        });

        yield return new WaitForSeconds(0.2f);

        gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r =>
        {
            r.constraints = RigidbodyConstraints.None;
        });

        yield return new WaitForSeconds(2f);

        seikai.SetActive(false);

        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x].interactable = true;
            yield return new WaitForSeconds(0.001f);
        }


        aus.PlayOneShot(ac);

        this.gameObject.SetActive(false);

        gamemanaer.GetComponent<csvreader>().questionchange();

    }


    public void Out()//不正解の時
    {

        StartCoroutine(NoBreak());
    }

    IEnumerator NoBreak()
    {
        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x].interactable = false;
            yield return new WaitForSeconds(0.001f);
        }

        huseikai.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        huseikai.SetActive(false);

        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x].interactable = true;
            yield return new WaitForSeconds(0.001f);
        }
    }

}
