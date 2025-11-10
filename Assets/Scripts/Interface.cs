public interface IDroppable
{
    void DropItem();
}

public interface IConsumable
{
    void Consume(Entity target);
}

public interface IBuffeable
{
    void ApplyBuff(Entity target);
}

public interface IAttackable
{
    float DamageAmount { get; }
    void AttackTarget(IDamageable target);
}

public interface IDamageable
{
    void TakeDamage(float amount);
}