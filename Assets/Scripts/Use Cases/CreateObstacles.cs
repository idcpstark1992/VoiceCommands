using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    [SerializeField] private Obstacle[] ObjectsArray;
    private int CurrentIndex;

    private void OnDisable()
    {
        Services.Instance.GetService<IEvents>().RemoveEvent("OnStart", OnStartGame);
        Services.Instance.GetService<IEvents>().RemoveEvent("OnReset", OnStartGame);
    }

    private void Start()
    {
        Services.Instance.GetService<IEvents>().RegisterEvent("OnReset", OnStartGame);
        Services.Instance.GetService<IEvents>().RegisterEvent("OnStart", OnStartGame);
    }

    void OnStartGame()
    {
        CurrentIndex = 0;
        InvokeRepeating("InstantiateObstacles",0, 4f);
    }
    private void InstantiateObstacles()
    {
        if (!SharedStates.isGameOver)
        {
            if (CurrentIndex < ObjectsArray.Length)
            {
                ObjectsArray[CurrentIndex].gameObject.SetActive(true);
                CurrentIndex++;
            }
            else
            {
                CancelInvoke();
            }
        }
        else
        {
            CancelInvoke();
        }
        
        
    }
}
