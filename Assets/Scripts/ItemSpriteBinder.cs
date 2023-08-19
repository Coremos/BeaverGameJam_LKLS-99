using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteBinder : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    public void Bind(Dictionary<int, ItemData> itemTableDataDic)
    {
        for (int index = 0; index < sprites.Length; index++)
        {
            itemTableDataDic[index].Sprite = sprites[index];
        }
    }
}