using UnityEngine;

[CreateAssetMenu(fileName = "KeyProfile.asset", menuName = "ScriptableObject/KeyProfile", order = int.MinValue)]
public class KeySettingProfile : ScriptableObject
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Dash;
    public KeyCode Interaction;
}