//---------------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

using RandomObjectsGenerator.Library.Core;
using RandomObjectsGenerator.Library.TargetModels;
using static System.Console;

const int targetCountOfObjects = 10;

// Step # 1.
WriteLine($"Creating a collection from {targetCountOfObjects} randomly generated Person objects in memory ...");
Person[] persons = PersonGenerator.GenerateTestObjects(targetCountOfObjects);

// Step # 2.
WriteLine("Serializing the collection to the JSON format ...");

// Step # 3.
WriteLine("Writing the serialization result to the current user desktop directory into the 'Persons.json' text file ...");

// Step # 4.
WriteLine("Clearing the collection from the database in-memory ...");

// Step # 5.
WriteLine("Reading serialized objects from the 'Persons.json' text file");

// Step # 6.
WriteLine("Printing persons' count, credit card count, and the average values of child age ...");
foreach (Person person in persons)
{
    WriteLine($"Person {person.FirstName} {person.LastName} has {person.CreditCardNumbers.Length}.");
}
