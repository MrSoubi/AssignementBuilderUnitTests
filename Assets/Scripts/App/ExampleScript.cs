using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	Character character;
    void Start()
    {
		CharacterBuilder builder = new CharacterBuilder();

		character = builder
			.WithName("Alex")
			.WithHealth(100)
			.WithStrength(150)
			.WithIntelligence(1000)
			.WithWeapon(new Weapon("VR Helmet of torment", 666))
			.Build();

		character.ApplyBuff(new Buff { strength = 50, remainingRounds = 3 });
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Character attacks with " + character.Attack() + " damage");
		}
	}
}
