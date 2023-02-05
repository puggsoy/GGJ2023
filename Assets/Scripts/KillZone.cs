using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
  		if (other.GetComponentInParent<Ball>() != null || other.GetComponentInParent<Bottle>() != null)
		{
			Destroy(other.gameObject);
		}
	}
}
