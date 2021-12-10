using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Inventory : MonoBehaviour
{
    [SerializeField] Gamemanager gamemanager;
    [Space(20)]
    public List<Weapon> pistol_wheel, machinegun_wheel, shotgun_wheel, special_wheel, melee_wheel;
    private List<Weapon> weapon_wheel;
    public List<Weapon> s;
    public int wheel_indx = 0;
    [Space(30)]
    public Image weapon_wield_Image;
    public Sprite weapon_Sprite;
    [Space]
    //Is the currently wielded weapon
    public Weapon weapon;

    private void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
    }

    private void Update()
    {
        
    }

    private void Fetch_Weapon_Information(Collider _weapon_pickup)
    {
        Weapon_Pick_Up temp = _weapon_pickup.GetComponent<Weapon_Pick_Up>();
        for (int i = 0; i < gamemanager.weapon_list.Count; i++)
        {
            if (gamemanager.weapon_list[i].weapon_name == temp.weapon_name)
            {
                weapon_wheel.Add(gamemanager.weapon_list[i]);
                //Types: Melee, Pistol, Machinegun, Shotgun, Special
                switch (temp.weapon_type)
                {
                    case "Melee":
                        melee_wheel.Add(gamemanager.weapon_list[i]);
                        break;
                    case "Pistol":
                        pistol_wheel.Add(gamemanager.weapon_list[i]);
                        break;
                    case "Machinegun":
                        machinegun_wheel.Add(gamemanager.weapon_list[i]);
                        break;
                    case "Shotgun":
                        shotgun_wheel.Add(gamemanager.weapon_list[i]);
                        break;
                    case "Special":
                        special_wheel.Add(gamemanager.weapon_list[i]);
                        break;
                } 
            }
        }
    }

    private void OnTriggerEnter(Collider enter_trigger_collision)
    {
        if (enter_trigger_collision.GetComponent<Weapon_Pick_Up>() != null)
            Fetch_Weapon_Information(enter_trigger_collision);
    }
    private void OnTriggerExit(Collider exit_trigger_collision)
    {
        
    }
}
