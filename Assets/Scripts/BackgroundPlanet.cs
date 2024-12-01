using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPlanet : MonoBehaviour
{

    private float speedX = -0.5f;
    private float resetPosition = 30f;
    private float turnSpeed;
	private float textureWidth;

	void Start ()
    {
        turnSpeed = Random.Range(0.01f, 0.05f);

		textureWidth = GetComponent<SpriteRenderer>( ).bounds.size.x;
	}
	
	void Update ()
	{

	    transform.Rotate(0f, 0f, turnSpeed);

	    transform.position = transform.position + new Vector3(speedX * Time.deltaTime, 0f, 0f);

	    

        if (transform.position.x < -(textureWidth / 2f))
	    {
            transform.position = new Vector3(resetPosition, transform.position.y, transform.position.z);
	    }

	}
}



