// ---------------------------------------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.TestPlaceholders.cs" company="Demo Projects Workshop">
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
    private const int TestFirstNamesCount = 50;
    private const int TestLastNamesCount = 100;

    private static readonly string[] TestFemaleFirstNamesPlaceholders;
    private static readonly string[] TestMaleFirstNamesPlaceholders;
    private static readonly string[] TestLastNamesPlaceholders;

    private static string[] GenerateFemaleFirstNames()
    {
        List<string> names = new ();

        for (int femaleFirstNameIndex = 0; femaleFirstNameIndex < TestFirstNamesCount; femaleFirstNameIndex++)
        {
            string placeholder = "FemaleFirstName_" + femaleFirstNameIndex.ToString();
            names.Add(placeholder);
        }

        return names.ToArray();
    }

    private static string[] GenerateMaleFirstNames()
    {
        List<string> names = new ();

        for (int maleFirstNameIndex = 0; maleFirstNameIndex < TestFirstNamesCount; maleFirstNameIndex++)
        {
            string placeholder = "MaleFirstName_" + maleFirstNameIndex.ToString();
            names.Add(placeholder);
        }

        return names.ToArray();
    }

    private static string[] GenerateLastNames()
    {
        List<string> names = new ();

        for (int personLastNameIndex = 0; personLastNameIndex < TestLastNamesCount; personLastNameIndex++)
        {
            string placeholder = "LastName_" + personLastNameIndex.ToString();
            names.Add(placeholder);
        }

        return names.ToArray();
    }
}
