using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Health othersHealth = other.GetComponent<Health>();

        if (othersHealth != null)
        {
            othersHealth.ApplyDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
