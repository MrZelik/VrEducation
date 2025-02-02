using System.Collections;
using TMPro;
using UnityEngine;

public class NetController : MonoBehaviour
{
    [SerializeField] private GameObject mesh;
    [SerializeField] private AnimationCurve takeCurve;
    [SerializeField] private float takeTime;
    [SerializeField] private TextMeshProUGUI butterflyTakesText;
    [SerializeField] private int needButterflys;
    [SerializeField] private AudioClip takeSound;

    private int butterflyTake;

    private bool isFull;

    private AudioSource audioSource;

    private void Start()
    {
        butterflyTakesText.text = butterflyTake + " / " + needButterflys;

        audioSource = GetComponent<AudioSource>();
    }

    public void Take(Vector3 netPos, GameObject butterfly)
    {
        if (isFull)
            return;

        audioSource.PlayOneShot(takeSound);

        transform.position = netPos;
        mesh.SetActive(true);

        StartCoroutine(TakeButterfly(netPos, butterfly));
    }

    private IEnumerator TakeButterfly(Vector3 netPos, GameObject butterfly)
    {
        float progress = 0;

        while(progress < 1f)
        {
            transform.position = netPos;

            transform.eulerAngles = new Vector3(transform.rotation.x, 56f, takeCurve.Evaluate(progress));
            progress += Time.deltaTime / takeTime;

            yield return null;
        }

        Destroy(butterfly);

        mesh.SetActive(false);

        AddButterfly();
    }

    private void AddButterfly()
    {
        butterflyTake++;
        butterflyTakesText.text = butterflyTake + " / " + needButterflys;

        if(butterflyTake == needButterflys)
        {
            isFull = true;
            LevelController.singleton.FinishLevel(true);
        }
    }
}
