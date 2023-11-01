//---------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.RandomNames.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.Core;

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Implements the generator for objects of the <see cref="Person"/> class.
/// </summary>
public static partial class PersonGenerator
{
    private static string GetRandomFirstNamePlaceholder(Gender gender)
    {
        int randomFirstNameIndex = Random.Shared.Next(0, TestFirstNamesCount);

        if (gender == Gender.Female)
        {
            return TestFemaleFirstNamesPlaceholders[randomFirstNameIndex];
        }
        else // person's gender is 'Gender.Male'
        {
            return TestMaleFirstNamesPlaceholders[randomFirstNameIndex];
        }
    }

    private static string GetRandomLastNamePlaceholder()
    {
        int randomIndex = Random.Shared.Next(0, TestLastNamesPlaceholders.Length);
        return TestLastNamesPlaceholders[randomIndex];
    }
}
