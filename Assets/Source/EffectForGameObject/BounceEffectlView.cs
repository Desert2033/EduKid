using UnityEngine;
using DG.Tweening;

public class BounceEffectView : IViewEffects
{ 
    public void MakeEffect(GameObject objectForEffect)
    {
       
        Vector3 rectObjectCellScale = objectForEffect.transform.localScale;
        objectForEffect.transform.DOPunchScale(new Vector2(0.5f, 0.5f), 1);

    }
}
