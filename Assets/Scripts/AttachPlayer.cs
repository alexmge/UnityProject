using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    public GameObject player;

    // On collision with player, set player's parent to this object
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    // On exit of collision with player, set player's parent to null
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
