using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Transform m_attackPosition;
    [SerializeField] private float m_radius;
    [SerializeField] private float m_damage;
    

    public void AttackEvent() 
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(m_attackPosition.position, m_radius);
        foreach (var hitCollider in hitColliders)
        {
            var health = hitCollider.GetComponent<Health>();
            if (health != null && health != GetComponentInParent<Health>())
            {
                health.TakeDamage(m_damage);
            }
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_attackPosition.position, m_radius);    
    }
}
