﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();


	}
	
	// Update is called once per frame
	void Update () {
        if(gm.gameOver){
            return;
        }
        if(!inPlay){
            transform.position = paddle.position;
        }

        //press spacebar to launch ball
        if(Input.GetButtonDown("Jump") && !inPlay){
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
	}

    void OnTriggerEnter2D(Collider2D collison){
        if(collison.CompareTag("bottom")){
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("brick")){
            Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            gm.UpdateScore(collision.gameObject.GetComponent<brick>().points);
            gm.UpdateNumBricks();
            Destroy(collision.gameObject); 
        }
    }
}
