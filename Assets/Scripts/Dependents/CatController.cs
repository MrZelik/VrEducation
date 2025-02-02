using UnityEngine;
using DG.Tweening;

public class CatController : MonoBehaviour, IDependent
{
    [SerializeField] private LampController leftLamp;
    [SerializeField] private LampController rightLamp;
    [SerializeField] private Transform cat;

    [SerializeField] private string goLeftAnimName;
    [SerializeField] private string goRightAnimName;
    [SerializeField] private string goSecondLeftAnimName;
    [SerializeField] private string goSecondRightAnimName;

    private LampController firtActiveLamp;

    public Animator catAnimator;

    public void StartAction(LampController lamp)
    {
        if(firtActiveLamp == null)
        {
            if (lamp == rightLamp)
            {
                firtActiveLamp = rightLamp;
                GoToFirstLamp();
            }
            else
            {
                firtActiveLamp = leftLamp;
                GoToFirstLamp();
            }
        }
        else
        {
            GoToSecondLamp();
        }
    }


    public void GoToFirstLamp()
    {
        Sequence toFirtsLampAnim = DOTween.Sequence();

        if(firtActiveLamp == rightLamp)
        {
            catAnimator.SetBool("Jump", true);
            catAnimator.SetBool("Walk", false);
            catAnimator.SetBool("Idle", false);
            toFirtsLampAnim
                .Append(cat.DOLocalJump(new Vector3(0.8f, -0.35f, 0f), 0.3f, 1, 0.5f)
                .SetEase(Ease.Linear)
                .OnComplete(() => catAnimator.SetBool("Walk", true)))
                .OnComplete(() => catAnimator.SetBool("Jump", false))
                .Append(cat.DOLocalMove(new Vector3(0.9f, -0.35f, 1.3f), 4f)
                .SetEase(Ease.Linear))
                .Join(cat.DOLocalRotate(new Vector3(0f, 3.8f, 0f), 1f))
                .Append(cat.DOLocalRotate(new Vector3(0f, 125f, 0f), 1f))
                .OnComplete(() => catAnimator.SetBool("Idle", true))
                .OnComplete(() => catAnimator.SetBool("Jump", false))
                .OnComplete(() => catAnimator.SetBool("Walk", false));
        }
        else
        {
            catAnimator.SetBool("Jump", true);
            catAnimator.SetBool("Walk", false);
            catAnimator.SetBool("Idle", false);
            toFirtsLampAnim
                .Append(cat.DOLocalJump(new Vector3(0.8f, -0.35f, 0f), 0.3f, 1, 0.5f)
                .SetEase(Ease.Linear)
                .OnComplete(() => catAnimator.SetBool("Walk", true)))
                .OnComplete(() => catAnimator.SetBool("Jump", false))
                .OnComplete(() => catAnimator.SetBool("Idle", false))
                .Append(cat.DOLocalMove(new Vector3(0.0f, -0.35f, -1.7f), 4f)
                .SetEase(Ease.Linear))
                .Join(cat.DOLocalRotate(new Vector3(0f, 200f, 0f), 1f))
                .Append(cat.DOLocalRotate(new Vector3(0f, 115f, 0f), 1f))
                .OnComplete(() => catAnimator.SetBool("Idle", true))
                .OnComplete(() => catAnimator.SetBool("Jump", false))
                .OnComplete(() => catAnimator.SetBool("Walk", false));
        }
    }

    public void GoToSecondLamp()
    {
        Sequence toSecondLampAnim = DOTween.Sequence();

        if (firtActiveLamp == rightLamp)
        {
            catAnimator.SetBool("Walk", true);
            catAnimator.SetBool("Idle", false);

            toSecondLampAnim
                 .Append(cat.DOLocalMove(new Vector3(0f, -0.35f, -1.7f), 5f)
                 .SetEase(Ease.Linear))
                 .Join(cat.DOLocalRotate(new Vector3(0f, 200f, 0f), 1f))
                 .Append(cat.DOLocalRotate(new Vector3(0f, 115f, 0f), 1f))
                 .OnComplete(() => catAnimator.SetBool("Idle", true))
                 .OnComplete(() => catAnimator.SetBool("Walk", false));
        }
        else
        {
            catAnimator.SetBool("Walk", true);
            catAnimator.SetBool("Idle", false);

            toSecondLampAnim
                 .Append(cat.DOLocalMove(new Vector3(0.9f, -0.35f, 1.3f), 4f)
                 .SetEase(Ease.Linear))
                 .Join(cat.DOLocalRotate(new Vector3(0f, 3.8f, 0f), 1f))
                 .Append(cat.DOLocalRotate(new Vector3(0f, 125f, 0f), 1f))
                 .OnComplete(() => catAnimator.SetBool("Idle", true))
                 .OnComplete(() => catAnimator.SetBool("Walk", false));
        }
    }
}
