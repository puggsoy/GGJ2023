using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private Ball m_ballPrefab = null;

	[SerializeField]
	private Transform m_ballLocator = null;

	private void Start()
	{
		SpawnBall();
	}

	private void SpawnBall()
	{
		Ball ball = Instantiate(m_ballPrefab, m_ballLocator.position, Random.rotation);
		ball.OnLaunch += SpawnBall;
	}
}
