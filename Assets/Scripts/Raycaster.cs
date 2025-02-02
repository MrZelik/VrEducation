using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Image filledChoise;
    [SerializeField] private float fillTime;

    private bool nowFilled;

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if(!nowFilled)
                    StartCoroutine(FillChoise(interactable));
            }
            else
            {
                if(nowFilled)
                    StopAllCoroutines();
                filledChoise.fillAmount = 0;
                nowFilled = false;
            }
        }
        else
        {
            if (nowFilled)
                StopAllCoroutines();
            filledChoise.fillAmount = 0;
            nowFilled = false;
        }
    }

    private IEnumerator FillChoise(IInteractable interactable)
    {
        nowFilled = true;

        while(filledChoise.fillAmount < 1)
        {
            filledChoise.fillAmount += Time.deltaTime / fillTime;
            yield return null;
        }

        interactable.Interact();
        nowFilled = false;
    }
}
