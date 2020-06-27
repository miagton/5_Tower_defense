using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text text;
    PlayerHealth health;
    private void Start()
    {
         text = GetComponent<Text>();
        health = FindObjectOfType<PlayerHealth>();
      //  UpdateText();
    }

   
    void Update()
    {
        UpdateText();
    }
    void UpdateText()
    {
        
        int lives = health.GetHealth();
        text.text = "Lives : " + lives;

    }
}
