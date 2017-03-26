using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movements : MonoBehaviour 
{
	public int force = 200;
	public float playerHealthMax = 100.0f;
	public float playerHealth;
	public float damages = 0.0f;
	public float test = 0.0f;
	private bool canJump;
	private float limitVelocity = 0.0f;
	private Rigidbody selfRigidbody;

	void Start()
	{
		selfRigidbody = GetComponent<Rigidbody> ();
		playerHealth = playerHealthMax;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.D) && !Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.39f, transform.position.z), transform.TransformDirection(Vector3.right), 0.3f))
			transform.Translate(Vector3.right * 2 * Time.deltaTime);
		if (Input.GetKey(KeyCode.A) && !Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.39f, transform.position.z), transform.TransformDirection(Vector3.left), 0.3f))
			transform.Translate(Vector3.left * 2 * Time.deltaTime);
		if (Input.GetKey(KeyCode.Space) &&
			(Physics.Raycast(new Vector3(transform.position.x - 0.249f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.down), 0.4f) ||
				Physics.Raycast(new Vector3(transform.position.x + 0.249f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.down), 0.4f)))
		{
			canJump = true;
		}
	}

	void FixedUpdate()
	{
		if (selfRigidbody.velocity.y < -10.0 && selfRigidbody.velocity.y > -40.0)
			limitVelocity = selfRigidbody.velocity.y + 10.0f;
		if (Physics.Raycast(new Vector3(transform.position.x - 0.249f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.down), 0.5f) ||
			Physics.Raycast(new Vector3(transform.position.x + 0.249f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.down), 0.5f))
		{
			damages = (Math.Abs(limitVelocity) * 100.0f / 5.0f);
			if (damages > 0.0f)
			{
				playerHealth -= playerHealthMax * damages / 100.0f;
				print (damages);
				damages = 0.0f;
			}
			selfRigidbody.velocity = new Vector3 (selfRigidbody.velocity.x, 0, selfRigidbody.velocity.z);
			limitVelocity = 0.0f;
			if (playerHealth <= 0)
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (canJump)
		{
			canJump = false;
			selfRigidbody.AddForce(0, force, 0, ForceMode.Acceleration);
		}
	}
}
