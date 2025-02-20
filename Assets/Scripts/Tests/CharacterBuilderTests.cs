using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterBuilderTests
{
	[Test]
	public void WithName_Should_Set_Name()
	{
		// Arrange
		CharacterBuilder builder = new CharacterBuilder();

		// Act
		Character character = builder
			.WithName("Alice")
			.Build();

		// Assert
		Assert.AreEqual("Alice", character.name);
	}

	[Test]
	public void WithHealth_Should_Set_Health()
	{
		// Arrange
		CharacterBuilder builder = new CharacterBuilder();

		// Act
		Character character = builder
			.WithHealth(150)
			.Build();

		// Assert
		Assert.AreEqual(150, character.health);
	}

	[Test]
	public void WithStrength_Should_Set_Strength()
	{
		// Arrange
		CharacterBuilder builder = new CharacterBuilder();

		// Act
		Character character = builder
			.WithStrength(20)
			.Build();

		// Assert
		Assert.AreEqual(20, character.strength);
	}

	[Test]
	public void WithIntelligence_Should_Set_Intelligence()
	{
		// Arrange
		CharacterBuilder builder = new CharacterBuilder();

		// Act
		Character character = builder
			.WithIntelligence(25)
			.Build();

		// Assert
		Assert.AreEqual(25, character.intelligence);
	}

	[Test]
	public void WithWeapon_Should_Set_Weapon()
	{
		// Arrange
		CharacterBuilder builder = new CharacterBuilder();
		Weapon weapon = new Weapon("test weapon", 10);

		// Act
		Character character = builder
			.WithWeapon(weapon)
			.Build();

		// Assert
		Assert.AreEqual(weapon, character.weapon);
	}
}
