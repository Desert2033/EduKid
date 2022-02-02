using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _restartButton;

    [SerializeField]
    private GameObject _transparentDark;

    private FadeInEffect _fadeForBatton;

    private FadeInEffect _fadeForImage;

    public void DrawRestartMenu()
    {
        _restartButton.SetActive(true);
        _transparentDark.SetActive(true);
        _fadeForBatton = new FadeInEffect(_restartButton.GetComponent<Image>());
        _fadeForImage = new FadeInEffect(_transparentDark.GetComponent<Image>());
        _fadeForImage.LevelTransparency = 0.5f;
        StartCoroutine(FadeEffect());
    }

    private IEnumerator FadeEffect()
    {
        _fadeForBatton.FadeOut(0f);
        _fadeForImage.FadeOut(0f);

        yield return new WaitForSeconds(0.5f);

        _fadeForBatton.FadeIn(1f);
        _fadeForImage.FadeIn(1f);
    }
}
