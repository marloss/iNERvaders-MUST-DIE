using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    private Sprite_Billboard sprite_Billboard;
    [Space]
    public float health;
    [SerializeField] private float current_health;
    [Space]
    [Tooltip("Checks if the enemy is aligible for any more action.")]
    public bool isAlive;
    public bool isDormant;
    private bool isMeleeType;
    [Space]
    public GameObject player;

    private void Start()
    {
        sprite_Billboard = GetComponent<Sprite_Billboard>();
    }
}