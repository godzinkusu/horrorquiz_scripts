using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{   
    public enum EnemyState
    {
        Idle,Running,ENDing
    }


    public class moveenemy : MonoBehaviour
    {
        private Animator enemyAnimotor;
        private float timer = 0;

        public static float enemyspeed = 1.0f;

        public GameObject maincharacter;


        // Start is called before the first frame update
        void Start()
        {
            enemyAnimotor = GetComponent<Animator>();
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            timer += Time.deltaTime;

            if(timer >= 11f)
            {
                enemyAnimotor.SetBool("Run", true);
                
            }

            if (enemyAnimotor.GetCurrentAnimatorStateInfo(0).IsTag("move") && maincharacter.transform.position.z >= -260)
            {
                this.transform.position += new Vector3(0, 0, -0.02f) * enemyspeed;
                enemyAnimotor.SetFloat("speed", enemyspeed);
                
            }


            else
            {
                
            }
        }
    }
}



