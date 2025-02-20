using UnityEngine;

public class Character
{
    public string name;
    public int health;
	public int strength;
	public int intelligence;

	public Weapon weapon;
    public Buff activeBuff;

    public Character(string name, int health, int strength, int intelligence, Weapon weapon){
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.intelligence = intelligence;
        this.weapon = weapon;
    }

    public int Attack(){
        int result = strength;

        if (weapon != null)
            result += weapon.strength;

        if (activeBuff != null)
        {
            result += activeBuff.strength;
            activeBuff.remainingRounds--;

			if (activeBuff.remainingRounds < 1)
				activeBuff = null;
		}
        
        return result;
    }

    public void ApplyBuff(Buff buff)
	{
		activeBuff = buff;
	}
}
