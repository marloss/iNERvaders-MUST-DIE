using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behavior : MonoBehaviour
{
    public Projectile projectile;
    [Space]
    [SerializeField] Rigidbody projectile_rigidbody;
    [Space]
    public SpriteRenderer spriteRenderer;
    public float damage;

    void Start()
    {
        projectile_rigidbody = GetComponent<Rigidbody>();
        GetComponentInChildren<Sprite_Billboard>()._sprite = projectile.projectile_Sprite;
        projectile_rigidbody.AddForce(transform.forward * projectile.projectile_Speed, ForceMode.Impulse);
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Inventory>().weapon.damage;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Enemy_Behavior>() != null)
        {
            Enemy_Behavior enemy_Behavior = col.GetComponent<Enemy_Behavior>();
            enemy_Behavior.Absorb_Damage(damage, false);
        }
            
    }
}
