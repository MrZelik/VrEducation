using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] butterflyPrefabs;
    [SerializeField] private int maxButterflys;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timePerSpawn;
    [SerializeField] private NetController netController;

    public List<GameObject> butterflys = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(InitialSpawn());
    }

    private void Update()
    {
        for (int i = 0; i < butterflys.Count; i++)
        {
            if(butterflys[i] == null)
            {
                GameObject butterfly = Instantiate(butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)]);
                butterfly.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                butterfly.GetComponentInChildren<ButterflyMoveController>().netController = netController;

                butterflys[i] = butterfly;
            }
        }
    }

    private IEnumerator InitialSpawn()
    {
        for (int i = 0; i < maxButterflys; i++)
        {
            GameObject butterfly = Instantiate(butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)]);
            butterfly.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            butterfly.GetComponentInChildren<ButterflyMoveController>().netController = netController;

            butterflys.Add(butterfly);
            yield return new WaitForSeconds(timePerSpawn);
        }
    }
}
