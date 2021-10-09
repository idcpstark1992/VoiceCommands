using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
public class Delegates : IEvents
{
   
    private Dictionary<string, UnityEvent> DictionaryHolder = new Dictionary<string, UnityEvent>();

    public List<string> GetEventsKeys()
    {
        List<string> mToreturn = new List<string>();

        foreach (var item in DictionaryHolder.Keys)
        {
            mToreturn.Add(item);
        }
        return mToreturn;
    }

    public void RegisterEvent(string _EventName, UnityAction _ActionToAdd)
    {
        if(DictionaryHolder.TryGetValue(_EventName,out UnityEvent value))
        {
            value.AddListener(_ActionToAdd);
            Debug.Log($"updatedItem  {_ActionToAdd.GetType()}  NAME=   {_EventName}  ");
        }
        else
        {
            UnityEvent MineEvent = new UnityEvent();
            MineEvent.AddListener(_ActionToAdd);
            DictionaryHolder.Add(_EventName, MineEvent);
            Debug.Log($"added Action  {_ActionToAdd.GetType()}  NAME=   {_EventName}  ");
        }
    }

    public void RemoveEvent(string _EventName, UnityAction _ActionToRemove)
    {
        if(DictionaryHolder.TryGetValue(_EventName,out UnityEvent value))
        {
            value.RemoveListener(_ActionToRemove);
        }
        else
        {
            Debug.Log($"Event {_EventName}  Not Found ");
        }
    }

    public void TriggerEvent(string _eventName)
    {
        if (DictionaryHolder.TryGetValue(_eventName, out UnityEvent value))
        {
            value?.Invoke();
        }
    }


}
