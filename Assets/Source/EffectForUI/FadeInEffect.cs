using UnityEngine.UI;
using DG.Tweening;


public class FadeInEffect
{

    private MaskableGraphic _objectforEffect;

    private Tween _fadeTween;

    public float LevelTransparency { get; set; }

    public FadeInEffect(MaskableGraphic canvasGroup)
    {
        _objectforEffect = canvasGroup;
        LevelTransparency = 1f;
    }

    public void FadeIn(float duration)
    {
        Fade(LevelTransparency, duration);
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration);
    }

    private void Fade(float endValue, float duration)
    {
        if (_fadeTween != null)
        {
            _fadeTween.Kill(false);
        }

        _fadeTween = _objectforEffect.DOFade(endValue, duration);
    }
}