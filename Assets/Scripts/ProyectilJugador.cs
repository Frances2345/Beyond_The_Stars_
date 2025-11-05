using UnityEngine;

public class ProyectilJugador : MonoBehaviour, IAttackable
{
    [SerializeField] private float damageAmount = 25f;
    public float DamageAmount => damageAmount;

    public void AttackTarget(IDamageable target) 
    { 
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            target.TakeDamage(DamageAmount);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}