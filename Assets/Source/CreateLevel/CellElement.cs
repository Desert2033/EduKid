using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;

public class CellElement : MonoBehaviour
{

    private Task _task;

    [SerializeField]
    private GameObject _particlePrefab;

    [SerializeField]
    private OnClickCell onClickCell;

    private IViewEffects _bounceEffect;

    private ParticleSystem _particle;

    public string Identity { get; set; }

    private void Start()
    {
        _bounceEffect = new BounceEffectView();
        _task = GameObject.Find("Task").GetComponent<Task>();
        onClickCell.AddListener(_task.checkEventChooseCard);

        _particle = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    private void OnMouseDown()
    {
        onClickCell?.Invoke(Identity);
    }

    public void EaseInBounce()
    {
        Transform transformChild = transform.GetChild(0);

        Vector3 mainTransformChildPsition = transformChild.position;

        if (DOTween.PlayingTweens() == null)
        {
            transformChild.DOShakePosition(1, new Vector3(0.2f, 0))
                    .OnComplete(() =>
                    {
                        transformChild
                            .DOMoveX(mainTransformChildPsition.x, 0.1f)
                            .SetEase(Ease.InBounce);
                    }).SetAutoKill(true);
        }
       
    }

    public void BounceEffectAndParticls()
    {

        Transform card = transform.GetChild(0);

        _bounceEffect.MakeEffect(card.gameObject);

        _particle.Play();

    }

}

[System.Serializable]
public class OnClickCell : UnityEvent<string> { }