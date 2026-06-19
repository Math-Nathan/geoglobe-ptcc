using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobeManager : MonoBehaviour
{
    public static GlobeManager Instance;

    [Header("Referências")]
    public GlobeRotation globeRotation;
    public GlobeDrag globeDrag;
    public CountryPanelUI panel;

    private CountryObject selectedCountry;
    private GameObject currentMesh;

    [SerializeField] private string sceneName;
    [SerializeField] private GameObject panelMenu;
    void Awake()
    {
        Instance = this;
        panelMenu.SetActive(true);
    }
    public void Voltar()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SelectCountry(CountryObject country)
    {
        // Para a rotação
        globeRotation.enabled = false;
        globeDrag.enabled = false;

        // Remove mesh anterior se houver
        if (currentMesh != null)
            Destroy(currentMesh);

        // Instancia o mesh 3D do país
        if (country.data.countryMeshPrefab != null)
        {
            currentMesh = Instantiate(
                country.data.countryMeshPrefab,
                Vector3.zero,
                Quaternion.identity
            );
        }

        // Abre o painel com as informações
        panel.Show(country.data);

        selectedCountry = country;
    }

    public void Deselect()
    {
        // Retoma a rotação
        globeRotation.enabled = true;
        globeDrag.enabled = true;

        // Remove o mesh do país
        if (currentMesh != null)
            Destroy(currentMesh);

        // Fecha o painel
        panel.Hide();

        selectedCountry = null;
    }
}