// ---------------------------------------------------------------------------------------------------------
// <copyright file="Child.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.TargetModels;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents person's child with general human characteristics.
/// </summary>
public class Child
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Child"/> class.
    /// </summary>
    public Child()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Child"/> class.
    /// </summary>
    /// <param name="id">Child's ID.</param>
    /// <param name="gender">Child's gender.</param>
    /// <param name="birthDateTime">Child's birth date and time.</param>
    /// <param name="lastName">Child's last name.</param>
    /// <param name="firstName">Child's first name.</param>
    public Child(int id, Gender gender, DateTime birthDateTime, string lastName, string firstName)
    {
        this.Guid = Guid.NewGuid();
        this.Id = id;
        this.Gender = gender;
        this.BirthDate = new DateTimeOffset(birthDateTime).ToUnixTimeSeconds();
        this.LastName = lastName;
        this.FirstName = firstName;
    }

    /// <summary>
    /// Gets or sets the GUID for child's entity tracking by EF Core.
    /// </summary>
    [Key]
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the unique numeric identifier of the child.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the gender of the child.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Gets or sets child's birth date in the POSIX format.
    /// </summary>
    public long BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the last name of the child.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the first name of the child.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets child's age in years.
    /// </summary>
    /// <returns>Child's age in years.</returns>
    public byte GetAgeInYears()
    {
        DateTimeOffset birthDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(this.BirthDate);
        int differenceInYears = DateTime.Now.Year - birthDateTimeOffset.Year;
        return Convert.ToByte(differenceInYears);
    }
}
