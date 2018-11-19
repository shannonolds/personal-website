using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {

    public float speed;
    public float rightBound;
    public float leftBound;
    public GameManager gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gm.gameOver){
            return;
        }
        //move paddle on the horizontal axis
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);  

        //check to see if the paddle is off the screen
        if(transform.position.x < leftBound){
            transform.position = new Vector2(leftBound, transform.position.y);
        }
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector2(rightBound, transform.position.y);
        }
    }
}
