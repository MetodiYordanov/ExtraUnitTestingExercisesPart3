using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["John"] = 3,
            ["Mike"] = 2,
            ["Jeniffer"] = 6,
            ["Silvester"] = 4,
            ["Victoria"] = 5,
        };

        string expected = $"Jeniffer with average grade 6.00{Environment.NewLine}" +
            $"Victoria with average grade 5.00{Environment.NewLine}" +
            $"Silvester with average grade 4.00";

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>();
        string expected = string.Empty;

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["Silvester"] = 4,
            ["Victoria"] = 5,
        };

        string expected = $"Victoria with average grade 5.00{Environment.NewLine}" +
            $"Silvester with average grade 4.00";

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["John"] = 5,
            ["Mike"] = 5,
            ["Jeniffer"] = 5,
            ["Silvester"] = 5,
            ["Victoria"] = 5,
        };

        string expected = $"Jeniffer with average grade 5.00{Environment.NewLine}" +
            $"John with average grade 5.00{Environment.NewLine}" +
            $"Mike with average grade 5.00";

        // Act
        string result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
