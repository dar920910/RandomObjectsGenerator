//---------------------------------------------------------------------------
// <copyright file="PersonGenerator.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.Core;

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Implements the generator for objects of the Person class.
/// </summary>
public static class PersonGenerator
{
    /// <summary>
    /// Generates test Person objects in the specified count (only for testing aims).
    /// </summary>
    /// <param name="count">The target count of instances of the object to creation.</param>
    /// <returns>The array of the Person objects.</returns>
    public static Person[] GenerateTestObjects(uint count)
    {
        Person person = new ()
        {
            Id = 0,
            SequenceId = 0,
            TransportId = Guid.NewGuid(),
            FirstName = "Person's First Name",
            LastName = "Person's Last Name",
            Gender = Gender.Male,
            Age = 100,
            BirthDate = 100_000,
            CreditCardNumbers = Array.Empty<string>(),
            Phones = Array.Empty<string>(),
            Salary = 100_000M,
            IsMarried = false,
            Children = Array.Empty<Child>(),
        };

        List<Person> persons = new ();

        for (int i = 0; i < 5; i++)
        {
            persons.Add(person);
        }

        return persons.ToArray();
    }
}
