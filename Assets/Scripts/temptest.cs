using UnityEngine;
using UnityEngine.InputSystem;

public class DebugClick : MonoBehaviour
{
    void Update()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;

        if (mouse.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Acertou: " + hit.collider.gameObject.name);
                Debug.Log("Tem CountryObject: " + (hit.collider.GetComponent<CountryObject>() != null));
                Debug.Log("Layer: " + hit.collider.gameObject.layer);
            }
            else
            {
                Debug.Log("Raycast não acertou nada");
            }
        }
    }
}