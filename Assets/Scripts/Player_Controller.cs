using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float maxSpeed = 10f;
    Rigidbody2D rigidbody;
	// Use this for initialization
	void Start ()
    {

        // getting the access to the rigid body component.
        rigidbody = GetComponent<Rigidbody2D>();
    
	}
	
	// Update is called once per frame
	void Update () {

        // get the current value of the axis (w,a,s,d) or (arrows)
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical   = Input.GetAxisRaw("Vertical");

        // smoothed out values
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        // declare the current movement for the vector
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // change the velocity of the rigid body
        rigidbody.velocity = movement * maxSpeed;

        // get user input for the keys
        /*if (Input.GetKey(KeyCode.UpArrow)) {
            
            rigidbody.velocity = Vector2.up * maxSpeed;
        }

        if (Input.GetKey("down")) {
            rigidbody.AddForce(movement * maxSpeed);
        }

        if (Input.GetKey("left")) {
            rigidbody.AddForce(movement * maxSpeed);
        }
        if (Input.GetKey("right")) {
            rigidbody.AddForce(movement * maxSpeed);
        }*/

	}
}
