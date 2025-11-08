using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPos;

    public GameObject enemy;

    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(enemy, SpawnPos.position, Quaternion.identity);
    }
}