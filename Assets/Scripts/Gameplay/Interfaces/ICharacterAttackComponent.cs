public interface ICharacterAttackComponent
{
    void Attack(DamageableEntity target);
    void CancelAttack();
    void ClearAttackStates();

}
