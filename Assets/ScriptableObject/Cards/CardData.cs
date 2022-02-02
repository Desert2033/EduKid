using UnityEngine;
using System;

[Serializable]
public class CardData
{
    [SerializeField]
    private string _identity;

    [SerializeField]
    private Sprite _sprite;

    public string Identity => _identity;

    public Sprite Sprite => _sprite;
}
