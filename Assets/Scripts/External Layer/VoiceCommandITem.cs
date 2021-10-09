using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceCommandITem : MonoBehaviour
{
    [SerializeField] private string CommandString;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float JumpImpulse;
    [SerializeField] private GameObject PlayerNeck;
    [SerializeField] private Vector3 FinalNeckPosition;
    private Dictionary<string, UnityEngine.Events.UnityAction> InnerActionsPlayer = new Dictionary<string, UnityEngine.Events.UnityAction>();
    private void Awake()
    {

        InnerActionsPlayer.Add("Arriba", OnUpEvent);
        InnerActionsPlayer.Add("Abajo",  OnDownEvent);

        foreach (var item in InnerActionsPlayer)
        {
            Services.Instance.GetService<IEvents>().RegisterEvent(item.Key, item.Value);
        }


        rb = GetComponent<Rigidbody>();
    }
    private void OnDisable()
    {
        foreach (var item in InnerActionsPlayer)
        {
            Services.Instance.GetService<IEvents>().RemoveEvent(item.Key, item.Value);
        }
    }
    public void OnUpEvent()
    {
        rb.AddForce(Vector3.up * JumpImpulse, ForceMode.Impulse);
    }
    public void OnDownEvent()
    {
        LeanTween.moveLocal(PlayerNeck, Vector3.up * .8f, .2f).setOnComplete(RestoreNeckPosition);
    }
    private void RestoreNeckPosition()
    {
        LeanTween.moveLocal(PlayerNeck, Vector3.up * 1.5f, .5f);
    }
}
