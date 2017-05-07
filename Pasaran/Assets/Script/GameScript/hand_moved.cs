﻿using UnityEngine;
using System.Collections;

public class hand_moved : MonoBehaviour {

	public Transform player;
	public float smoothing = 0.5f;
	public float posZ;
	Vector3 offset;
	Vector3 newPosition;

	// Use this for initialization
	void Start()
	{
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		newPosition = player.transform.position + offset;

		newPosition.z = posZ;

		transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.deltaTime);
	}

}