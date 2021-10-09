using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Services.Instance.GetService<IEvents>().TriggerEvent("OnGameOver");
    }
}
