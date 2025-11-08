using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Скорость движения врага
    public Transform target; // Ссылка на главного персонажа (игрока)

    private void Update()
    {
        if(target.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}
