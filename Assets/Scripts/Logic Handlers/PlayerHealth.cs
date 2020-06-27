using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;

    [SerializeField] AudioClip hitSound;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            audioSource.PlayOneShot(hitSound);
            health=health-healthDecrease;
           
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
