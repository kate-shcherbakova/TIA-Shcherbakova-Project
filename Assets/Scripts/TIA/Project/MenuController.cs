using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject[] pages; // Массив страниц
    private int currentPageIndex = 0; // Индекс текущей страницы

    public GameObject yourPipeBoosterPrefab;

    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();

        // Изначально делаем активной только первую страницу
        ShowPage(currentPageIndex);
    }

    public void OnSelectButtonClicked()
    {
        Debug.LogError("Select button triggered");

        // Создаем PipeBooster prefab
        GameObject pipeBooster = Instantiate(yourPipeBoosterPrefab);

        // Получаем ссылку на ImageTargetDrone
        GameObject imageTargetDrone = GameObject.Find("ImageTargetDrone"); // Замените на ваше имя

        // Если нашли ImageTargetDrone, делаем PipeBooster его дочерним объектом
        if (imageTargetDrone != null)
        {
            pipeBooster.transform.parent = imageTargetDrone.transform;
        }
        else
        {
            Debug.LogError("ImageTargetDrone not found!");
        }

        // Устанавливаем позицию перед AR камерой
        float distanceFromCamera = 2.0f; // Замените на ваше значение
        pipeBooster.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;

        // Другие настройки или действия, если необходимо
    }

    public void OnRightArrowButtonClicked()
    {
        // При нажатии кнопки вправо переключаемся на следующую страницу
        currentPageIndex = (currentPageIndex + 1) % pages.Length;
        ShowPage(currentPageIndex);
    }

    public void OnLeftArrowButtonClicked()
    {
        // При нажатии кнопки влево переключаемся на предыдущую страницу
        currentPageIndex = (currentPageIndex - 1 + pages.Length) % pages.Length;
        ShowPage(currentPageIndex);
    }

    private void ShowPage(int pageIndex)
    {
        // Делаем активной только выбранную страницу
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }

}
