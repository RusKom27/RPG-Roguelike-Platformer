using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public float parallaxSpeed;
    private Vector3 lastMouse;

    void Start()
    {
        lastMouse = Input.mousePosition;
    }
    void Update()
    {
        Vector3 delta = Input.mousePosition - lastMouse;
        transform.position += delta * parallaxSpeed;
        lastMouse = Input.mousePosition;
    }

}