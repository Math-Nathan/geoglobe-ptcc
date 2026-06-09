using UnityEngine;
using UnityEngine.InputSystem;

public class GlobeDrag : MonoBehaviour
{
    public float dragSpeed = 0.5f;
    private Vector2 lastMousePos;
    private bool isDragging = false;

    void Update()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;

        if (mouse.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.GetComponent<CountryObject>() != null)
            {
                isDragging = false;
                return;
            }

            isDragging = true;
            lastMousePos = mouse.position.ReadValue();
        }

        if (mouse.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
        }

        if (isDragging && mouse.leftButton.isPressed)
        {
            Vector2 currentPos = mouse.position.ReadValue();
            Vector2 delta = currentPos - lastMousePos;

            transform.Rotate(Vector3.up, -delta.x * dragSpeed, Space.World);
            transform.Rotate(Vector3.right, delta.y * dragSpeed, Space.World);

            lastMousePos = currentPos;
        }
    }
}