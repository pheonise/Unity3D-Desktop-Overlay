using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouse : MonoBehaviour
{
	/// <summary>
	/// This script demonstrates moving the cursor via the Numpad keys.
	/// The logic is the same as moving a 2D object, though the y-axis is reversed (y-down rather than Unity's y-up)
	/// </summary>
	
	[SerializeField] float moveSpeed = 500f;

	void Update()
	{
		float delta = Time.deltaTime * moveSpeed;

		Vector2 position = SystemInput.GetCursorPosition();

		//TODO: Add keyboard keys to SystemInput so we don't need focus to read Input
//		if (SystemInput.GetKey(KeyCode.Keypad8))

		if (Input.GetKey(KeyCode.Keypad8))
		{
			position += Vector2.down * delta;
		}

		if (Input.GetKey(KeyCode.Keypad5))
		{
			position += Vector2.up * delta;
		}

		if (Input.GetKey(KeyCode.Keypad4))
		{
			position += Vector2.left * delta;
		}

		if (Input.GetKey(KeyCode.Keypad6))
		{
			position += Vector2.right * delta;
		}

		SystemInput.SetCursorPosition(new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)));
	}
}