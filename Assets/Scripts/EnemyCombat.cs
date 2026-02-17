using UnityEngine;

public class EnemyCombat : MonoBehaviour, ICombat
{
    public int Health;
    public int Damage;
    public void Attack()
    {
       //
    }

    public void Die()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DetectAttackable>())
        {
            other.GetComponent<DetectAttackable>().TargetedEnemy = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DetectAttackable>())
        {
            other.GetComponent<DetectAttackable>().TargetedEnemy = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
}
