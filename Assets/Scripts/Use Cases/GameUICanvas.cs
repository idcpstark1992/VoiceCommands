using UnityEngine.UI;
using UnityEngine;

public class GameUICanvas : MonoBehaviour
{
    [SerializeField] private Button OnStartButton;
    [SerializeField] private RectTransform InformationHolderTransform;

    private void Start()
    {
        OnStartButton.onClick.AddListener(OnStartGame);
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
        OnStartButton.onClick.RemoveAllListeners();
        OnStartButton.onClick.AddListener(OnResetGame);
        LeanTween.scale(InformationHolderTransform, Vector3.one, .2f).setEaseInCirc();
    }

    public void OnResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}
