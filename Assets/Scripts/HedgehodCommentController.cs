using System.Collections;
using TMPro;
using UnityEngine;

public class HedgehodCommentController : MonoBehaviour
{
    [SerializeField] private string[] niceComments;
    [SerializeField] private string[] badComments;
    [SerializeField] private GameObject commentPanel;
    [SerializeField] protected TextMeshProUGUI commentText;

    public void SayNice()
    {
        StopAllCoroutines();

        string text = niceComments[Random.Range(0, niceComments.Length)];

        commentText.text = text;
        commentPanel.SetActive(true);

        StartCoroutine(CloseTextPanel());
    }

    public void SayBad()
    {
        StopAllCoroutines();

        string text = badComments[Random.Range(0, badComments.Length)];

        commentText.text = text;
        commentPanel.SetActive(true);

        StartCoroutine(CloseTextPanel());
    }

    private IEnumerator CloseTextPanel()
    {
        yield return new WaitForSeconds(3f);

        commentPanel.SetActive(false);
    }
}
