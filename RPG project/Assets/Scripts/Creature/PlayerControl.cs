using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]     // 한 오브젝트에 하나만 달리게
public class PlayerControl : MonoBehaviour
{

    Player player;

    float moveSpeed = 5;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void MovementInput()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);

        if (direction != Vector2.zero)
        {
            player.MovementEvent.CallMovementEvent(direction, moveSpeed);
        }
    }
}
