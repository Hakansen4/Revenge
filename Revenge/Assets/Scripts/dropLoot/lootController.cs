using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootController : MonoBehaviour
{
    private Transform target;
    private charSoulController souls;
    private float min = 100;
    private float max = 200;
    [HideInInspector]public float soulsSayisi;
    Vector3 _velocity = Vector3.zero;
    float timer = 0;
    void Start()
    {
        souls = GameObject.FindGameObjectWithTag("Player").GetComponent<charSoulController>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(Time.time - timer > 2)
        transform.position = Vector3.SmoothDamp(transform.position,target.position,ref _velocity,Time.deltaTime * Random.Range(min,max));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            souls.addSoul(soulsSayisi);
            Destroy(this.gameObject);
        }
    }
}