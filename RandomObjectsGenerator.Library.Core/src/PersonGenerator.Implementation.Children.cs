// ---------------------------------------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.Children.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.Core;

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Implements the generator for objects of the <see cref="Person"/> class.
/// </summary>
public static partial class PersonGenerator
{
    private static byte GetRandomChildrenCount()
    {
        const byte minimumChildrenCount = 0;
        const int maximumChildrenCount = 10;

        return Convert.ToByte(Random.Shared.Next(minimumChildrenCount, maximumChildrenCount + 1));
    }

    private static List<Child> GetRandomChildren(byte count, string parentLastName)
    {
        List<Child> chilren = new ();

        for (int childNumber = 0; childNumber < count; childNumber++)
        {
            bool isFemaleChild = GetRandomBooleanValue();
            Gender childGender = isFemaleChild ? Gender.Female : Gender.Male;
            string childFirstName = GetRandomFirstNamePlaceholder(childGender);

            byte childAgeInYears = GetRandomChildAgeInYears();
            long childBirthDate = GetRandomBirthDate(childAgeInYears);

            Child child = new ()
            {
                Guid = Guid.NewGuid(),
                Id = childNumber,
                Gender = childGender,
                BirthDate = childBirthDate,
                LastName = parentLastName,
                FirstName = childFirstName,
            };

            chilren.Add(child);
        }

        return chilren;
    }
}
