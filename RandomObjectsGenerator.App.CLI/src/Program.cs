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

// Generate random Person collection and save it to the database in-memory.
uint targetCountOfObjects = RetrieveTargetCountParameterValueFromCommandLineArguments(args);
DatabaseContext databaseInMemory = new ();
CreateRandomPersonsIntoInMemoryStorage(targetCountOfObjects, databaseInMemory);

// Write this Person collection to the JSON file and then remove it from the database in-memory.
string personsJsonFilePath = GetPersonsOutputFilePathByDefault();
SerializePersonsToJsonTextFile(databaseInMemory, personsJsonFilePath);
RemoveAllPersonsFromInMemoryStorage(databaseInMemory);

// Read the serialized Person collection from the JSON file and then print its summary info to console.
List<Person> persons = DeserializePersonsFromJsonTextFile(personsJsonFilePath);
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

void SerializePersonsToJsonTextFile(DatabaseContext storageOfPersons, string filePath)
{
    Console.WriteLine("Serializing the collection to the JSON format ...");
    SerializationManager.SaveToJsonTextFile(storageOfPersons.Persons.ToList(), filePath);
    Console.WriteLine();
}

List<Person> DeserializePersonsFromJsonTextFile(string filePath)
{
    Console.WriteLine("Reading serialized objects from the JSON text file ...");
    Console.WriteLine();

    List<Person> persons;

    if (File.Exists(filePath))
    {
        persons = SerializationManager.ReadFromJsonTextFile(filePath);
        Console.WriteLine($"Success: Finished deserialization from the JSON file: '{filePath}'");
    }
    else
    {
        Console.WriteLine("Error: Cannot deserialize non-existing file !");
        persons = new List<Person>();
    }

    Console.WriteLine();
    return persons;
}
