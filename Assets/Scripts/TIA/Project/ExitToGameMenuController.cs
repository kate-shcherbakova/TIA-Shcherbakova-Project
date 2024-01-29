using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToGameMenuController : MonoBehaviour
{
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
