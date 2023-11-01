//---------------------------------------------------------------------------
// <copyright file="PersonTest.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.TargetModels.UnitTests;

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Contains unit tests for the <see cref="Person"/> class.
/// </summary>
public class PersonTest
{
    private const string TestLastName = "Unknown_LastName";

    private readonly Person testPerson;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonTest"/> class.
    /// </summary>
    public PersonTest()
    {
        this.testPerson = new Person()
        {
            Id = 1,
            SequenceId = 1,

            Gender = Gender.Male,
            Age = 50,
            BirthDate = new DateTimeOffset(new DateTime(year: 1973, 12, 31)).ToUnixTimeSeconds(),

            FirstName = "Unknown_FirstName",
            LastName = TestLastName,

            CreditCardNumbers = new List<CreditCard>(),
            Phones = new List<PhoneNumber>(),
            Salary = 100000M,
            TransportId = Guid.NewGuid(),

            IsMarried = true,
            Children = new List<Child>(),
        };
    }

    /// <summary>
    /// Checks calculation of child's age in years.
    /// </summary>
    [Fact]
    public void GetChildAgeInYearsTest()
    {
        Child child = new (id: 0, gender: Gender.Male, birthDateTime: new DateTime(year: 2013, 10, 10), lastName: TestLastName, firstName: "TestChildName");

        byte expectedAge = 10;
        byte actualAge = child.GetAgeInYears();

        Assert.Equal(expectedAge, actualAge);
    }

    /// <summary>
    /// Checks the average age of person's children.
    /// </summary>
    [Fact]
    public void GetAverageAgeOfChildrenTest()
    {
        this.testPerson.Children = new ()
        {
            new (id: 1, gender: Gender.Male, birthDateTime: new DateTime(year: 1993, 5, 5), lastName: TestLastName, firstName: "ChildName_1"),
            new (id: 2, gender: Gender.Female, birthDateTime: new DateTime(year: 2003, 7, 7), lastName: TestLastName, firstName: "ChildName_2"),
            new (id: 3, gender: Gender.Male, birthDateTime: new DateTime(year: 2013, 9, 9), lastName: TestLastName, firstName: "ChildName_3"),
        };

        byte expectedAverageAgeInYears = 20;
        byte actualAverageAgeInYears = this.testPerson.GetChildrenAverageAgeInYears();

        Assert.Equal(expectedAverageAgeInYears, actualAverageAgeInYears);
    }

    /// <summary>
    /// Checks the average age of person's children when the person has no children.
    /// </summary>
    [Fact]
    public void GetAverageAgeOfChildrenWhenPersonHasNoChildren()
    {
        this.testPerson.Children = new List<Child>();
        byte childrenAverageAgeInYears = this.testPerson.GetChildrenAverageAgeInYears();
        Assert.Equal(expected: 0, actual: childrenAverageAgeInYears);
    }
}
