using UnityEngine;
using UnityEngine.InputSystem;

public class GlobeRotation : MonoBehaviour
{
    [Header("Velocidade de Rotação")]
    public float rotationSpeed = 10f;

    [Header("Eixo de Rotação")]
    public Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        if (!Mouse.current.leftButton.isPressed)
        {
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        }
    }
}