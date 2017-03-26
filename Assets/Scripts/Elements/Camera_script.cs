using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
	public Transform target;
	public float smoothTime = 0.1F;
	public float camera_distance = 30f;
	private Vector3 velocity = Vector3.zero;
	private Movements playerStats;

	void Start()
	{
		GameObject player = GameObject.Find("Player");
		playerStats = player.GetComponent<Movements>();
	}

	void OnGUI ()
	{
		GUI.Box (new Rect (0, 0, 100, 50), playerStats.playerHealth.ToString());
	}

	void Update()
	{
		Vector3 targetPosition = target.TransformPoint(new Vector3(0.5f, 0.4f, -camera_distance));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
