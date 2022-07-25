using Xunit;
using System;
using System.Collections.Generic;
using ORION.DataAccess.Strategy;
using ORION.DataAccess.Models;

namespace ORION.Admin.UnitTests.Models
{
    public class DefaultDaysInOfficeStrategyTest
    {
        private IDaysInOfficeStrategy _SystemUnderTest;
        public IDaysInOfficeStrategy SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new DefaultDaysInOfficeStrategy();
                }

                return _SystemUnderTest;
            }
        }

        [Fact]
        public void DaysInOffice_ZeroTermsInOffice()
        {
            var terms = new List<Term>();

            int actual = SystemUnderTest.GetDaysInOffice(terms);

            Assert.Equal<int>(0, actual);
        }

        [Fact]
        public void DaysInOffice_SingleTermOfOneDay()
        {
            var terms = new List<Term>();

            var term = new Term()
            {
                StartOfTerm = DateTime.Now,
                EndOfTerm = DateTime.Now.AddDays(1)
            };

            terms.Add(term);

            int actual = SystemUnderTest.GetDaysInOffice(terms);

            Assert.Equal<int>(1, actual);
        }

        [Fact]
        public void DaysInOffice_SingleTermOfFourYears()
        {
            var terms = new List<Term>();

            var term = new Term()
            {
                StartOfTerm = DateTime.Now,
                EndOfTerm = DateTime.Now.AddYears(4)
            };

            terms.Add(term);

            int actual = SystemUnderTest.GetDaysInOffice(terms);

            Assert.Equal<int>(DurationOfFourYearTerm, actual);
        }

        [Fact]
        public void DaysInOffice_TwoTermOfOneDay()
        {
            var terms = new List<Term>();

            var term1 = new Term()
            {
                StartOfTerm = DateTime.Now,
                EndOfTerm = DateTime.Now.AddDays(1)
            };

            var term2 = new Term()
            {
                StartOfTerm = DateTime.Now,
                EndOfTerm = DateTime.Now.AddDays(1)
            };

            terms.Add(term1);
            terms.Add(term2);

            int actual = SystemUnderTest.GetDaysInOffice(terms);

            Assert.Equal<int>(2, actual);
        }

        private const int DurationOfFourYearTerm = (365 * 4) + 1;
    }
}
