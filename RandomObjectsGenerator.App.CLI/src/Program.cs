//---------------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

using RandomObjectsGenerator.Library.Core;
using RandomObjectsGenerator.Library.DatabaseContext.InMemory;
using RandomObjectsGenerator.Library.TargetModels;
using static System.Console;

const int targetCountOfObjects = 10;
const string targetOutputFileName = "Persons.txt";

DatabaseContext databaseInMemory = new ();

WriteLine($"Step # 1: Creating a collection from {targetCountOfObjects} randomly generated Person objects in memory ...");

for (int personIndex = 0; personIndex < targetCountOfObjects; personIndex++)
{
    Person person = PersonGenerator.CreateRandomPerson(personIndex);
    databaseInMemory.Persons.Add(person);
}

databaseInMemory.SaveChanges();
WriteLine();

WriteLine("Step # 2: Serializing the collection to the JSON format ...");

WriteLine();

WriteLine($"Step # 3: Writing the serialization result to the current user desktop directory into the '{targetOutputFileName}' text file ...");

string outputFolderPath = (Environment.OSVersion.Platform == PlatformID.Win32NT) ?
    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : Environment.CurrentDirectory;
WriteLine($"Output Folder Path: '{outputFolderPath}'");
string outputFilePath = Path.Combine(outputFolderPath, targetOutputFileName);

StreamWriter stream = new (outputFilePath);

foreach (Person person in databaseInMemory.Persons)
{
    stream.WriteLine($"Person {person.Id}: '{person.FirstName} {person.LastName}'");
}

stream.Close();
WriteLine();

WriteLine("Step # 4: Clearing the collection from the database in-memory ...");

foreach (var person in databaseInMemory.Persons)
{
    databaseInMemory.Persons.Remove(person);
}

databaseInMemory.SaveChanges();
WriteLine();

WriteLine("Step # 5: Reading serialized objects from the 'Persons.json' text file");

string[] personRecords = File.ReadAllLines(outputFilePath);
WriteLine();

WriteLine("Step # 6: Printing persons' count, credit card count, and the average values of child age ...");

foreach (Person person in databaseInMemory.Persons)
{
    WriteLine($"Person: {person.Id} {person.FirstName} {person.LastName}");
}

foreach (string personRecord in personRecords)
{
    WriteLine(personRecord);
}

WriteLine();
