using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Enemy_Idle idleState;
    public Enemy_MoveState moveState;

    [Header("ÒÆ¶¯Ï¸½Ú")]
    public float idleTime = 2;
    public float moveSpeed = 1.4f;
    [Range(0f, 2f)]
    public float moveAnimSpeedMultiplier = 1;
}
