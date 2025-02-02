using UnityEngine;

public class LampDependentAnimation : MonoBehaviour, IDependent
{
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;

    public void StartAction(LampController lamp)
    {
        animator.Play(animationName);
    }
}
