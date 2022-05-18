using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    public float speed;
    public bool isGoingLeft;
    private Transform trnsfrm;
    void Start()
    {
        trnsfrm = this.gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        move();
    }
    private void move()
    {
        if(isGoingLeft)
        {
            transform.localScale = new Vector3(-1,1,1);
            transform.position -= Vector3.right * speed *Time.deltaTime;
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Enemy")   &&  !other.CompareTag("chaseArea")  &&  !other.CompareTag("e0_Hit"))
            Destroy(gameObject);
    }
}
