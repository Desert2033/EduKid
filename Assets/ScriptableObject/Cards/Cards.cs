using UnityEngine;

[CreateAssetMenu(fileName = "New Cards", menuName = "ScriptableObject/Cards")]
public class Cards : ScriptableObject
{
    [SerializeField]
    private CardData[] _card;

    public CardData[] Card => _card;

    public int id;
}
