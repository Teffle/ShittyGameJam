using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public LayerMask WhatIsGround;
    
    public bool IsGrounded()
    {
        var position = transform.position;
        var direction = Vector2.down;
        const float distance = 0.8f;

        Debug.DrawRay(position, direction, new Color(1f, 0f, 1f));
        var hit = Physics2D.Raycast(position, direction, distance, WhatIsGround);
        var hitLeft = Physics2D.Raycast(position + new Vector3(0.45f, 0, 0), direction, distance, WhatIsGround);
        var hitRight = Physics2D.Raycast(position + new Vector3(-0.45f, 0, 0), direction, distance, WhatIsGround);

        if (hitLeft == true || hitRight == true || hitLeft == true)
        {
            return true;
        } else
        {
            return false;
        }
        
    }
}
