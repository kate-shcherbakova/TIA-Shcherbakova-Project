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
        easyLevelButton.onClick.AddListener(() => LoadLevel(false));
        hardLevelButton.onClick.AddListener(() => LoadLevel(true));
        gameRulesButton.onClick.AddListener(OpenGameRules);
        exitButton.onClick.AddListener(ExitGame);
    }

    void LoadLevel(bool isHard)
    {
        // Сохраняем параметр isHard в PlayerPrefs
        PlayerPrefs.SetInt("hard", isHard ? 1 : 0);
        PlayerPrefs.Save();

        // Загружаем сцену Level
        SceneManager.LoadScene("Level");
    }

    void OpenGameRules()
    {
        // Выводим в консоль сообщение
        SceneManager.LoadScene("GameRules");
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