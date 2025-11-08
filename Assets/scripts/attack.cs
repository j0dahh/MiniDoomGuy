using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private SpriteRenderer spriteRenderer;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange; // Дальность атаки.
    public int damage; // Урон атаки.
    public Animator anim; // Ссылка на компонент Animator.

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Уменьшаем время до следующей атаки.
        timeBtwAttack -= Time.deltaTime;

        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                // Включаем анимацию атаки.
                anim.SetTrigger("Attack");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<enemy>().TakeDamage(damage);
                }

                // Сбрасываем таймер атаки.
                timeBtwAttack = startTimeBtwAttack;
            }
        }
    }
    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
