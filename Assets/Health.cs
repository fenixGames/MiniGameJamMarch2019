using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hitPoints;
    public float armorValue = 0.0f;

    public void ApplyDamage(float damage)
    {
        if (damage > armorValue)
            hitPoints -= (damage - armorValue);

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
