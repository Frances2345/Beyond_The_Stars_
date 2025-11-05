using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour, IAttackable
{
    [SerializeField] private float damageAmount = 15;
    public float DamageAmount => damageAmount;

    public void AttackTarget(IDamageable target)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        bool destroy = false;

        if (target != null)
        {
            if (collision.CompareTag("Player"))
            {
                target.TakeDamage(DamageAmount);
                Destroy(gameObject);
                destroy = true;
            }
        }

        if (!destroy && !collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

}
