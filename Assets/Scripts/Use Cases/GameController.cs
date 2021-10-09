using UnityEngine;

public  class  GameController : MonoBehaviour
{
    public void OnGameOver()
    {
        SharedStates.isGameOver = true;
    }
    public void OnStartAndRestartGame()
    {
        SharedStates.isGameOver = false;
    }
    private void Start()
    {
        Services.Instance.GetService<IEvents>().RegisterEvent("OnReset", OnStartAndRestartGame);
        Services.Instance.GetService<IEvents>().RegisterEvent("OnGameOver", OnGameOver);
    }
    private void OnDisable()
    {
        Services.Instance.GetService<IEvents>().RemoveEvent("OnReset", OnStartAndRestartGame);
        Services.Instance.GetService<IEvents>().RemoveEvent("OnGameOver", OnGameOver);
    }
}
