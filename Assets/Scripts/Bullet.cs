using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    private Transform parentTransform;
    private Enemy _enemy;
    private float timer = 0f;
    
    private void Start()
    {
        _enemy = gameObject.GetComponentInParent<Enemy>();
        parentTransform = GetComponentInParent<Transform>();
        gameObject.GetComponent<Rigidbody>().AddForce(parentTransform.forward * 500f);
        gameObject.transform.parent = null;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Police"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
        else if (other.gameObject.CompareTag("Limo"))
        {
            if (_enemy.limoHealth == 2)
            {
                _enemy.limoHealth -= 1;
                Destroy(gameObject);
            }
            else if (_enemy.limoHealth <= 1)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
