using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Text healthText;

    private int health;

    void Start()
    {
        health = 100;
        SetHealthText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GameObject.CompareTag("Projectile"))
        {
            health--;
            SetHealthText();
        }
    }

    void SetHealthText()
    {
        if (healthText == null)
            return;
        healthText.text = "Health: " + health.ToString();
    }
}