using System.Collections;
using UnityEngine;

public class LampController : MonoBehaviour, IInteractable
{
    [SerializeField] private Light light;
    [SerializeField] private AnimationCurve activeCurve;
    [SerializeField] private AnimationCurve flickerCurve;
    [SerializeField] private float activeTime;
    [SerializeField] private bool needFlicker;
    [SerializeField] private bool needDependent;
    [SerializeField] private GameObject dependent;
    [SerializeField] private AudioClip activeSound;

    AudioSource audioSource;

    public bool nowActive = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        if (nowActive)
            return;

        nowActive = true;
        light.gameObject.SetActive(true);

        audioSource.PlayOneShot(activeSound);

        StartCoroutine(TurnOnLight());
    }

    private IEnumerator TurnOnLight()
    {
        if (needDependent)
            dependent.GetComponent<IDependent>().StartAction(this);

        float progress = 0f;

        while(progress < 1)
        {
            light.intensity = activeCurve.Evaluate(progress);
            progress += Time.deltaTime / activeTime;
            yield return null;
        }

        if(needFlicker)
            StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        float progress = 0f;

        while (progress < 1)
        {
            light.intensity = flickerCurve.Evaluate(progress);
            progress += Time.deltaTime / 2;
            yield return null;
        }

        StartCoroutine(Flicker());
    }
}
