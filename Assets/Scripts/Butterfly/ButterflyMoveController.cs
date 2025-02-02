using System.Collections;
using UnityEngine;

public class ButterflyMoveController : MonoBehaviour, IInteractable
{
    public Transform netPos;
    public NetController netController;

    public bool active = false;

    public void Interact()
    {
        if (active)
            return;

        active = true;
        netController.Take(netPos.position, transform.parent.gameObject);
    }
}
