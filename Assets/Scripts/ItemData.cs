using UnityEngine;

public class ItemData
{
    [SerializeField]
    public enum ItemType
    {
        None = 0,
        Item,
        Converter
    }

    public int Index;
    public string Name;
    public ItemType Type;
    public LocationType Location;
    public string Description;
    public string Answer;
    public bool IsAnswer;
    public bool NeedConvert;
    public int Count;
    public Sprite Sprite;
}