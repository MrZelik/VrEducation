using System.Collections;
using UnityEngine;

public class DroppedItemController : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private float spawnTime;
    [SerializeField] private DroppedItem itemPrefab;
    [SerializeField] private Transform initialPos;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(spawnTime);

        int itemType = Random.Range(0, 3);

        DroppedItem newItem = Instantiate(itemPrefab, initialPos);

        if(itemType == 0)
        {
            newItem.itemType = DroppedItem.dropItems.apple;
        }
        else if(itemType == 1)
        {
            newItem.itemType = DroppedItem.dropItems.branch;
        }
        else if (itemType == 2)
        {
            newItem.itemType = DroppedItem.dropItems.stone;
        }

        newItem.SetGO();

        newItem.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].position;

        StartCoroutine(Spawner());
    }
}
