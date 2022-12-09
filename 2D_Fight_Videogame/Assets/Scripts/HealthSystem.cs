public class HealthSystem
{
    private int health;
    private int maxHealth;
    private float healthPercent;
    public HealthSystem(int maxHp)
    {
        this.maxHealth = maxHp;
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent(){
        healthPercent = health / maxHealth; 
        return healthPercent;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0) health = 0;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health >= maxHealth) health = maxHealth;
    }
}
