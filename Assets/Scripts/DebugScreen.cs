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

	[SerializeField]
	private TextMeshProUGUI m_angularMinText = null;

	[SerializeField]
	private TextMeshProUGUI m_angularMaxText = null;

	[SerializeField]
	private TextMeshProUGUI m_swipeThresholdText = null;

	[SerializeField]
	private TextMeshProUGUI m_yClampText = null;

	private void Awake()
	{
		Refresh();
	}

	private void Refresh()
	{
		m_yMultText.text = Ball.s_upForce.ToString();
		m_zMultText.text = Ball.s_forwardForce.ToString();
		m_angularMinText.text = Ball.s_angularMin.ToString();
		m_angularMaxText.text = Ball.s_angularMax.ToString();
		m_swipeThresholdText.text = Ball.s_swipeThreshold.ToString();
		m_yClampText.text = Ball.s_upClamp.ToString();
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

	public void AddAngularMin(float amount)
	{
		Ball.s_angularMin += amount;
		Refresh();
	}

	public void AddAngularMax(float amount)
	{
		Ball.s_angularMax += amount;
		Refresh();
	}

	public void AddSwipeThreshold(float amount)
	{
		Ball.s_swipeThreshold += amount;
		Refresh();
	}

	public void AddYClamp(float amount)
	{
		Ball.s_upClamp += amount;
		Refresh();
	}
}
