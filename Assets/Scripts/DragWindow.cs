using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWindow : MonoBehaviour
{
	
	/// <summary>
	/// Simple click-and-drag, but moves the actual window (if not fullscreen)
	/// </summary>
	
	new Collider2D collider = null;
	bool draggingWindow = false;

	void Awake()
	{
		collider = GetComponent<Collider2D>();
	}

	void Update()
	{
		if (!Input.GetMouseButton(0))
		{
			draggingWindow = false;
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			Vector2 pos = TransparentWindow.Camera.ScreenToWorldPoint(Input.mousePosition);

			var overlapCollider = Physics2D.OverlapPoint(pos);
			if (!overlapCollider)
			{
				draggingWindow = false;
				return;
			}

			if (overlapCollider == collider)
			{
				draggingWindow = true;
			}
		}

		if (draggingWindow)
		{
			TransparentWindow.DragWindow();
		}
	}
}