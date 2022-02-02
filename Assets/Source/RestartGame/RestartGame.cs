using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _loadScreen;

    [SerializeField]
    private Slider _slider;

    private FadeInEffect _fade;

    public void Restart()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        _fade = new FadeInEffect(_loadScreen.GetComponent<Image>());

        _loadScreen.SetActive(true);

        StartCoroutine(Loader(sceneIndex));

    }

    private IEnumerator Loader(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            _slider.value = progress;

            yield return null;
        }

    }
}
