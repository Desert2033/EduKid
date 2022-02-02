using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    [SerializeField]
    private ModelLevel _modelLevel;

    private RandomWithOutRepeat random = new RandomWithOutRepeat();

    private FadeInEffect _fade;

    private string _task;

    [SerializeField]
    private UnityEvent OnTrueAnswer;

    void Start()
    {
        MakeTask();

        _fade = new FadeInEffect(transform.GetComponentInParent<Text>());

        StartCoroutine(FadeStart());

    }

    public void MakeTask()
    {
        int rundomNUmber = random.GetRandom(0, _modelLevel.CurrentCards.Length);
        _task = _modelLevel.CurrentCards[rundomNUmber].Identity;

        RenderTask();
    }

    public void checkEventChooseCard(string identity)
    {
        if (identity == _task)
        {
            _modelLevel.GenerateLevel();
            
            GameObject findCell = GameObject.Find("Cell_" + identity);
            findCell.GetComponent<CellElement>().BounceEffectAndParticls();

            if (_modelLevel.CurrentCells != null) 
            {
                StartCoroutine(EventTrueAnswer(identity));                
            }
            
        }
        else
        {
            GameObject findCell = GameObject.Find("Cell_" + identity);
            findCell.GetComponent<CellElement>().EaseInBounce(); 
        }
    }

    private void RenderTask()
    {

        transform.GetComponent<Text>().text = "Find " + _task;
    }

    private IEnumerator EventTrueAnswer(string identity)
    {

        yield return new WaitForSeconds(1f);

        OnTrueAnswer?.Invoke();
        MakeTask();

    }
    private IEnumerator FadeStart()
    {
        _fade.FadeOut(0f);

        yield return new WaitForSeconds(0.5f);

        _fade.FadeIn(1f);
    }
}