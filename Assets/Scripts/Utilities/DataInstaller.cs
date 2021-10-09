using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInstaller : MonoBehaviour
{
    [SerializeField] private Delegates IDictionarySource;
    private void Awake()
    {
        Services.Instance.RegisterService<IEvents>(new Delegates());
    }
}
