//---------------------------------------------------------------------------
// <copyright file="PersonGenerator.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------

namespace RandomObjectsGenerator.Library.Core;

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Implements the generator for objects of the Person class.
/// </summary>
public static class PersonGenerator
{
    private const int TestFirstNamesCount = 50;
    private const int TestLastNamesCount = 100;

    private static readonly string[] TestFemaleFirstNamesPlaceholders;
    private static readonly string[] TestMaleFirstNamesPlaceholders;
    private static readonly string[] TestLastNamesPlaceholders;

    static PersonGenerator()
    {
        // Initialize 'TestFemaleFirstNamesPlaceholders'
        List<string> testNamesPlaceholders = new ();

        for (int femaleFirstNameIndex = 0; femaleFirstNameIndex < TestFirstNamesCount; femaleFirstNameIndex++)
        {
            string placeholder = "FemaleFirstName_" + femaleFirstNameIndex.ToString();
            testNamesPlaceholders.Add(placeholder);
        }

        TestFemaleFirstNamesPlaceholders = testNamesPlaceholders.ToArray();

        // Initialize 'TestMaleFirstNamesPlaceholders'
        testNamesPlaceholders.Clear();

        for (int maleFirstNameIndex = 0; maleFirstNameIndex < TestFirstNamesCount; maleFirstNameIndex++)
        {
            string placeholder = "MaleFirstName_" + maleFirstNameIndex.ToString();
            testNamesPlaceholders.Add(placeholder);
        }

        TestMaleFirstNamesPlaceholders = testNamesPlaceholders.ToArray();

        // Initialize 'TestLastNamesPlaceholders'
        testNamesPlaceholders.Clear();

        for (int personLastNameIndex = 0; personLastNameIndex < TestLastNamesCount; personLastNameIndex++)
        {
            string placeholder = "LastName_" + personLastNameIndex.ToString();
            testNamesPlaceholders.Add(placeholder);
        }

        TestLastNamesPlaceholders = testNamesPlaceholders.ToArray();
    }

    /// <summary>
    /// Generates a random instance of the Person class.
    /// </summary>
    /// <param name="personId">The unique identifier of the instance.</param>
    /// <returns>A randomly generated instance of the Person class.</returns>
    public static Person CreateRandomPerson(int personId)
    {
        bool isFemale = GetRandomBooleanValue();
        Gender personGender = isFemale ? Gender.Female : Gender.Male;
        byte personAge = GetRandomAdultAgeInYears(personGender);
        long personBirthDate = GetRandomBirthDate(personAge);

        string personFirstName = GetRandomFirstNamePlaceholder(personGender);
        string personLastName = GetRandomLastNamePlaceholder();

        string[] personCreditCards = GetRandomCreditCardsNumbers();
        string[] personPhones = GetRandomPhoneNumbers();
        decimal personSalary = GetRandomMonthlySalarySizeInRussianRubles();

        bool isMarriedPerson = GetRandomBooleanValue();

        byte personChildrenCount = GetRandomChildrenCount();
        Child[] personChildren = GetRandomChildren(personChildrenCount, personLastName);

        return new Person()
        {
            Id = personId,
            SequenceId = personId,

            Gender = personGender,
            Age = personAge,
            BirthDate = personBirthDate,

            FirstName = personFirstName,
            LastName = personLastName,

            CreditCardNumbers = personCreditCards,
            Phones = personPhones,
            Salary = personSalary,
            TransportId = Guid.NewGuid(),

            IsMarried = isMarriedPerson,
            Children = personChildren,
        };
    }

    private static Child[] GetRandomChildren(byte count, string parentLastName)
    {
        List<Child> chilren = new ();

        for (int childNumber = 0; childNumber < count; childNumber++)
        {
            bool isFemaleChild = GetRandomBooleanValue();
            Gender childGender = isFemaleChild ? Gender.Female : Gender.Male;
            string childFirstName = GetRandomFirstNamePlaceholder(childGender);

            byte childAgeInYears = GetRandomChildAgeInYears();
            long childBirthDate = GetRandomBirthDate(childAgeInYears);

            Child child = new ()
            {
                Id = childNumber,
                Gender = childGender,
                BirthDate = childBirthDate,
                LastName = parentLastName,
                FirstName = childFirstName,
            };

            chilren.Add(child);
        }

        return chilren.ToArray();
    }

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
        else // Else person's gender is 'Gender.Male' (the program serves only traditional gender types).
        {
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

        DateTime birthDate = new (birthYear, birthMonth, birthDay);
        DateTimeOffset dateTimeOffset = new (birthDate);
        return dateTimeOffset.ToUnixTimeSeconds();
    }

    private static bool GetRandomBooleanValue()
    {
        // This method can be used to generate both 'IsMarried' and 'Gender' properties of a person.
        int random = Random.Shared.Next();
        return random > int.MaxValue / 2;
    }

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

    private static string[] GetRandomCreditCardsNumbers()
    {
        const byte minumumCreditCardsCount = 1;
        const byte maximumCreditCardsCount = 10;

        int creditCardsCount = Random.Shared.Next(minumumCreditCardsCount, maximumCreditCardsCount);

        List<string> creditCards = new ();

        for (int cardIndex = 0; cardIndex < creditCardsCount; cardIndex++)
        {
            string card = GetRandomCardNumber();
            creditCards.Add(card);
        }

        return creditCards.ToArray();
    }

    private static string GetRandomCardNumber()
    {
        byte cardDigit_01 = GetRandomDigit();
        byte cardDigit_02 = GetRandomDigit();
        byte cardDigit_03 = GetRandomDigit();
        byte cardDigit_04 = GetRandomDigit();
        byte cardDigit_05 = GetRandomDigit();
        byte cardDigit_06 = GetRandomDigit();
        byte cardDigit_07 = GetRandomDigit();
        byte cardDigit_08 = GetRandomDigit();
        byte cardDigit_09 = GetRandomDigit();
        byte cardDigit_10 = GetRandomDigit();
        byte cardDigit_11 = GetRandomDigit();
        byte cardDigit_12 = GetRandomDigit();
        byte cardDigit_13 = GetRandomDigit();
        byte cardDigit_14 = GetRandomDigit();
        byte cardDigit_15 = GetRandomDigit();
        byte cardDigit_16 = GetRandomDigit();

        string cardNumberPart_1 = $"{cardDigit_01}{cardDigit_02}{cardDigit_03}{cardDigit_04}";
        string cardNumberPart_2 = $"{cardDigit_05}{cardDigit_06}{cardDigit_07}{cardDigit_08}";
        string cardNumberPart_3 = $"{cardDigit_09}{cardDigit_10}{cardDigit_11}{cardDigit_12}";
        string cardNumberPart_4 = $"{cardDigit_13}{cardDigit_14}{cardDigit_15}{cardDigit_16}";

        return $"{cardNumberPart_1} {cardNumberPart_2} {cardNumberPart_3} {cardNumberPart_4}";
    }

    private static byte GetRandomDigit()
    {
        return Convert.ToByte(Random.Shared.Next(0, 10));
    }

    private static string[] GetRandomPhoneNumbers()
    {
        const byte minumumPhonesCount = 1;
        const byte maximumPhonesCount = 10;

        int creditCardsCount = Random.Shared.Next(minumumPhonesCount, maximumPhonesCount);

        List<string> phones = new ();

        for (int phoneIndex = 0; phoneIndex < creditCardsCount; phoneIndex++)
        {
            string phone = GetRandomPhone();
            phones.Add(phone);
        }

        return phones.ToArray();
    }

    private static string GetRandomPhone()
    {
        byte phoneDigit_00 = GetRandomDigit();
        byte phoneDigit_01 = GetRandomDigit();
        byte phoneDigit_02 = GetRandomDigit();
        byte phoneDigit_03 = GetRandomDigit();
        byte phoneDigit_04 = GetRandomDigit();
        byte phoneDigit_05 = GetRandomDigit();
        byte phoneDigit_06 = GetRandomDigit();
        byte phoneDigit_07 = GetRandomDigit();
        byte phoneDigit_08 = GetRandomDigit();
        byte phoneDigit_09 = GetRandomDigit();
        byte phoneDigit_10 = GetRandomDigit();

        string phoneNumberPart_1 = $"{phoneDigit_01}{phoneDigit_02}{phoneDigit_03}";
        string phoneNumberPart_2 = $"{phoneDigit_04}{phoneDigit_05}{phoneDigit_06}";
        string phoneNumberPart_3 = $"{phoneDigit_07}{phoneDigit_08}";
        string phoneNumberPart_4 = $"{phoneDigit_09}{phoneDigit_10}";

        return $"+{phoneDigit_00} {phoneNumberPart_1}-{phoneNumberPart_2}-{phoneNumberPart_3}-{phoneNumberPart_4}";
    }

    private static decimal GetRandomMonthlySalarySizeInRussianRubles()
    {
        const int minimumThousandsOfRubles = 20;
        const int maximumThousandsOfRubles = 500;
        const int thousandOfRubles = 1000;

        int randomThoudandsOfRubles = Random.Shared.Next(minimumThousandsOfRubles, maximumThousandsOfRubles);
        return Convert.ToDecimal(randomThoudandsOfRubles * thousandOfRubles);
    }

    private static byte GetRandomChildrenCount()
    {
        const byte minimumChildrenCount = 0;
        const int maximumChildrenCount = 10;

        return Convert.ToByte(Random.Shared.Next(minimumChildrenCount, maximumChildrenCount + 1));
    }
}
