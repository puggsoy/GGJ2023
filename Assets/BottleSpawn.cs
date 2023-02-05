using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawn : MonoBehaviour
{
    public static BottleSpawn instance;

    public Transform[] SpawnPoints;
    public Transform point;
    public GameObject Prefab;


    private void Awake()
    {
        instance = this;
    }

    public void SpawnBottle()
    {
        StartCoroutine(Wait());

        int randomIndex = Random.Range(0, SpawnPoints.Length);
        point = SpawnPoints[randomIndex];

        Instantiate(Prefab, point.position, point.rotation);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

}
