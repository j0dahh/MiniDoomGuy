using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //Значение здоровья
    public int health;
    //Максимальное значение здоровья
    public int maxHealth;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    //Функция получения урона
    public void TakeHit(int damage)
    {
        health -= damage;

        //Если здоровье меньше 0 - уничтожить объект на котором весит этот скрипт
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    //Функция прибавления здоровья
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        //Если здоровье, после пополнения, больше максимального значения - здоровье будет равно максимальному значению.
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
