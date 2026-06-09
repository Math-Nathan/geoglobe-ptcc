using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalMenager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject painelOpcoes;

   public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenOptions()
    {
        painelMenuPrincipal.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void CloseOptions()
    {
        painelOpcoes.SetActive(false);
        painelMenuPrincipal.SetActive(true);    
    }
}
