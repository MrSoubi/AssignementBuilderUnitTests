using UnityEngine;

public class CharacterBuilder
{
    private string characterName = "John";
    private int characterHealth = 100;
    private int characterStrength = 10;
    private int characterIntelligence = 10;
    private Weapon characterWeapon;

    public CharacterBuilder WithName(string name){
        characterName = name;
        return this;
    }

    public CharacterBuilder WithHealth(int health){
        characterHealth = health;
        return this;
    }

    public CharacterBuilder WithStrength(int strength){
        characterStrength = strength;
        return this;
    }

    public CharacterBuilder WithIntelligence(int intelligence){
        characterIntelligence = intelligence;
        return this;
    }

    public CharacterBuilder WithWeapon(Weapon weapon){
        characterWeapon = weapon;
        return this;
    }

    public Character Build(){
        Character character = new Character(
            characterName,
            characterHealth,
            characterStrength,
            characterIntelligence,
            characterWeapon
        );
        return character;
    }
}
