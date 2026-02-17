using UnityEngine;

public class DetectAttackable : MonoBehaviour
{
    public CharacterCombat characterCombat;
    public int Damage;
    public GameObject TargetedEnemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("attackable");
            characterCombat.CanAttack = true;
            characterCombat.CurrentWaponDamage = Damage;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            print(" notattackable");
            characterCombat.CanAttack = false;
            characterCombat.CurrentWaponDamage = 0;
        }
    }
}
