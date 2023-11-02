// ---------------------------------------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.Salary.cs" company="Demo Projects Workshop">
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
    private const int MinimumThousandsOfCurrencyUnits = 20;
    private const int MaximumThousandsOfCurrencyUnits = 500;
    private const int ThousandOfCurrencyUnits = 1000;

    private static decimal GetRandomMonthlySalarySizeInCurrencyUnits() =>
        Convert.ToDecimal(GetRandomThousandCountOfCurrencyUnits() * ThousandOfCurrencyUnits);

    private static int GetRandomThousandCountOfCurrencyUnits() =>
        Random.Shared.Next(MinimumThousandsOfCurrencyUnits, MaximumThousandsOfCurrencyUnits + 1);
}
