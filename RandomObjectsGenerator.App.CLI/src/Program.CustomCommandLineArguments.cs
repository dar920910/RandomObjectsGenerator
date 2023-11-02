// ---------------------------------------------------------------------------------------------------------
// <copyright file="Program.CustomCommandLineArguments.cs" company="Demo Projects Workshop">
// Copyright (c) Demo Projects Workshop. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>
// ---------------------------------------------------------------------------------------------------------

/// <summary>
/// Defines the <see cref="Program"/> class of the console application.
/// </summary>
internal partial class Program
{
    private const string CustomCountOfObjectsParameter = "--count=";
    private const uint DefaultCountOfObjects = 10_000;

    /// <summary>
    /// Retrieves the user-defined count of objects from program's command-line arguments.
    /// </summary>
    /// <param name="arguments">The array of command-line arguments passed to the program.</param>
    /// <returns>The target count of objects passed by a user via the 'count' command-line parameter.</returns>
    internal static uint RetrieveTargetCountParameterValueFromCommandLineArguments(string[] arguments)
    {
        uint targetCountOfObjects = DefaultCountOfObjects;

        if (arguments.Length > 0)
        {
            foreach (string argument in arguments)
            {
                if (argument.StartsWith(CustomCountOfObjectsParameter))
                {
                    string value = argument.Replace(CustomCountOfObjectsParameter, string.Empty);

                    if (uint.TryParse(value, out uint result))
                    {
                        targetCountOfObjects = result;
                    }
                }
            }
        }

        return targetCountOfObjects;
    }
}
