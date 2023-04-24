using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    // [SerializeField] private float m_currentHealth;
    // [SerializeField] private float m_maxHealth = 100;

    // public event Action HealthChanged;
    // public event Action<float, float> ClientOnHealthChanged;


    // private void Awake() => m_currentHealth = m_maxHealth;

    // void Update()
    // {
    //     if (m_currentHealth <= 0)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // public void AdjustHealth(float adj) {

    //     m_currentHealth += adj;
    //     ClientOnHealthChanged?.Invoke(m_currentHealth, m_maxHealth);        
    // } 

    private int m_currentHealth;
    [SerializeField] private int m_maxHealth = 100;


    public event Action<float, float> HealthChanged;
    void Awake()
    {
        m_currentHealth = m_maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // if (!photonView.IsMine) return;

        m_currentHealth = (int)Mathf.Max(m_currentHealth - damage, 0);
        HealthChanged?.Invoke(m_currentHealth, m_maxHealth);
        // HealthChanged?.Invoke();
    }

    public void OnAttack(GameObject attacker, Attack attack) 
    {
        TakeDamage(attack.Damage);

        if (m_currentHealth <= 0)
        {
            var destructibles = GetComponents(typeof(IDestructible));
            foreach (IDestructible d in destructibles)
                d.OnDestruction(attacker);
        }   
    }

    public int GetCurrentHealth() => m_currentHealth;
    public int GetMaxHealth() => m_maxHealth;
}
