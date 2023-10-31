//---------------------------------------------------------------------------
// <copyright file="SerializationManager.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Provides static methods to execute JSON (de)serialization operations for objects of predefined models.
/// </summary>
public static class SerializationManager
{
    private const string OutputPersonsFileName = "Persons.json";

    /// <summary>
    /// Saves the specified Person objects to the JSON text file.
    /// </summary>
    /// <returns>The list of objects which are read as instances of the Person class.</returns>
    public static List<Person> ReadFromJsonTextFile()
    {
        string outputFilePath = GetOutputPersonsFilePath();

        List<Person> persons = new ();

        using (StreamReader stream = File.OpenText(outputFilePath))
        {
            JsonSerializer serializer = new ();
            persons = (List<Person>)serializer.Deserialize(stream, typeof(List<Person>));
        }

        return persons;
    }

    /// <summary>
    /// Saves the specified Person objects to the JSON text file.
    /// </summary>
    /// <param name="collection">The list of objects which are instances of the Person class.</param>
    public static void SaveToJsonTextFile(List<Person> collection)
    {
        string outputFilePath = GetOutputPersonsFilePath();

        using (StreamWriter stream = File.CreateText(outputFilePath))
        {
            DefaultContractResolver contractResolver = new ()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
                {
                    OverrideSpecifiedNames = false,
                },
            };

            string json = JsonConvert.SerializeObject(collection, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
            });

            stream.WriteLine(json);
        }
    }

    private static string GetOutputPersonsFilePath()
    {
        string outputFolderPath = (Environment.OSVersion.Platform == PlatformID.Win32NT) ?
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : Environment.CurrentDirectory;

        return Path.Combine(outputFolderPath, OutputPersonsFileName);
    }
}
