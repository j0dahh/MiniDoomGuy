using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform SpawnPos;

    public enemy enemy;
    public float enemyHealth;
    public float increaseHealth;

    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }
    private void Update()
    {
        enemyHealth += Time.deltaTime * increaseHealth;
    }

    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(enemy, SpawnPos.position, Quaternion.identity);
        Repeat();


        enemy.health = Mathf.RoundToInt(enemyHealth);
        
    }
}