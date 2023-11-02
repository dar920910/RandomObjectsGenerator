// ---------------------------------------------------------------------------------------------------------
// <copyright file="Program.ResultFileOutputSettings.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

using RandomObjectsGenerator.Library.TargetModels;

/// <summary>
/// Defines the <see cref="Program"/> class of the console application.
/// </summary>
internal partial class Program
{
    /// <summary>
    /// Gets the default path to the output text file for the generated collection of objects which are instances of the <see cref="Person"/> class.
    /// </summary>
    /// <returns>The default path to the output text file.</returns>
    internal static string GetPersonsOutputFilePathByDefault()
    {
        const string outputPersonsFileName = "Persons.json";

        string outputFolderPath = (Environment.OSVersion.Platform == PlatformID.Win32NT) ?
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : Environment.CurrentDirectory;

        return Path.Combine(outputFolderPath, outputPersonsFileName);
    }
}
