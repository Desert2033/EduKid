using UnityEngine;

[CreateAssetMenu(fileName = "New Cells", menuName = "ScriptableObject/Cells")]
public class Cells : ScriptableObject
{
    [SerializeField]
    private int _countRows;

    [SerializeField]
    private int _countColumns;

    [SerializeField]
    private Sprite _sprite;

    public int CountRows => _countRows;

    public int CountColumns => _countColumns;

    public Sprite Sprite => _sprite;

}
