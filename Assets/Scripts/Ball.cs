using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public event Action OnLaunch = null;

	[SerializeField]
	private Rigidbody m_rb = null;

	[SerializeField]
	private Collider m_collider = null;

	[SerializeField]
	private ForceMode m_forceMode = ForceMode.Force;

	[SerializeField]
	private float m_upForce = 1f;

	[SerializeField]
	private float m_forwardForce = 1f;

	private Vector3 m_spawnedPos = Vector3.zero;

	private Vector2 m_startPos = Vector2.zero;
	private Vector2 m_endPos = Vector2.zero;

	private float m_touchTimeStart = 0f;
	private float m_touchTimeEnd = 0f;

	private bool m_thrown = false;

	private void Awake()
	{
		m_rb.isKinematic = true;
		m_collider.enabled = false;
		m_spawnedPos = transform.position;
	}

	private void Update()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		PCUpdate();
#elif UNITY_ANDROID
		AndroidUpdate();
#endif

		Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

		if (screenPos.y > Screen.height + 100 || screenPos.y < 0 || screenPos.x > Screen.width + 100 || screenPos.x < 0)
		{
			Destroy(this.gameObject);
		}
	}

	private void PCUpdate()
	{
		if (m_thrown) return;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			ThrowBall(new Vector3(0, m_upForce, m_forwardForce));
		}
	}

	private void AndroidUpdate()
	{
		if (m_thrown) return;

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			m_touchTimeStart = Time.time;
			m_startPos = Input.GetTouch(0).position;
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			m_touchTimeEnd = Time.time;
			float timeInterval = m_touchTimeEnd - m_touchTimeStart;
			m_endPos = Input.GetTouch(0).position;

			m_rb.isKinematic = false;
			ThrowBall(new Vector3(0, m_upForce / timeInterval, m_forwardForce / timeInterval));
		}
	}

	private void ThrowBall(Vector3 force)
	{
		if (m_thrown || force == null) return;

		m_rb.isKinematic = false;
		m_collider.enabled = true;
		m_rb.AddForce(force, m_forceMode);

		m_thrown = true;

		OnLaunch?.Invoke();
	}
}
