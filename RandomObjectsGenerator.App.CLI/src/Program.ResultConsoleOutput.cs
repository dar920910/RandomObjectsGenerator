//---------------------------------------------------------------------------
// <copyright file="Program.ResultConsoleOutput.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Defines the <see cref="Program"/> class of the console application.
/// </summary>
internal partial class Program
{
    /// <summary>
    /// Prints the summary information about a collection of the Person objects to console.
    /// </summary>
    /// <param name="persons">The list of objects which are instances of the <see cref="Person"/> class.</param>
    internal static void PrintPersonCollectionSummaryInfo(List<Person> persons)
    {
        Console.WriteLine("*** Summary Information about the Created Person Collection ***");
        Console.WriteLine();

        Console.WriteLine($"Read Count of Persons: {persons.Count}");
        Console.WriteLine();

        foreach (Person person in persons)
        {
            Console.WriteLine(GetDelimiterLineBetweenPersonInfo());
            Console.WriteLine($"Person # {person.Id}: {person.FirstName} {person.LastName}");
            Console.WriteLine($"   The Count of Person's Credit Cards: {person.CreditCardNumbers.Count} cards.");
            Console.WriteLine($"   The Average Age of Person's Children: {person.GetChildrenAverageAgeInYears()} years.");
        }

        Console.WriteLine(GetDelimiterLineBetweenPersonInfo());
        Console.WriteLine();
    }

    private static string GetDelimiterLineBetweenPersonInfo()
    {
        const char delimiterSymbol = '-';
        const byte delimiterLength = 75;

        return new string(delimiterSymbol, delimiterLength);
    }
}
