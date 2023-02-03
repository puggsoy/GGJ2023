using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField]
	private Rigidbody m_rb = null;

	[Header("PC Controls")]
	[SerializeField]
	private float m_upForce = 1f;

	[SerializeField]
	private float m_forwardForce = 1f;

	private void Awake()
	{
		m_rb.isKinematic = true;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_rb.isKinematic = false;
			m_rb.velocity = new Vector3(0, m_upForce, m_forwardForce);
		}
	}
}
