using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawn : MonoBehaviour
{
    public static BottleSpawn instance;

    [SerializeField]
    private float m_spawnDelay = 1;

    public Transform[] SpawnPoints;
    public Transform point;
    public GameObject Prefab;

    private int waitingBottles = 0;

    private float timeSinceLastBottle = 100;

    private void Awake()
    {
        instance = this;
    }

    public void QueueBottle()
    {
        waitingBottles++;
    }

    private void Update()
    {
        if (waitingBottles == 0)
            return;

        timeSinceLastBottle += Time.deltaTime;

        if (timeSinceLastBottle > m_spawnDelay)
        {
            waitingBottles--;
            SpawnBottle();

            timeSinceLastBottle = 0;
        }
	}

	void SpawnBottle()
    {
		int randomIndex = Random.Range(0, SpawnPoints.Length);
		point = SpawnPoints[randomIndex];

		Instantiate(Prefab, point.position, point.rotation);
	}

}
