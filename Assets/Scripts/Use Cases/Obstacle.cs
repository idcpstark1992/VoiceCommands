using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody RbObject;
    [SerializeField] private float MaximunPosition;
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 InitialPosition;
    [SerializeField] private Vector3 AxisSlide;
    private bool GameOver;
    private void Start()
    {
        RbObject = GetComponent<Rigidbody>();
        AxisSlide = Vector3.left;
        Services.Instance.GetService<IEvents>().RegisterEvent("OnReset",OnResetScene);
        Services.Instance.GetService<IEvents>().RegisterEvent("OnGameOver", OnGameOver);
    }
    private void OnDisable()
    {
        Services.Instance.GetService<IEvents>().RemoveEvent("OnReset", OnResetScene);
        Services.Instance.GetService<IEvents>().RemoveEvent("OnGameOver", OnGameOver);
    }
    private void OnEnable()
    {
        InitialPosition = gameObject.transform.position;
    }
    private void FixedUpdate()
    {
        if (!GameOver)
        {
            RbObject.MovePosition(AxisSlide * Speed + RbObject.position);
            if (RbObject.position.x < MaximunPosition)
            {
                ReturnToPosition();
            }
        }
    }
    private void ReturnToPosition()
    {
        int RandomNumber = Random.Range(0, 2);
        RbObject.transform.position = RandomNumber == 0 ? InitialPosition : new Vector3(InitialPosition.x,2,InitialPosition.z);
    }
    private void OnResetScene()
    {
        GameOver = false;
        ReturnToPosition();
        gameObject.SetActive(false);
    }
    private void OnGameOver()
    {
        GameOver = true;
    }

}
    
