using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovement
{
    public float MoveSpeed;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (GetComponent<SeePlayer>().CanSeePlayer)
        {
            float direction = Mathf.Sign(Player.transform.position.x - transform.position.x); direction = Mathf.Sign(Player.transform.position.x - transform.position.x);
            Move(direction);
        }
    }

    public void Move(float direction)
    {
        transform.position += new Vector3(MoveSpeed * Time.deltaTime * direction, 0, 0);
    }
}
