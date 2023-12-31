// ---------------------------------------------------------------------------------------------------------
// <copyright file="PersonGenerator.Implementation.AgeAndDates.cs" company="Demo Projects Workshop">
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
    private static byte GetRandomAdultAgeInYears(Gender gender)
    {
        const byte startAdultAge = 18;
        const byte retirementFemaleAge = 60;
        const byte retirementMaleAge = 65;

        if (gender == Gender.Female)
        {
            int randomNumber = Random.Shared.Next(startAdultAge, retirementFemaleAge);
            return Convert.ToByte(randomNumber);
        }
        else
        {
            // Else person's gender is 'Gender.Male' (the program serves only traditional gender types).
            int randomNumber = Random.Shared.Next(startAdultAge, retirementMaleAge);
            return Convert.ToByte(randomNumber);
        }
    }

    private static byte GetRandomChildAgeInYears()
    {
        const byte startChildAge = 0;
        const byte endChildAge = 18;

        int randomNumber = Random.Shared.Next(startChildAge, endChildAge);
        return Convert.ToByte(randomNumber);
    }

    private static long GetRandomBirthDate(byte ageInYears)
    {
        DateTime now = DateTime.Now;
        int birthYear = now.Year - ageInYears;

        const int calendarFirstYearMonthIndex = 1;
        const int calendarLastYearMonthIndex = 12;
        int birthMonth = Random.Shared.Next(calendarFirstYearMonthIndex, calendarLastYearMonthIndex + 1);

        const int calendarFirstMonthDayIndex = 1;
        const int calendarLastMonthDayIndex = 31;
        int birthDay = Random.Shared.Next(calendarFirstMonthDayIndex, calendarLastMonthDayIndex + 1);

        DateTime birthDate = GetValidDateTime(birthYear, birthMonth, birthDay);
        DateTimeOffset dateTimeOffset = new (birthDate);
        return dateTimeOffset.ToUnixTimeSeconds();
    }

    private static DateTime GetValidDateTime(int randomYear, int randomMonth, int randomDay)
    {
        DateTime validDateTime;

        try
        {
            validDateTime = new DateTime(year: randomYear, month: randomMonth, day: randomDay);
        }
        catch (ArgumentOutOfRangeException)
        {
            /* Comments to processing the 'ArgumentOutOfRangeException' exception.
             * The 'ArgumentOutOfRangeException' exception can be thrown when occuring anomal situations.
             * These situations are caused by attempts to create an invalid DateTime object for dates like the 'February, 31'.
             * If the program throws this exception, the following code will be do the following actions:
             * 1. Generate a random day value except of the '29', '30', '31' day values from possible values.
             * 2. Execute the recursive method call while creation of the valid DateTime object.
            */

            int validDayNumber = GetDayValueAvailableForEveryMonthInYear();
            validDateTime = GetValidDateTime(randomYear, randomMonth, validDayNumber);
        }

        return validDateTime;
    }

    private static int GetDayValueAvailableForEveryMonthInYear()
    {
        const int calendarFirstMonthDayIndex = 1;
        const int calendarLastMonthDayIndex = 28;

        return Random.Shared.Next(calendarFirstMonthDayIndex, calendarLastMonthDayIndex + 1);
    }
}
