using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi_move : MonoBehaviour
{
    Transform playerPos;
    float dist;
    float detectDist = 25.0f;
    int shotCnt = 0;
    public GameObject pfDestroyFX;
    Score_Ctrl score;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        score = GameObject.Find("ScoreTxt").GetComponent<Score_Ctrl>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(playerPos.position, transform.position);

        if (dist < detectDist)
        {
            GetComponent<Animator>().SetBool("IsWalk", true);
            GetComponent<NavMeshAgent>().SetDestination(playerPos.position);
        }
        else if (dist > detectDist)
        {
            GetComponent<Animator>().SetBool("IsWalk", false);
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            shotCnt += 1;
            if (shotCnt == 3)
            {
                Debug.Log("Hit");
                GetComponent<Animator>().SetBool("IsDie", true);
                Invoke("setactive", 0.8f);
                shotCnt = 0;
                Instantiate(pfDestroyFX, transform.position, transform.rotation);
                score.enemyScore = score.enemyScore + 10;
            }
        }
    }
    private void setactive()
        {
         gameObject.SetActive(false);
        }

}
