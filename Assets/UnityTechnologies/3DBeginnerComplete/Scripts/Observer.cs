using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;
    public float viewAngle = 110f;

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update ()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Check if player is within FOV
            float dot = Vector3.Dot(directionToPlayer, transform.forward);
            float threshold = Mathf.Cos(viewAngle / 2 * Mathf.Deg2Rad);

            if (dot > threshold)
            {
                Ray ray = new Ray(transform.position, directionToPlayer);
                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit))
                {
                    if (raycastHit.collider.transform == player)
                    {
                        gameEnding.CaughtPlayer ();
                    }
                }
            }
        }
    }
}
