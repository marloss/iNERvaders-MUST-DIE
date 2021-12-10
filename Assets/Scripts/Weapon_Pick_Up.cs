using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Pick Up", menuName = "Weapon/Weapon_Pick_Up", order = 2)]
public class Weapon_Pick_Up : ScriptableObject
{
    public string weapon_name;
    [Tooltip("Types: Melee, Pistol, Machinegun, Shotgun, Special")]
    public string weapon_type;
    [Space]
    public Sprite weapon_vield_sprite;
    public Sprite weapon_hoist_sprite;
}
