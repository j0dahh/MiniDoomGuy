using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;
    public float damageCooldown = 2.0f; // Время задержки между нанесением урона

    private bool canDamage = true; // Флаг, разрешающий наносить урон

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Если тег объекта коллайдера, который столкнулся с коллайдером нашего объекта, соответствует "collisionTag"
        if (coll.gameObject.tag == collisionTag && canDamage)
        {
            // Берём у этого объекта компонент Health (скрипт, который на нём висит)
            Health health = coll.gameObject.GetComponent<Health>();
            // И вызываем функцию получения урона, в аргументе переменная урона
            health.TakeHit(collisionDamage);


            canDamage = false; // После нанесения урона устанавливаем флаг в false
            StartCoroutine(EnableDamageCooldown()); // Запускаем корутину для включения задержки

        }
    }

    IEnumerator EnableDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown); // Ждем заданное время
        canDamage = true; // После задержки включаем возможность нанесения урона снова
    }
}
