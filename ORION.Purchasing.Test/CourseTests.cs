﻿using ORION.HumanResources.DataAccess.Entities;
using Xunit;

namespace ORION.HumanResources.Test
{
    public class CourseTests
    {
        [Fact]
        public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
        {
            // Arrange
            // nothing to see here

            // Act
            var course = new Course("Disaster Management 101");

            // Assert
            Assert.True(course.IsNew);
        }
    }
}
