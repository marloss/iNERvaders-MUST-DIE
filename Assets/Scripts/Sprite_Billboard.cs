using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Billboard : MonoBehaviour
{
    public Enemy_Behavior enemy_Behavior_script;
    [Space]
    public SpriteRenderer _spriteRenderer;
    [Space]
    public Animator sprite_animator;
    [Space]
    public bool isDirectionalSprite;
    public bool isInverted;
    [Space]
    [Header("Sprites for Directional Billboard")]
    public List<Sprite> current_Sprite_List;
    [Space]
    public List<Sprite> dormant_Sprite;
    public List<Sprite> movement_Sprite;
    public List<Sprite> Idle_Sprite;
    public List<Sprite> Attack_Sprite;
    public List<Sprite> Stagger_Sprite; //Fix syntax small
    public List<Sprite> Death_Sprite;
    [Space]
    [Header("Sprites for non-directionectional Billboard")]
    public Sprite _sprite;

    private void Start()
    {
        enemy_Behavior_script = GetComponent<Enemy_Behavior>();
        isDirectionalSprite = dormant_Sprite.Count > 0 && movement_Sprite.Count > 0;
        Set_Sprite_List(movement_Sprite, "movement_sprite_swap"); //Placeholder
    }

    private void LateUpdate()
    {
        Set_Animation_Properties();
    }

    public void Set_Sprite_List(List<Sprite> sprites, string animation_swap_id)
    {
	//Swap animator state to a new, existing named set
        current_Sprite_List = sprites;
        sprite_animator.SetTrigger(animation_swap_id);
    }

    private void Set_Animation_Properties()
    {
        _spriteRenderer.gameObject.transform.LookAt(enemy_Behavior_script.player.transform.position);
        switch (isDirectionalSprite)
        {
            case true:
                sprite_animator.SetInteger("sprite_direction", Fetch_Direction_From_Angle());
                _spriteRenderer.flipX = isInverted;
                break;
            case false:
                _spriteRenderer.sprite = _sprite;
                break;
        }
    }
    private int Fetch_Direction_From_Angle()
    {
        int direction = 0;
        float raw_direction = Calculate_Angle();
        if (raw_direction < 20 && raw_direction > -20)
        {
            direction = 0;
            isInverted = false;
        }
        else if (raw_direction > 20 && raw_direction < 85)
        {
            direction = 1;
            isInverted = false;
        }
        else if (raw_direction > 85 && raw_direction < 95)
        {
            direction = 2;
            isInverted = false;
        }
        else if (raw_direction > 95 && raw_direction < 140)
        {
            direction = 3;
            isInverted = false;
        }
        else if (raw_direction > 140 && raw_direction < 180)
        {
            direction = 4;
            isInverted = false;
        }
        else if (raw_direction < -20 && raw_direction > -85)
        {
            direction = 1;
            isInverted = true;
        }
        else if (raw_direction < -85 && raw_direction > -95)
        {
            direction = 2;
            isInverted = true;
        }
        else if (raw_direction < -95 && raw_direction > -140)
        {
            direction = 3;
            isInverted = true;
        }
        else if (raw_direction < -140 && raw_direction > -180)
        {
            direction = 4;
            isInverted = false;
        }
        return direction;
    }
    private float Calculate_Angle()
    {
        ///Calculates the angle between two vectors.
        ///One of the Vector is the enemy's forward position
        ///The last Vector is the Enemy/Player vector (Calculate magnitude from Enemy pont and Player point with subtraction)
        ///Signed agle returns positive and negative values
        Vector3 enemy_Directional_Vector = transform.forward;
        Vector3 player_Enemy_Vector = enemy_Behavior_script.player.transform.position - transform.position;
        float view_angle = Vector3.SignedAngle(enemy_Directional_Vector, player_Enemy_Vector, Vector3.up);
        return view_angle;
    }
}
