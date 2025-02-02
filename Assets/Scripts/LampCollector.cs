using System.Collections;
using TMPro;
using UnityEngine;

public class LampCollector : MonoBehaviour
{
    [SerializeField] private LampController[] lamps;

    private bool needCuclulate = true;

    private bool allActive = false;

    private void Update()
    {
        if (allActive)
            return;

        foreach (LampController lamp in lamps)
        {
            if (lamp.nowActive)
            {
                allActive = true;
            }
            else if (!lamp.nowActive)
            {
                allActive = false;
                return;
            }
        }

        if(allActive)
        {
            LevelController.singleton.FinishLevel(false);
        }
    }
}
