using UnityEngine;

public class LookAtCursorWithFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Получите позицию курсора в мировых координатах.
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Определите вектор направления от спрайта к позиции курсора.
        Vector3 direction = cursorPosition - transform.position;

        // Вычислите угол поворота в радианах.
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Преобразуйте угол в градусы.
        float angleInDegrees = angle * Mathf.Rad2Deg;

        // Примените поворот спрайта по оси Z (угол Эйлера).
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleInDegrees));

        
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }// Выполните переворот спрайта, если угол превышает 90 градусов или меньше -90 градусов по оси X.
        
    }
}

