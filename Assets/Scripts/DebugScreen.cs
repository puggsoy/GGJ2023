using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugScreen : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI m_yMultText = null;

	[SerializeField]
	private TextMeshProUGUI m_zMultText = null;

	private void Awake()
	{
		Refresh();
	}

	private void Refresh()
	{
		m_yMultText.text = Ball.s_upForce.ToString();
		m_zMultText.text = Ball.s_forwardForce.ToString();
	}

	public void AddYMult(float amount)
	{
		Ball.s_upForce += amount;
		Refresh();
	}

	public void AddZMult(float amount)
	{
		Ball.s_forwardForce += amount;
		Refresh();
	}
}
