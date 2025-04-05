using System;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [HideInInspector]
    public Player player;

    [HideInInspector]
    public Rigidbody2D rb;
    
    public float health;
    public Slider healthBar;

    private float maxHealth;

    private void Awake()
    {
        maxHealth = health;
    }

    void Start()
    {
        player = Player.Instance;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(healthBar != null)
            UpdateHealthBar();

        if (health > maxHealth) health = maxHealth;
    }

    void UpdateHealthBar()
    {
        healthBar.value = health;
    }
}