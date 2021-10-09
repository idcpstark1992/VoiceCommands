using UnityEngine.UI;
using UnityEngine;

public class GameUICanvas : MonoBehaviour
{
    [SerializeField] private Button OnStartButton;
    [SerializeField] private Button OnResetButton;
    [SerializeField] private RectTransform InformationHolderTransform;
    [SerializeField] private RectTransform ResetInformationTransform;

    private void Start()
    {
        OnStartButton.onClick.AddListener(OnStartGame);
        OnResetButton.onClick.AddListener(OnReset);
        Services.Instance.GetService<IEvents>().RegisterEvent("OnGameOver", OnGameOver);

    }
    private void OnDisable()
    {
        Services.Instance.GetService<IEvents>().RemoveEvent("OnGameOver", OnGameOver);
    }

    public void OnStartGame()
    {
        Services.Instance.GetService<IEvents>().TriggerEvent("OnStart");
        LeanTween.scale(InformationHolderTransform, Vector3.zero, .2f).setEaseOutCirc();
    }

    public void OnGameOver()
    {
        LeanTween.scale(ResetInformationTransform, Vector3.one, .2f).setEaseInCirc();
    }
    public void OnReset()
    {
        LeanTween.scale(ResetInformationTransform, Vector3.zero, .2f).setEaseOutCirc();
        Services.Instance.GetService<IEvents>().TriggerEvent("OnReset");
    }

}
