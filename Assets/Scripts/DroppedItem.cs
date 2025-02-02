using System;
using System.Collections;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    [SerializeField] private GameObject appleGO;
    [SerializeField] private GameObject branchGO;
    [SerializeField] private GameObject stoneGO;
    [SerializeField] private float dropTime;
    [SerializeField] private float timeToDestroy;

    public dropItems itemType;

    private bool fall;

    public enum dropItems
    {
        apple,
        branch,
        stone
    }

    private void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    private void Update()
    {
        if (!fall)
            return;

        Vector3 pos = transform.position;
        pos = Vector3.Lerp(pos, new Vector3(pos.x, -1.7f, pos.z), dropTime);
        transform.position = pos;
    }

    public void SetGO()
    {
        if (itemType == dropItems.apple)
        {
            appleGO.SetActive(true);
        }
        else if (itemType == dropItems.branch)
        {
            branchGO.SetActive(true);
        }
        else if (itemType == dropItems.stone)
        {
            stoneGO.SetActive(true);
        }

        fall = true;
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
