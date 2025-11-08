using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
