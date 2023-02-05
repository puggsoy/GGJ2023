using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private Ball m_ballPrefab = null;

	[SerializeField]
	private Transform m_ballLocator = null;

	[SerializeField]
	private int m_maxBalls = 10;

	private List<Ball> m_balls = new List<Ball>();

	private void Start()
	{
		SpawnBall();
	}

	private void SpawnBall()
	{
		Ball ball = Instantiate(m_ballPrefab, m_ballLocator.position, Random.rotation);
		ball.OnLaunch += SpawnBall;
		m_balls.Add(ball);

		if (m_balls.Count > m_maxBalls)
		{
			m_balls[0].Shrink();
			m_balls.RemoveAt(0);
		}
	}
}
