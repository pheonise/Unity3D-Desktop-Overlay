using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class WindowBoundsCollider2D : MonoBehaviour
{
	new Camera camera;
	EdgeCollider2D borderCollider;

	[Tooltip("Camera-relative size of the bounds (1 = full window, 0.5 = half). Useful for safe-areas")] [SerializeField]
	float scale = 1f;

	[Tooltip("A larger radius helps prevent fast-moving objects from clipping through")] [SerializeField]
	float edgeRadius = 10f;

	void Start()
	{
		CreateCollider();
	}

	void CreateCollider()
	{
		camera = GetComponent<Camera>();
		borderCollider = gameObject.AddComponent<EdgeCollider2D>();

		var cameraPlane = camera.orthographic ? 0 : -camera.transform.position.z;
		borderCollider.edgeRadius = edgeRadius;

		var maxScale = scale;
		var minScale = 1f - scale;
		borderCollider.points = new[]
		{
			(Vector2) camera.ViewportToWorldPoint(new Vector3(minScale, minScale, cameraPlane)) + new Vector2(-edgeRadius, -edgeRadius),
			(Vector2) camera.ViewportToWorldPoint(new Vector3(minScale, maxScale, cameraPlane)) + new Vector2(-edgeRadius, edgeRadius),
			(Vector2) camera.ViewportToWorldPoint(new Vector3(maxScale, maxScale, cameraPlane)) + new Vector2(edgeRadius, edgeRadius),
			(Vector2) camera.ViewportToWorldPoint(new Vector3(maxScale, minScale, cameraPlane)) + new Vector2(edgeRadius, -edgeRadius),
			(Vector2) camera.ViewportToWorldPoint(new Vector3(minScale, minScale, cameraPlane)) + new Vector2(-edgeRadius, -edgeRadius),
		};
	}

	void OnDrawGizmosSelected()
	{
		var maxScale = scale;
		var minScale = 1f - scale;

		if (!camera)
		{
			camera = GetComponent<Camera>();
		}

		var cameraPlane = camera.orthographic ? 0 : -camera.transform.position.z;
		var pointA = camera.ViewportToWorldPoint(new Vector3(minScale, minScale, cameraPlane));
		var pointB = camera.ViewportToWorldPoint(new Vector3(minScale, maxScale, cameraPlane));
		var pointC = camera.ViewportToWorldPoint(new Vector3(maxScale, maxScale, cameraPlane));
		var pointD = camera.ViewportToWorldPoint(new Vector3(maxScale, minScale, cameraPlane));
		Gizmos.DrawLine(pointA, pointB);
		Gizmos.DrawLine(pointB, pointC);
		Gizmos.DrawLine(pointC, pointD);
		Gizmos.DrawLine(pointD, pointA);
	}
}