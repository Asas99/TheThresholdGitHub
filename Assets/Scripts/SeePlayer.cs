using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    private GameObject Player;
    public bool CanSeePlayer;
    public float ViewDistance = 10f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, ViewDistance);
        
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            CanSeePlayer = true;
        }
        else
        {
            CanSeePlayer = false;
        }
        if (direction.magnitude > ViewDistance)
        {
            CanSeePlayer = false;
        }

    }
}