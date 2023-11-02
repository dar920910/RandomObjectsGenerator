// ---------------------------------------------------------------------------------------------------------
// <copyright file="ChildTest.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.TargetModels.UnitTests;

using Xunit;
using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Contains unit tests for the <see cref="Child"/> class.
/// </summary>
public class ChildTest
{
    private const string ChildFirstNamePlaceholder = "TestChildFirstName";
    private const string ChildLastNamePlaceholder = "TestChildLastName";

    /// <summary>
    /// Checks calculation of child's age in years.
    /// </summary>
    /// <param name="childBirthYear">The actual year of child's birth.</param>
    /// <param name="expectedAge">The expected age of a child.</param>
    [Theory]
    [InlineData(2023, 0)]
    [InlineData(2018, 5)]
    [InlineData(2013, 10)]
    [InlineData(2003, 20)]
    [InlineData(1993, 30)]
    public void GetChildAgeInYearsTheory(int childBirthYear, byte expectedAge)
    {
        const int childBirthMonth = 6;
        const int childBirthDay = 1;

        byte actualAge = new Child(
            id: default,
            gender: Gender.Male,
            birthDateTime: new DateTime(childBirthYear, childBirthMonth, childBirthDay),
            lastName: ChildLastNamePlaceholder,
            firstName: ChildFirstNamePlaceholder)
        .GetAgeInYears();

        Assert.Equal(expectedAge, actualAge);
    }
}
