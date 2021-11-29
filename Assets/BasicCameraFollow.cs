using System;
using UnityEngine;
using System.Collections;

public class BasicCameraFollow : MonoBehaviour 
{

	private Vector3 startingPosition;
	private Transform followTarget;
	private Vector3 targetPos;
	public float moveSpeed;



	void Start()
	{
  
		//Instantiate(this.gameObject,this.transform.position,this.transform.rotation);
		 followTarget = GameObject.FindWithTag("Player").transform;
		 if(!followTarget)Debug.Log("followTarget - null");
		startingPosition = followTarget.position;
	}

	void Update () 
	{
		if(followTarget != null)
		{
			targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
		}
	}
}

