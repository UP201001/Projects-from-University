public class HealthSystem
{
    private double health;
    private double maxHealth;
    private float healthPercent;
    public HealthSystem(double maxHp)
    {
        this.maxHealth = maxHp;
        health = maxHealth;
    }

    public double GetHealth()
    {
        return health;
    }

    public double GetHealthPercent(){
        healthPercent = (float)(health / maxHealth); 
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
