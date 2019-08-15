using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	new Camera camera;

	void Awake()
	{
		camera = FindObjectOfType<Camera>();
	}
	
	void Update()
	{
		var mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
		transform.position = mousePos;
	}
}
