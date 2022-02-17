using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    private float timer = 0f;
    public GameObject bulletRef;
    private GameObject bulletObject;

    public int limoHealth = 2;
    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 3f)
        {
            bulletObject = Instantiate(bullet, bulletRef.transform.position, transform.rotation);
            bulletObject.transform.parent = gameObject.transform;
            timer = 0f;
        }
    }
}
