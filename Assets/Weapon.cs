using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject proyectile;
    public Transform firingStartPoint;
    public float cooldown = 0.5f;
    private float _timer;
    private bool isFiring;

    public void Attack()
    {
        if (_timer <= 0.0f)
        {
            Instantiate(proyectile, transform.position, transform.rotation);
            _timer = cooldown;
        }
    }

    public void StartFiring()
    {
        isFiring = true;
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0.0f;
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0.0f)
            _timer = 0.0f;

        if (isFiring)
            Attack();
    }
}
