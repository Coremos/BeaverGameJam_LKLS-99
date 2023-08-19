public class KeySettingBinder
{
    public KeySetting Bind(KeySettingProfile profile)
    {
        var setting = new KeySetting();
        setting.AddKey(KeyType.Up, profile.Up);
        setting.AddKey(KeyType.Down, profile.Down);
        setting.AddKey(KeyType.Left, profile.Left);
        setting.AddKey(KeyType.Right, profile.Right);
        setting.AddKey(KeyType.Interaction, profile.Interaction);
        setting.AddKey(KeyType.Dash, profile.Dash);
        return setting;
    }
}