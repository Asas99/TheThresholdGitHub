using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCombat : MonoBehaviour, ICombat
{
    public int Health;
    public bool CanAttack;
    public int CurrentWaponDamage;
    public DetectAttackable detectAttackable;

    public void Attack()
    {
        if (detectAttackable.TargetedEnemy)
        {
            detectAttackable.TargetedEnemy.GetComponent<EnemyCombat>().Health -= CurrentWaponDamage;
        }
    }

    public void Die()
    {
        if(Health <= 0)
        {
            //Daha sonraki aþamalarda bir sprite animastion oynatýlabilir.
            //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
}
