using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToGameMenuController : MonoBehaviour
{
    public Button stopButton;

    void Start()
    {
        stopButton.onClick.AddListener(ExitToMainMenu);
    }

    void ExitToMainMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
