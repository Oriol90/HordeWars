using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 30f;

    private Vector3 dragOrigin;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleKeyboardMovement();
        HandleMouseDrag();
        HandleZoom();
    }

    void HandleKeyboardMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D o Flechas
        float moveY = Input.GetAxis("Vertical");   // W/S o Flechas

        Vector3 move = new Vector3(moveX, moveY, 0f);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(2)) // Botón central del ratón
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position += difference;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= scroll * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
    }
}
