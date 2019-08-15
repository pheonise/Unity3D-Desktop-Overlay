using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
	[Tooltip("How long in seconds until the object is destroyed")]
	[SerializeField] float lifetime = 5f;
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}