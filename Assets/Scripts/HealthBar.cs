using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealth;
    private float health;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        slider.value = health/maxHealth;

        if(Input.GetKeyDown(KeyCode.Q))
        {
            health--;
            Debug.Log("lost hp");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            health++;
        }
    }
}
