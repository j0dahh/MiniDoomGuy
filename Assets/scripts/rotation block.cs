using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private void Update()
    {
        // Получите позицию курсора в мировых координатах.
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Определите вектор направления от спрайта к позиции курсора.
        Vector3 direction = cursorPosition - transform.position;

        // Определите направление - вправо или влево.
        float directionX = direction.x > 0 ? 1f : -1f;

        // Примените поворот спрайта только по оси Y, чтобы развернуть его влево или вправо.
        transform.rotation = Quaternion.Euler(0, directionX > 0 ? 0 : 180, 0);
    }
}
