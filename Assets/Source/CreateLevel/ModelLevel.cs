using UnityEngine;
using UnityEngine.Events;


public class ModelLevel : MonoBehaviour
{

    [SerializeField]
    private Cells[] _cells;

    [SerializeField]
    private Cards[] _cards;

    private Cells _currentCells;

    private CardData[] _currentCards;

    private int _levelIterator = 0;

    [SerializeField]
    private UnityEvent endGame;

    public Cells CurrentCells => _currentCells;

    public CardData[] CurrentCards => _currentCards;

    private void Awake()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        if (_levelIterator < _cells.Length)
        {
            RandomWithOutRepeat random = new RandomWithOutRepeat();
            _currentCells = _cells[_levelIterator];

            int countCards = _currentCells.CountColumns * _currentCells.CountRows;
            CardData[] cardData = _cards[Random.Range(0, _cards.Length)].Card;
            _currentCards = new CardData[countCards];
            for (int index = 0; index < countCards; index++)
            {
                _currentCards.SetValue(cardData[random.GetRandom(0, cardData.Length - 1)], index);
            }

            _levelIterator++;
        }
        else
        {
            _currentCells = null;
            endGame.Invoke();
        }
    }

}
