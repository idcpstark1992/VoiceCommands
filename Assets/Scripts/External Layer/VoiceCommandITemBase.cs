using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class VoiceCommandITemBase : MonoBehaviour , IVoiceCommand
{

    [SerializeField] private string EventName;
    private UnityAction HolderAction;
    public virtual void OnExecution()
    {
        HolderAction?.Invoke();
    }
    public void AddCommandToExecute (UnityAction unityEvent)
    {
        HolderAction = unityEvent;
    }


}
