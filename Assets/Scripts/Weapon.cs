using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public string weapon_name;
    [Space]
    public string weapon_type;
    [Space]
    public int maximum_ammunition;
    public int used_ammunition;
    [Space]
    public float weapon_lenght;
    [Space]
    public bool projectile_based;
    public bool isExplosive;
    public bool aim;
    public bool secondary_fire;
    [Space(20)]
    public Sprite wield_sprite;
    public Sprite hoist_sprite;
    [Space]
    public GameObject projectile;
    [Space]
    public float maximum_Fire_Rate;
    public float minimum_Fire_Rate;
    [Space]
    public int damage;
}
