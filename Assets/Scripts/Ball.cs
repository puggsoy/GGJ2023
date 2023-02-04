using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
	private float m_editorSpeed = 1;

	[Header("Audio")]
	[SerializeField]
	private float m_volume = 3;

	[SerializeField]
	public AudioClip[] m_swipeSounds;

	public static float s_upForce = 1f;

	public static float s_forwardForce = 6f;

	public static float s_angularMin = 1f;

	public static float s_angularMax = 10f;

	public static float s_swipeThreshold = 0.1f;

	public static float s_upClamp = 10f;

	public static float s_speedClamp = 6f;

	public static float s_lastSpeed = 0f;

	private Vector2 m_startPos = Vector2.zero;
	private Vector2 m_endPos = Vector2.zero;

	private float m_touchTimeStart = 0f;
	private float m_touchTimeEnd = 0f;

	private bool m_thrown = false;

	private void Awake()
	{
		m_rb.isKinematic = true;
		m_collider.enabled = false;
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
			s_lastSpeed = m_editorSpeed;
			ThrowBall(new Vector3(0, s_upForce * m_editorSpeed, s_forwardForce * m_editorSpeed));
		}
	}

	private void AndroidUpdate()
	{
		if (m_thrown) return;

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			m_touchTimeStart = Time.time;
			m_startPos = Input.GetTouch(0).position;
			m_startPos = new Vector2(m_startPos.x / Screen.width, m_startPos.y / Screen.height);
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			m_touchTimeEnd = Time.time;
			float timeInterval = m_touchTimeEnd - m_touchTimeStart;

			m_endPos = Input.GetTouch(0).position;
			m_endPos = new Vector2(m_endPos.x / Screen.width, m_endPos.y / Screen.height);
			Vector2 displacement = m_endPos - m_startPos;

			if (displacement.sqrMagnitude < (s_swipeThreshold * s_swipeThreshold))
				return;

			float speed = (displacement.y / timeInterval);

			s_lastSpeed = speed;

			speed = Math.Min(speed, s_speedClamp);

			ThrowBall(new Vector3(0, s_upForce * speed, s_forwardForce * speed));
		}
	}

	private void ThrowBall(Vector3 force)
	{
		if (m_thrown || force == null || force.y < 0) return;

		force = new Vector3(force.x, Math.Min(force.y, s_upClamp), force.z);

		m_rb.isKinematic = false;
		m_collider.enabled = true;
		m_rb.AddForce(force, m_forceMode);
		m_rb.angularVelocity = (new Vector3(UnityEngine.Random.Range(s_angularMin, s_angularMax), 0, 0));

		m_thrown = true;

		SoundManager.Instance.RandomSoundEffect(m_volume, m_swipeSounds);

		OnLaunch?.Invoke();
	}
}
