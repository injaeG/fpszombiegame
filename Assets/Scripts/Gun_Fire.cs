using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Fire : MonoBehaviour
{
    public GameObject pfBullet;
    public Transform firePos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
            
    }

    private void Fire()
    {
        Instantiate(pfBullet, firePos.position, firePos.rotation);
    }
}
