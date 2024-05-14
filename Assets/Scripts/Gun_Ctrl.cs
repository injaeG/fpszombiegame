using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Ctrl : MonoBehaviour
{
    public GameObject pfBullet;
    public Transform firePos;
    Animator m_animator;
    public int dmagazine;//디폴트 탄창
    public int magazine;//실제 탄창
    public float ShootRate;//DPS
    public float ReloadTime;//재장전 시간
    private float TimeLeft = 0.1f; 
    private float nextTime = 0.0f;
    Scoreload_ctrl score;
    void Start()
    {
        score = GameObject.Find("loadTxt").GetComponent<Scoreload_ctrl>();
        magazine = dmagazine;
        score.Load = dmagazine;
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            m_animator.SetTrigger("Shoot");
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft; Shoot();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            m_animator.SetTrigger("Reload");
            Reload();
        }



    }
    private void Shoot()
    {
        if(magazine > 0)
        {
            Instantiate(pfBullet, firePos.transform.position, firePos.transform.rotation);
            magazine--;
            score.Load--;
        }
    }

    private void Reload()
    {
        magazine = dmagazine;
        score.Load = dmagazine;

    }

    
}
