//---------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.Salary.cs" company="Demo Projects Workshop">
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
    private static decimal GetRandomMonthlySalarySizeInRussianRubles()
    {
        const int minimumThousandsOfRubles = 20;
        const int maximumThousandsOfRubles = 500;
        const int thousandOfRubles = 1000;

        int randomThoudandsOfRubles = Random.Shared.Next(minimumThousandsOfRubles, maximumThousandsOfRubles);
        return Convert.ToDecimal(randomThoudandsOfRubles * thousandOfRubles);
    }
}
