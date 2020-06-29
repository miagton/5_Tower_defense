using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerLimitShower : MonoBehaviour
{
    Text thisText;
    TowerFactory info;

    private void Start()
    {
        thisText = GetComponent<Text>();
        info = FindObjectOfType<TowerFactory>();
    }
    private void Update()
    {
        thisText.text = "Towers Limit: " + info.GetTurretLimit();
    }
}
