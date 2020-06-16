using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Play()
    {
        SceneManager.LoadScene("mainGame");
    }

    public void Controls()
    {
        _panel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
