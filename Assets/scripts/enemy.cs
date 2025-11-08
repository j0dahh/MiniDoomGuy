using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int damage;
    private Health player;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private Score sm;

    private void Start()
    {
        sm = FindObjectOfType<Score>();
        player = FindObjectOfType<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            sm.Kill();
            Destroy(gameObject);
        }
        

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
        {
            OnEnemyAttack();
        }
    }
    public void OnEnemyAttack()
    {
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }

    IEnumerator IncreaseStatsOverTime()
    {
        while (true)
        {
            // ??????????? HP ? ???? ?????
            health += 3; // ?????????? HP ?? 10 ??????
            damage += 1;    // ?????????? ????? ?? 5 ??????

            yield return new WaitForSeconds(10f); // ??????????? ?????? 60 ??????
        }
    }


}
