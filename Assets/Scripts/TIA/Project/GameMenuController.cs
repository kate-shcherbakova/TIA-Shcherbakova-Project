using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    public Button easyLevelButton;
    public Button hardLevelButton;
    public Button gameRulesButton;
    public Button exitButton;

    void Start()
    {
        // Привязываем методы к событиям кнопок
        easyLevelButton.onClick.AddListener(OpenEasyLevel);
        hardLevelButton.onClick.AddListener(OpenHardLevel);
        gameRulesButton.onClick.AddListener(OpenGameRules);
        exitButton.onClick.AddListener(ExitGame);
    }

    void OpenEasyLevel()
    {
        // Загружаем сцену EasyLevel
        SceneManager.LoadScene("EasyLevel");
    }

    void OpenHardLevel()
    {
        // Выводим в консоль сообщение
        Debug.Log("Hard level scene should be opened");
    }

    void OpenGameRules()
    {
        // Выводим в консоль сообщение
        Debug.Log("Game rules should be opened");
    }

    void ExitGame()
    {
        // Закрываем приложение
        // Application.Quit();

        // Если вы разрабатываете в редакторе Unity, то Application.Quit() может не сработать.
        // В таком случае, вы можете использовать следующую строку:

        UnityEditor.EditorApplication.isPlaying = false;
    }

}
