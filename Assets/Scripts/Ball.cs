using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField]
	private Rigidbody m_rb = null;

	[SerializeField]
	private ForceMode m_forceMode = ForceMode.Force;

	[SerializeField]
	private float m_upForce = 1f;

	[SerializeField]
	private float m_forwardForce = 1f;

	private Vector2 m_startPos = Vector2.zero;
	private Vector2 m_endPos = Vector2.zero;

	private float m_touchTimeStart = 0f;
	private float m_touchTimeEnd = 0f;

	private void Awake()
	{
		m_rb.isKinematic = true;
	}

#if UNITY_EDITOR || UNITY_STANDALONE
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ThrowBall(new Vector3(0, m_upForce, m_forwardForce));
		}
	}

#elif UNITY_ANDROID
	private void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			m_touchTimeStart = Time.time;
			m_startPos = Input.GetTouch(0).position;
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			m_touchTimeEnd = Time.time;
			float timeInterval = m_touchTimeEnd - m_touchTimeStart;
			m_endPos= Input.GetTouch(0).position;
			
			m_rb.isKinematic = false;
			ThrowBall(new Vector3(0, m_upForce / timeInterval, m_forwardForce / timeInterval));
		}
	}
#endif

	private void ThrowBall(Vector3 force)
	{
		m_rb.isKinematic = false;
		m_rb.AddForce(force, m_forceMode);

		
	}
}
