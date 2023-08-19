using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private KeySettingProfile defaultProfile;

    private IInputHandler inputHandler;
    private KeySetting keySetting;

    private void Awake()
    {
        BindingKey(defaultProfile);
#if PLATFORM_STANDALONE_WIN
        inputHandler = new PCInputHandler();
#elif UNITY_ANDROID || UNITY_IOS
        inputHandler = new MobileInputHandler();
#endif
    }

    private void Update()
    {
        inputHandler.Update();
        UpdateKey();
    }

    private void UpdateKey()
    {
        foreach (var keyPair in keySetting.KeyPairs)
        {
            foreach (var keyCode in keyPair.Value)
            {
                if (Input.GetKey(keyCode))
                {
                    inputHandler.ExecuteCommand(keyPair.Key);
                }
            }
        }
    }

    private void BindingKey(KeySettingProfile profile)
    {
        var keySettingBinder = new KeySettingBinder();
        keySetting = keySettingBinder.Bind(profile);
    }
}