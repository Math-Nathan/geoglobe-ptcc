using UnityEngine;
using UnityEngine.InputSystem;

public class CountryObject : MonoBehaviour
{
    public CountryData data;

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
                // Verifica se o clique foi neste objeto específico
                if (hit.collider.gameObject == gameObject)
                {
                    GlobeManager.Instance.SelectCountry(this);
                }
            }
        }
    }
}