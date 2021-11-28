using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Controller : MonoBehaviour
{
    /// <summary>
    /// Character controller
    /// Doom movement
    /// </summary>

    [SerializeField] private float player_input_horizontal, player_input_vertical;
    [Space]
    public CharacterController player_controller;
    [Space]
    public float movement_speed;

    private void Start()
    {
        Set_Default_Properties();
    }

    void Update()
    {
        Fetch_Player_Input();
    }

    private void FixedUpdate()
    {
        Character_Controller_Movement();
    }

    private void Character_Controller_Movement()
    {
        if (player_controller != null)
        {
            Vector3 _mv = transform.right * player_input_horizontal + transform.forward * player_input_vertical;
            player_controller.Move(_mv * movement_speed *Time.fixedDeltaTime);
        }
    }

    private void Fetch_Player_Input()
    {
        player_input_horizontal = Input.GetAxis("Horizontal");
        player_input_vertical = Input.GetAxis("Vertical");
    }

    private void Set_Default_Properties()
    {
        player_controller = GetComponent<CharacterController>();
    }
}
