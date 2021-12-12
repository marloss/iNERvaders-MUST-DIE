using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Inventory : MonoBehaviour
{
    [SerializeField] Gamemanager gamemanager;
    [Space(20)]
    public List<Weapon> pistol_wheel, machinegun_wheel, shotgun_wheel, special_wheel, melee_wheel;
    [SerializeField] private List<Weapon> weapon_wheel;
    public int wheel_indx = 0;
    [Space(30)]
    public Image weapon_wield_Image;
    public Sprite weapon_Sprite;
    public Sprite temporary_Sprite;
    [Space]
    //Is the currently wielded weapon
    public Weapon weapon;
    [Space(30)]
    public KeyCode primary_fire;
    public KeyCode secondary_Fire;

    private void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
        Fetch_Weapon_Pick_Up(weapon);
    }

    private void Update()
    {
        Weapon_Utilize(weapon);
    }

    private void FixedUpdate()
    {
        Update_Fire_Rate(weapon);
    }

    void Weapon_Utilize(Weapon equipped_weapon)
    {
        if (equipped_weapon == null)
            return;
        if (equipped_weapon.minimum_Fire_Rate <= 0)
        {
            if (Input.GetKeyDown(primary_fire))
            {
                Weapon_Fire(equipped_weapon,equipped_weapon.projectile_based);
                equipped_weapon.minimum_Fire_Rate = equipped_weapon.maximum_Fire_Rate;
            }
        }
    }

    void Update_Fire_Rate(Weapon equipped_weapon)
    {
        if (equipped_weapon == null)
            return;
        if (equipped_weapon.minimum_Fire_Rate > 0)
            equipped_weapon.minimum_Fire_Rate -= Time.deltaTime;
    }

    void Weapon_Fire(Weapon weapon, bool isProjectileBased)
    {
        Camera shootpos = GetComponentInChildren<Camera>();
        switch (isProjectileBased)
        {
            case true:
                Instantiate(weapon.projectile, shootpos.transform.position, shootpos.transform.rotation);
                break;
            case false:
                RaycastHit ray;
                bool isHit = Physics.Raycast(shootpos.transform.position, shootpos.transform.forward, out ray, weapon.weapon_lenght);
                if (isHit && ray.transform.GetComponent<Enemy_Behavior>() != null)
                {
                    Enemy_Behavior enemy = ray.transform.GetComponent<Enemy_Behavior>();
                    enemy.Absorb_Damage(weapon.damage, false);
                    //Decide if damage staggers
                }
                break;
        }
    }

    private void Fetch_Weapon_Information(Weapon current_weapon)
    {
        switch (current_weapon.wield_sprite != null) { case true: weapon_Sprite = current_weapon.wield_sprite; break; case false: weapon_Sprite = temporary_Sprite; break; }
        weapon = current_weapon;
        current_weapon.minimum_Fire_Rate = 0;
        Display_Weapon_Information(weapon);
    }

    private void Display_Weapon_Information(Weapon current_weapon) 
    {
        if (current_weapon is null)
        {
            throw new System.ArgumentNullException(nameof(current_weapon));
        }

        weapon_wield_Image.sprite = weapon_Sprite;
        weapon_wield_Image.SetNativeSize();
    }

    private void Fetch_Weapon_Pick_Up(Weapon _weapon_pickup)
    {
        for (int i = 0; i < gamemanager.weapon_list.Count; i++)
        {
            if (gamemanager.weapon_list[i].weapon_name == _weapon_pickup.weapon_name)
            {
                weapon_wheel.Add(gamemanager.weapon_list[i]);
                //Types: Melee, Pistol, Machinegun, Shotgun, Special
                switch (_weapon_pickup.weapon_type)
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
        Fetch_Weapon_Information(_weapon_pickup);
    }

    private void Fetch_Weapon_Pick_Up(Collider _weapon_pickup)
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
        Fetch_Weapon_Information(temp.weapon);
        Destroy_Object(_weapon_pickup.gameObject);
    }

    private void Destroy_Object(GameObject _destroy) 
    {
        Destroy(_destroy);
    }

    private void OnTriggerEnter(Collider enter_trigger_collision)
    {
        if (enter_trigger_collision.GetComponent<Weapon_Pick_Up>() != null)
            Fetch_Weapon_Pick_Up(enter_trigger_collision);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(GetComponentInChildren<Camera>().transform.position, GetComponentInChildren<Camera>().transform.forward);
    }
}
