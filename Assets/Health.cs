using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hitPoints;

    public void ApplyDamage(float damage)
    {
        hitPoints -= damage;

        DeathEffect deathEffect = GetComponent<DeathEffect>();

        if (deathEffect != null && hitPoints <= 0.0f)
            deathEffect.Die();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
