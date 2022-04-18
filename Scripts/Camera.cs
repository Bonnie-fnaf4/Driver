using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Car; //Переменная для отслеживания положения машины

    public float speed = 4f; //Скорость реагирования камеры на движения машины

    public Vector3 _position; //Переменная позиции

    public float x, y, z;
    void Start()
    {
         _position = Car.InverseTransformPoint(transform.position); //Получаем позицию машины в локальных координатах
    }

    void Update()
    {
        var currentPositin = Car.TransformPoint(_position); //Создаём переменую для координат перемещения камеры

        transform.position = Vector3.Lerp(transform.position, currentPositin, speed * Time.deltaTime); //Перемещаем камеру
        var currentRotation = Quaternion.LookRotation(Car.position - transform.position); //Рассчитывает траекторию поворота машины
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, speed * Time.deltaTime); //Присваевает координаты поворота камере
    }
}
