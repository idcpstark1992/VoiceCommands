using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public interface IEvents
{
    void RegisterEvent(string _EventName ,UnityAction _ActionToAdd);
    void RemoveEvent(string _EventName, UnityAction _ActionToRemove);
    void TriggerEvent(string _eventName);
}