using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInstaller : MonoBehaviour
{
    [SerializeField] private Delegates IDictionarySource;


    private void Start()
    {
        Services.Instance.RegisterService<IEvents>(IDictionarySource);
    }
}
