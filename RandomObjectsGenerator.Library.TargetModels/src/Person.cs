//---------------------------------------------------------------------------
// <copyright file="Person.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Represents a person with generally known social characteristics.
/// </summary>
public class Person
{
    /// <summary>
    /// Gets or sets the unique numeric identifier of the person.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the sequence identifier of the person.
    /// </summary>
    public int SequenceId { get; set; }

    /// <summary>
    /// Gets or sets the GUID for person's transport vehicle.
    /// </summary>
    public Guid TransportId { get; set; }

    /// <summary>
    /// Gets or sets the first name of the person.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the person.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the gender of the person.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Gets or sets the age of the person.
    /// </summary>
    public byte Age { get; set; }

    /// <summary>
    /// Gets or sets person's birth date in the POSIX format.
    /// </summary>
    public long BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the numbers of credit cards owned by the person.
    /// </summary>
    public string[] CreditCardNumbers { get; set; }

    /// <summary>
    /// Gets or sets the phone numbers owned by the person.
    /// </summary>
    public string[] Phones { get; set; }

    /// <summary>
    /// Gets or sets person's monthly salary size in Russian rubles.
    /// </summary>
    public decimal Salary { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the person is married.
    /// </summary>
    public bool IsMarried { get; set; }

    /// <summary>
    /// Gets or sets person's children.
    /// </summary>
    public Child[] Children { get; set; }
}

/// <summary>
/// Represents person's child with general human characteristics.
/// </summary>
public class Child
{
    /// <summary>
    /// Gets or sets the unique numeric identifier of the child.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the child.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the child.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets child's birth date in the POSIX format.
    /// </summary>
    public long BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the gender of the child.
    /// </summary>
    public Gender Gender { get; set; }
}

/// <summary>
/// Represents a gender of a person.
/// </summary>
public enum Gender
{
    /// <summary>
    /// Represents the male gender.
    /// </summary>
    Male,

    /// <summary>
    /// Represents the female gender.
    /// </summary>
    Female,
}
