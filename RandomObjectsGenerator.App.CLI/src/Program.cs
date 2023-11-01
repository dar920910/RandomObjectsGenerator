//---------------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

using RandomObjectsGenerator.Library.Core;
using RandomObjectsGenerator.Library.DatabaseContext.InMemory;
using RandomObjectsGenerator.Library.Serialization;
using RandomObjectsGenerator.Library.TargetModels;
using static System.Console;

const string customCountOfObjectsParameter = "--count=";
const uint defaultCountOfObjects = 10_000;

uint targetCountOfObjects = defaultCountOfObjects;

if (args.Length > 0)
{
    foreach (string arg in args)
    {
        if (arg.StartsWith(customCountOfObjectsParameter))
        {
            string value = arg.Replace(customCountOfObjectsParameter, string.Empty);

            if (uint.TryParse(value, out uint result))
            {
                targetCountOfObjects = result;
            }
        }
    }
}

WriteLine($"Creating a collection from {targetCountOfObjects} randomly generated Person objects in memory ...");
DatabaseContext databaseInMemory = new ();
for (int personIndex = 0; personIndex < targetCountOfObjects; personIndex++)
{
    Person person = PersonGenerator.CreateRandomPerson(personIndex);
    databaseInMemory.Persons.Add(person);
}

databaseInMemory.SaveChanges();
WriteLine();

WriteLine("Serializing the collection to the JSON format ...");
SerializationManager.SaveToJsonTextFile(databaseInMemory.Persons.ToList());
WriteLine();

WriteLine("Clearing the collection from the database in-memory ...");
foreach (var person in databaseInMemory.Persons)
{
    databaseInMemory.Persons.Remove(person);
}

databaseInMemory.SaveChanges();
WriteLine();

WriteLine("Reading serialized objects from the JSON text file");
List<Person> persons = SerializationManager.ReadFromJsonTextFile();
foreach (Person person in persons)
{
    WriteLine($"Person {person.Id}: '{person.FirstName} {person.LastName}'");
}

WriteLine();

WriteLine("Printing persons' count, credit card count, and the average values of child age ...");
foreach (Person person in persons)
{
    WriteLine("---------------------------------------------------------------------------");
    WriteLine($"Person # {person.Id}: {person.FirstName} {person.LastName}");
    WriteLine($"   Credit Cards: {person.CreditCardNumbers.Count}");
    WriteLine($"   Average Age of Children: {person.GetChildrenAverageAgeInYears()}");
}

WriteLine();
