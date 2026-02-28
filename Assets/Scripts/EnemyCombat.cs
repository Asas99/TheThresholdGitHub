using UnityEngine;

public class EnemyCombat : MonoBehaviour, ICombat
{
    public int Health;
    public int Damage;
    [SerializeField] private bool Attackable;
    public CharacterCombat characterCombat;

    [SerializeField] private float attackInterval; // 1 saniyede bir
    private float attackTimer;

    public void Attack()
    {
        if (characterCombat)
        {
            characterCombat.Health -= Damage;
            print("Attacks");
        }
        else
        {
            print("Karakter bulunamadý");
        }

    }

    public void Die()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        characterCombat = GameObject.FindFirstObjectByType<CharacterCombat>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DetectAttackable>())
        {
            other.GetComponent<DetectAttackable>().TargetedEnemy = gameObject;
            Attackable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DetectAttackable>())
        {
            other.GetComponent<DetectAttackable>().TargetedEnemy = null;
            Attackable = false;
        }
    }

    void Update()
    {
        if (Attackable)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackInterval)
            {
                Attack();
                attackTimer = 0f;
            }
        }
        else
        {
            attackTimer = 0f; // hedef çýkarsa resetle
        }

        Die();
    }
}