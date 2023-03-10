using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	[SerializeField]
	private TextMeshProUGUI m_speedClampText = null;

	[SerializeField]
	private TextMeshProUGUI m_lastSpeedText = null;

	private void Awake()
	{
		gameObject.SetActive(false);
	}

	private void OnEnable()
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
		m_speedClampText.text = Ball.s_speedClamp.ToString();
		m_lastSpeedText.text = string.Format("Last speed: {0}", Ball.s_lastSpeed.ToString());
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

	public void AddSpeedClamp(float amount)
	{
		Ball.s_speedClamp += amount;
		Refresh();
	}

	public void Reset()
	{
		SceneManager.LoadScene("GameScene");
	}
}
