using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    private GameObject Player;
    public bool CanSeePlayer;
    public float ViewDistance = 10f;
    public float StopDistance;
    [HideInInspector]
    public Vector2 direction;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        direction = Player.transform.position - transform.position;
        //Burayı biraz değiştirdim raycastall yapıp önüne gelen bir collider varsa ona çarpıp bitmemesini sağladım fakat ilerde bu layermask kullanarak daha temiz ve optimize edilebilir
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, direction.normalized, ViewDistance);
        CanSeePlayer = false;
        foreach (RaycastHit2D raycastHit in hit)
        {
            if (raycastHit.collider.gameObject == gameObject || raycastHit.collider.CompareTag("Enemy"))
            {
                continue;
            }
            if (raycastHit.collider.gameObject.CompareTag("Player"))
            {
                CanSeePlayer = true;
                break;
            }
            else if (!raycastHit.collider.isTrigger)
            {
                break;
            }
        }
    }
}