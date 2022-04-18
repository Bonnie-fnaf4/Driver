using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Panel, Win, Lost; //переменные для панели

    public Transform Car; //Переменная для проверки координат машины

    public void Start()
    {
        Time.timeScale = 1; //устанавливаем нормальное время
    }

    public void Update()
    {
        if(Car.position.y < -5) //Если машина улетела за карту и падает вниз то она проиграла
        {
            Red();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Red") //Если машина коснулась красного объекта то она проиграла
        {
            Red();
        }

        if (other.gameObject.tag == "Green") //Если машина коснулась зелённого объекта то она выиграла
        {
            Panel.SetActive(true);
            Win.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Red() //Войд для проигреша
    {
        Panel.SetActive(true);
        Lost.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() //Копка перезгрузки
    {
        SceneManager.LoadScene(0);
    }

    public void Exit() //кнопка выхода из игры
    {
        Application.Quit();
    }
}
