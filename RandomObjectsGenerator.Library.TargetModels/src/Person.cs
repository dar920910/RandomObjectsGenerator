// ---------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.TargetModels;

using System.ComponentModel.DataAnnotations;

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
    /// Gets or sets the GUID for person's entity tracking by EF Core.
    /// </summary>
    [Key]
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
    public List<CreditCard> CreditCardNumbers { get; set; }

    /// <summary>
    /// Gets or sets the phone numbers owned by the person.
    /// </summary>
    public List<PhoneNumber> Phones { get; set; }

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
    public List<Child> Children { get; set; }

    /// <summary>
    /// Gets the average age of person's children in years.
    /// </summary>
    /// <returns>The average age in years.</returns>
    public byte GetChildrenAverageAgeInYears()
    {
        if (this.Children.Count == 0)
        {
            return 0;
        }

        int childrenSummaryAge = 0;
        foreach (Child child in this.Children)
        {
            childrenSummaryAge += child.GetAgeInYears();
        }

        int averageAge = childrenSummaryAge / this.Children.Count;
        return Convert.ToByte(averageAge);
    }
}
