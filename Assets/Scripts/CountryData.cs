using UnityEngine;

[CreateAssetMenu(fileName = "NewCountry", menuName = "GeoGlobe/Country")]
public class CountryData : ScriptableObject
{
    public string countryName;
    public string capital;
    public string population;
    public string area;
    public string continent;
    [TextArea] public string curiosity;
    public Material flag;
    public GameObject countryMeshPrefab; // mesh 3D do país
}