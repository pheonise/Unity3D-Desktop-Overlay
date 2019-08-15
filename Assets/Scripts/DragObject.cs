using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
	[Tooltip("What GameObject layers should the click query against?")] [SerializeField]
	LayerMask clickLayerMask = ~0;

	TargetJoint2D joint;

	void Update()
	{
		if (!Input.GetMouseButton(0))
		{
			if (joint)
			{
				Destroy(joint);
				joint = null;
			}

			return;
		}

		Vector2 pos = TransparentWindow.Camera.ScreenToWorldPoint(Input.mousePosition);

		if (joint)
		{
			joint.target = pos;
			return;
		}

		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}

		var overlapCollider = Physics2D.OverlapPoint(pos, clickLayerMask);
		if (!overlapCollider)
		{
			return;
		}

		var attachedRigidbody = overlapCollider.attachedRigidbody;
		if (!attachedRigidbody)
		{
			return;
		}

		joint = attachedRigidbody.gameObject.AddComponent<TargetJoint2D>();
		joint.autoConfigureTarget = false;
		joint.anchor = attachedRigidbody.transform.InverseTransformPoint(pos);
	}
}