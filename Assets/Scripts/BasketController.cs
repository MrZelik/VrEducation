using System.Collections;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private int needApple;
    [SerializeField] private GameObject[] apples;
    [SerializeField] private GameObject mesh;
    [SerializeField] private HedgehodCommentController commentController;
    [SerializeField] private AudioClip takeAppleSound;
    [SerializeField] private AudioClip takeWrongSound;

    public int appleTaked;

    private bool canTake = true;

    private AudioSource audioSource;

    private void Start()
    {
        appleTaked = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Quaternion rot = camera.rotation;

        rot.x = 0;
        rot.z = 0;

        transform.rotation = rot;
    }

    private void AddApple()
    {
        audioSource.PlayOneShot(takeAppleSound);

        apples[appleTaked].SetActive(true);
        appleTaked++;

        if(appleTaked == needApple)
        {
            canTake = false;
            LevelController.singleton.FinishLevel(false);
        }
    }

    private IEnumerator TempDisable()
    {
        audioSource.PlayOneShot(takeWrongSound);

        canTake = false;

        for(int i = 0; i < 5; i++)
        {
            mesh.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            mesh.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }

        canTake = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canTake)
            return;

        if(other.gameObject.TryGetComponent<DroppedItem>(out DroppedItem item))
        {
            if(item.itemType == DroppedItem.dropItems.apple)
            {
                Destroy(item.gameObject);
                commentController.SayNice();
                AddApple();
            }
            else if (item.itemType == DroppedItem.dropItems.branch || item.itemType == DroppedItem.dropItems.stone)
            {
                Destroy(item.gameObject);
                commentController.SayBad();
                StartCoroutine(TempDisable());
            }
        }
    }
}
