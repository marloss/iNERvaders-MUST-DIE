using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Weapon/Projectile", order = 2)]
public class Projectile : ScriptableObject
{
    public float projectile_Speed;
    [Space]
    public Sprite projectile_Sprite;
    public GameObject projectile_Model;
}
