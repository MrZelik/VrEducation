using UnityEngine;

public class LevelChosieButton : MonoBehaviour, IInteractable
{
    [SerializeField] private string levelName;

    private bool active = false;

    public void Interact()
    {
        if (active)
            return;

        active = true;
        LevelController.singleton.StartLevel(levelName);
    }
}
