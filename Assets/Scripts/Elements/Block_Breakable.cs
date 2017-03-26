using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Breakable : MonoBehaviour
{
	private Rigidbody[] p1;

	void Start()
	{
		p1 = GetComponentsInChildren<Rigidbody> ();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player")
		{
			StartCoroutine(BreakThisObject());
		}
	}

	IEnumerator BreakThisObject() {
		foreach(Rigidbody child in p1)
		{
			if(child.CompareTag("p1"))
				child.constraints = RigidbodyConstraints.None;
		}
		yield return new WaitForSeconds(1);
		foreach(Rigidbody child in p1)
		{
			if(child.CompareTag("p2"))
				child.constraints = RigidbodyConstraints.None;
		}
		yield return new WaitForSeconds(1);
		foreach(Rigidbody child in p1)
		{
			if(child.CompareTag("p3"))
				child.constraints = RigidbodyConstraints.None;
		}
		yield return new WaitForSeconds(1);
		Destroy(this.gameObject);
	}
}
