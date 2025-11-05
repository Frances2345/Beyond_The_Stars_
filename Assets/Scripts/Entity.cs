using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{

    [SerializeField] protected float Speed = 14f;
    [SerializeField] protected float Attack = 10f;
    [SerializeField] protected float Defensa = 10f;
    [SerializeField] protected float Health = 100f;

    public virtual void TakeDamage(float amount)
    {
        float damageTaken = Mathf.Max(0, amount - Defensa);
        Health -= damageTaken;
        Debug.Log(gameObject.name + " recibió " + damageTaken + " de daño. Salud restante: " + Health);

        if (Health <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {

        Debug.Log("ha muerto");
        Destroy(gameObject);
    }

}