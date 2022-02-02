using System.Collections.Generic;
using UnityEngine;

public class FieldRender : MonoBehaviour
{

    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private ModelLevel _modelLevel;

    private List<GameObject> _listCellsOnScene;

    private IViewEffects _viewEffects;

    void Start()
    {
        _viewEffects = new BounceEffectView();
        _listCellsOnScene = new List<GameObject>();
        MakeGrid();
    }


    private void MakeGrid()
    {

        int rows = _modelLevel.CurrentCells.CountRows;

        int columns = _modelLevel.CurrentCells.CountColumns;

        CardData[] cards = _modelLevel.CurrentCards;

        float x = -3;

        float y = 2.5f;

        float spacing = 3;

        Vector3 newPosition = new Vector3();

        for (int indexRow = 0, indexCards = 0; indexRow < rows; indexRow++)
        {
            for (int indexColumn = 0; indexColumn < columns; indexColumn++, indexCards++)
            {
                
                GameObject newCellPrefab = Instantiate(_prefab);
                newCellPrefab.name = "Cell_" + cards[indexCards].Identity;
                _listCellsOnScene.Add(newCellPrefab);
                Transform prefabChild = newCellPrefab.transform.GetChild(0);
                prefabChild.GetComponent<SpriteRenderer>().sprite = cards[indexCards].Sprite;
                newCellPrefab.GetComponent<CellElement>().Identity = cards[indexCards].Identity;


                newPosition.Set(x, y, 0);
                newCellPrefab.transform.position = newPosition;

                _viewEffects.MakeEffect(newCellPrefab);
                x += spacing;

            }

            x = -3;
            y -= spacing;
        }

    }

    public void RedrawGrid()
    {
        foreach(GameObject cell in _listCellsOnScene)
        {
           Destroy(cell);
        }
        _listCellsOnScene.Clear();
        _viewEffects = new NoneEffectView();
        MakeGrid(); 
    }

    public void BlockAllGrid()
    {
        int ignoreRaycast = 2;
        foreach (GameObject cell in _listCellsOnScene)
        {
            cell.layer = ignoreRaycast;
        }
    }

}
