using System.Collections;
using UnityEngine;

public class LampDependentParticls : MonoBehaviour, IDependent
{
    [SerializeField] private GameObject[] particles;
    [SerializeField] private float timePerActive;

    public void StartAction(LampController lamp)
    {
        StartCoroutine(StartActionCur());
    }

    private IEnumerator StartActionCur()
    {
        foreach (var particle in particles)
        {
            particle.SetActive(true);

            yield return new WaitForSeconds(timePerActive);
        }
    }
}
