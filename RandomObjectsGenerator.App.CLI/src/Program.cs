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

uint targetCountOfObjects = RetrieveTargetCountParameterValueFromCommandLineArguments(args);
DatabaseContext databaseInMemory = new ();

CreateRandomPersonsIntoInMemoryStorage(targetCountOfObjects, databaseInMemory);

SerializePersonsFromInMemoryStorage(databaseInMemory);

RemoveAllPersonsFromInMemoryStorage(databaseInMemory);

List<Person> persons = DeserializePersonsFromJsonTextFile();

PrintPersonCollectionSummaryInfo(persons);

void CreateRandomPersonsIntoInMemoryStorage(uint countOfPersons, DatabaseContext storageOfPersons)
{
    Console.WriteLine($"Creating a collection from {countOfPersons} randomly generated Person objects in memory ...");

    for (int personIndex = 0; personIndex < targetCountOfObjects; personIndex++)
    {
        Person person = PersonGenerator.CreateRandomPerson(personIndex);
        storageOfPersons.Persons.Add(person);
    }

    storageOfPersons.SaveChanges();
    Console.WriteLine();
}

void SerializePersonsFromInMemoryStorage(DatabaseContext storageOfPersons)
{
    Console.WriteLine("Serializing the collection to the JSON format ...");
    SerializationManager.SaveToJsonTextFile(storageOfPersons.Persons.ToList());
    Console.WriteLine();
}

void RemoveAllPersonsFromInMemoryStorage(DatabaseContext storageOfPersons)
{
    Console.WriteLine("Clearing the collection from the database in-memory ...");

    foreach (var person in storageOfPersons.Persons)
    {
        storageOfPersons.Persons.Remove(person);
    }

    storageOfPersons.SaveChanges();
    Console.WriteLine();
}

List<Person> DeserializePersonsFromJsonTextFile()
{
    Console.WriteLine("Reading serialized objects from the JSON text file");
    Console.WriteLine();

    return SerializationManager.ReadFromJsonTextFile();
}
