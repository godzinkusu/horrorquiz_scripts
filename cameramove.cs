using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace camera
{
    

    public enum CameraState
    {
        Idle,Walking,Running
    }

    //[RequireComponent(typeof(CharacterController))]//charactercontrollerを追加して

    public class cameramove : MonoBehaviour
    {
        [Range(0.1f, 2f)]
        public float walkSpeed = 1.5f;

        [Range(0.1f, 20f)]
        public float runSpeed = 5f;

        public GameObject camera2;

        public GameObject[] wall;

        private int d = 0;

        public GameObject Panel;

        public GameObject text1;

        public GameObject text2;

        public GameObject camera;

        public GameObject cameraanime;

        public AudioListener meal;

        public AudioListener camera2al;

        public AudioSource moveaus;

        public AudioClip moveac;

        private bool moveis;

        public Image[] buttonimage;


        // キャラクターコントローラー
        //private CharacterController charaController;


        // Start is called before the first frame update
        void Start()
        {
            //charaController = GetComponent<CharacterController>();
            moveis = false;

            StartCoroutine(PlayerFootSound());  // コルーチンの起動
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            breakhatei();

            if (this.transform.position.z <= -270)
            {
                SceneManager.LoadScene("GAMECLEAR");
            }


            if (cameraanime.activeSelf == false)
            {
                camera2al.enabled = true;
            }

            if (cameraanime.activeSelf == true)
            {
                camera2al.enabled = false;
            }
        }

        void Move()
        {

            if(camera2.activeSelf == false)
            {
                var movez = 0.5f;

                var movey = Mathf.Sin(Time.time * 10);

                var movement = new Vector3(0, 0.2f * movey, -movez);

                if (movement.sqrMagnitude > 1)//ベクトルの平方が1以上の時
                {
                    movement.Normalize();//ベクトルの長さを1に
                }

                this.transform.position += movement * Time.fixedDeltaTime * runSpeed;

                //charaController.Move(movement * Time.fixedDeltaTime * runSpeed);

                meal.enabled = true;
                moveis = true;

            }

            else if(camera2.activeSelf == true)
            {
                meal.enabled = false;
                moveis = false;
            }

        }

        void breakhatei()
        {
            if (d <= 9)
            {
                if (this.transform.position.z > wall[d].transform.position.z + 4f)
                {
                    Move();
                    buttonimage[0].color = new Color(1, 1, 1, 1);
                    buttonimage[1].color = new Color(1, 1, 1, 1);
                    buttonimage[2].color = new Color(1, 1, 1, 1);
                    buttonimage[3].color = new Color(1, 1, 1, 1);
                }

                if (this.transform.position.z <= wall[d].transform.position.z + 4f)
                {
                    if (wall[d].activeSelf == true)
                    {
                        Panel.SetActive(true);
                        moveis = false;
                    }

                    else if (wall[d].activeSelf == false)
                    {
                        Move();

                        Panel.SetActive(false);

                        d++;
                    }
                }
            }


            else if(d >9)
            {
                Move();
                text1.SetActive(false);
                text2.SetActive(false);
                camera.SetActive(false);
                buttonimage[0].color = new Color(1, 1, 1, 1);
                buttonimage[1].color = new Color(1, 1, 1, 1);
                buttonimage[2].color = new Color(1, 1, 1, 1);
                buttonimage[3].color = new Color(1, 1, 1, 1);
            }


        }

        // 移動時の足音
        public IEnumerator PlayerFootSound()
        { // 「IEnumerator」についてネットで調べてみよう！ 
            while (true)
            {
                if (moveis==true)
                {
                  moveaus.PlayOneShot(moveac);
                    yield return new WaitForSeconds(4);// 「WaitForSeconds」について調べてみよう！
                }

                if (moveis == false)
                {
                    moveaus.Stop();
                    yield return new WaitForSeconds(0.1f);
                }



            }
        }

    }


}

