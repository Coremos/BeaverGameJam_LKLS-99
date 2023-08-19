using System.Collections.Generic;
using UnityEngine;

public class KeySetting
{
    public Dictionary<KeyType, List<KeyCode>> KeyPairs;

    public KeySetting()
    {
        InitializeKeyPairs();
        SetDefaultKeyPairs();
    }

    private void InitializeKeyPairs()
    {
        KeyPairs = new Dictionary<KeyType, List<KeyCode>>();
        for (int index = 0; index < (int)KeyType.Count; index++)
        {
            KeyPairs.Add((KeyType)index, new List<KeyCode>());
        }
    }

    private void SetDefaultKeyPairs()
    {
        AddKey(KeyType.Up, KeyCode.UpArrow);
        AddKey(KeyType.Down, KeyCode.DownArrow);
        AddKey(KeyType.Left, KeyCode.LeftArrow);
        AddKey(KeyType.Right, KeyCode.RightArrow);
        AddKey(KeyType.Dash, KeyCode.LeftShift);
        AddKey(KeyType.Interaction, KeyCode.Z);
    }

    public void AddKey(KeyType keyType, KeyCode keyCode)
    {
        if (KeyPairs.TryGetValue(keyType, out var list))
        {
            if (list == null) return;
            list.Add(keyCode);
        }
    }
}
