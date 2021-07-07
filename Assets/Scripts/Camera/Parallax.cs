using UnityEngine;

public class Parallax : MonoBehaviour
{
    public bool parallax;
    public float parallaxSpeed;

    private GameObject mainCamera;
    private Transform MainCameraTransform;
    private float lastCameraX;

    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        MainCameraTransform = mainCamera.GetComponent<Transform>();
    }
    void Start()
    {
        lastCameraX = MainCameraTransform.position.x;
        MainCameraTransform = Camera.main.transform;
    }
    void Update()
    {
        if (parallax) 
        { 
            float deltaX = MainCameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCameraX = MainCameraTransform.position.x;
    }
}