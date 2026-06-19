using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountryPanelUI : MonoBehaviour
{
    [Header("Elementos UI")]
    public GameObject panelRoot;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI capitalText;
    public TextMeshProUGUI populationText;
    public TextMeshProUGUI areaText;
    public TextMeshProUGUI continentText;
    public TextMeshProUGUI curiosityText;
    public Image flagImage;
    public Button closeButton;

    private RectTransform rect;
    private float panelWidth;
    
    void Start()
    {
        rect = panelRoot.GetComponent<RectTransform>();
        panelWidth = rect.rect.width;
        closeButton.onClick.AddListener(GlobeManager.Instance.Deselect);
        panelRoot.SetActive(false);
        
    }

    public void Show(CountryData data)
    {
        panelRoot.SetActive(true);
        nameText.text = data.countryName;
        capitalText.text = " Capital: " + data.capital;
        populationText.text = " População: " + data.population;
        areaText.text = " Área: " + data.area + " km²";
        continentText.text = " Continente: " + data.continent;
        curiosityText.text = data.curiosity;

        if (data.flag != null)
            flagImage.material = data.flag;

        StopAllCoroutines();
        StartCoroutine(SlideIn());
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(SlideOut());
    }

    IEnumerator SlideIn()
    {
        float duration = 0.3f;
        float elapsed = 0f;
        Vector2 start = new Vector2(panelWidth, rect.anchoredPosition.y);
        Vector2 end = new Vector2(-195f, rect.anchoredPosition.y);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);
            rect.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }

        rect.anchoredPosition = end;
    }

    IEnumerator SlideOut()
    {
        float duration = 0.2f;
        float elapsed = 0f;
        Vector2 start = rect.anchoredPosition;
        Vector2 end = new Vector2(panelWidth, rect.anchoredPosition.y);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);
            rect.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }

        panelRoot.SetActive(false);
    }
}