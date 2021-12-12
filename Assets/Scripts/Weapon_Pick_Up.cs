using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Pick Up", menuName = "Weapon/Weapon_Pick_Up", order = 2)]
public class Weapon_Pick_Up : MonoBehaviour
{
    public Weapon weapon;
    public string weapon_name;
    [Tooltip("Types: Melee, Pistol, Machinegun, Shotgun, Special")]
    public string weapon_type;
    [Space]
    public Sprite weapon_vield_sprite;
    public Sprite weapon_hoist_sprite;

    private void Start() {
        weapon_name = weapon.weapon_name;
        weapon_type = weapon.weapon_type;
        weapon_vield_sprite = weapon.wield_sprite;
        weapon_hoist_sprite = weapon.wield_sprite;
        GetComponentInChildren<SpriteRenderer>().sprite = weapon_hoist_sprite;
        GetComponentInChildren<Sprite_Billboard>()._sprite = weapon.wield_sprite;
    }
}
