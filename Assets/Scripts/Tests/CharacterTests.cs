using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterTests
{
	[Test]
	public void Attack_Should_Return_Correct_Strength_When_No_Weapon_Or_Buff()
	{
		// Arrange
		CharacterBuilder builder = new CharacterBuilder();
		Character character = builder
			.WithStrength(10)
			.Build();

		// Act
		int attackStrength = character.Attack();

		// Assert
		Assert.AreEqual(10, attackStrength);
	}

	[Test]
	public void Attack_Should_Include_Weapon_Strength_When_Weapon_Is_Equipped()
	{
		// Arrange
		Weapon weapon = new Weapon("", 5);
		CharacterBuilder builder = new CharacterBuilder();
		Character character = builder
			.WithStrength(10)
			.WithWeapon(weapon)
			.Build();

		// Act
		int attackStrength = character.Attack();

		// Assert
		Assert.AreEqual(15, attackStrength);
	}

	[Test]
	public void Attack_Should_Include_Buff_Strength_When_Buff_Is_Active()
	{
		// Arrange
		Buff buff = new Buff { strength = 3, remainingRounds = 1 };

		CharacterBuilder builder = new CharacterBuilder();
		Character character = builder
			.WithStrength(10)
			.Build();

		character.ApplyBuff(buff);

		// Act
		int attackStrength = character.Attack();

		// Assert
		Assert.AreEqual(13, attackStrength);
	}

	[Test]
	public void Attack_Should_Include_Weapon_And_Buff_Strength_When_Both_Are_Present()
	{
		// Arrange
		Weapon weapon = new Weapon("", 5);
		Buff buff = new Buff { strength = 5, remainingRounds = 1 };

		CharacterBuilder builder = new CharacterBuilder();
		Character character = builder
			.WithStrength(10)
			.WithWeapon(weapon)
			.Build();

		character.ApplyBuff(buff);

		// Act
		int attackStrength = character.Attack();

		// Assert
		Assert.AreEqual(20, attackStrength);
	}

	[Test]
	public void Attack_Should_Decrease_Buff_Remaining_Rounds()
	{
		// Arrange
		Buff buff = new Buff { strength = 5, remainingRounds = 10 };

		CharacterBuilder builder = new CharacterBuilder();
		Character character = builder
			.WithStrength(10)
			.Build();

		character.ApplyBuff(buff);

		// Act
		character.Attack();

		// Assert
		Assert.AreEqual(9, buff.remainingRounds);
	}

	[Test]
	public void Attack_Should_Remove_Buff_When_Buff_Expires()
	{
		// Arrange
		Buff buff = new Buff { strength = 3, remainingRounds = 1 };
		CharacterBuilder builder = new CharacterBuilder();
		Character character = builder
			.WithStrength(10)
			.Build();
		character.ApplyBuff(buff);

		// Act
		character.Attack();

		// Assert
		Assert.IsNull(character.activeBuff);
	}
}
