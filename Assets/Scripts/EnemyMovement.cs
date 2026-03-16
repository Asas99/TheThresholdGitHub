using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovement
{
    public float MoveSpeed;
    public GameObject Player;
    [HideInInspector]
    public SeePlayer seePlayer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        seePlayer = GetComponent<SeePlayer>();
    }

    void Update()
    {
        if (seePlayer.CanSeePlayer)
        {
            float direction = Mathf.Sign(Player.transform.position.x - transform.position.x);
            if(seePlayer.direction.magnitude > seePlayer.StopDistance)
            {
                Move(direction);
            }
        }
    }

    public void Move(float direction)
    {
        transform.position += new Vector3(MoveSpeed * Time.deltaTime * direction, 0, 0);
    }
}
