using backend.DomainObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace backendTests.DomainServices
{
    [TestFixture]
    public class CustomerTests
    {
        private const char TestFillChar = '#';

        private static string[] ValidNameTestStrings = new string[] {
            new string(TestFillChar, Customer.MaxNameLength - 2),
            new string(TestFillChar, Customer.MaxNameLength - 1),
            "a",
            "b",
            "abc"
        };

        private static string[] InvalidNameTestStrings = new string[] {
            new string(TestFillChar, Customer.MaxNameLength + 1),
            new string(TestFillChar, Customer.MaxNameLength * 2),
            null,
            string.Empty
        };


        
        private static IEnumerable<string> ValidCompanyNameTestStrings = ValidNameTestStrings.Concat(new string [] {
            string.Empty
        });

        private static IEnumerable<string> InvalidCompanyNameTestStrings = InvalidNameTestStrings.Except(new string [] {
            string.Empty
        });

        [TestCaseSource(nameof(InvalidNameTestStrings))]
        public void Domain_Validation_FirstNameInvalid(string invalidName)
        {
            var customer = getInitializedCustomer();
            customer.FirstName = invalidName;

            Assert.That(isDomainObjectValid(customer), Is.False);
        }

        [TestCaseSource(nameof(InvalidNameTestStrings))]
        public void Domain_Validation_LastNameInvalid(string invalidName)
        {
            var customer = getInitializedCustomer();
            customer.LastName = invalidName;

            Assert.That(isDomainObjectValid(customer), Is.False);
        }

        [TestCaseSource(nameof(InvalidCompanyNameTestStrings))]
        public void Domain_Validation_CompanyNameInvalid(string invalidName)
        {
            var customer = getInitializedCustomer();
            customer.CompanyName = invalidName;

            Assert.That(isDomainObjectValid(customer), Is.False);
        }
        
        [TestCaseSource(nameof(ValidNameTestStrings))]
        public void Domain_Validation_FirstNameValid(string validName)
        {
            var customer = getInitializedCustomer();
            customer.FirstName = validName;

            Assert.That(isDomainObjectValid(customer), Is.True);
        }

        [TestCaseSource(nameof(ValidNameTestStrings))]
        public void Domain_Validation_LastNameValid(string validName)
        {
            var customer = getInitializedCustomer();
            customer.LastName = validName;

            Assert.That(isDomainObjectValid(customer), Is.True);
        }

        [TestCaseSource(nameof(ValidCompanyNameTestStrings))]
        public void Domain_Validation_CompanyNameValid(string validName)
        {
            var customer = getInitializedCustomer();
            customer.CompanyName = validName;

            Assert.That(isDomainObjectValid(customer), Is.True);
        }

        private bool isDomainObjectValid(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);    
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);

            return validationResults.Count == 0;
        }

        private Customer getInitializedCustomer()
        {
            return new Customer()
            {
                FirstName = "testFirstName",
                LastName = "testLastName",
                CompanyName = "testCompanyName"
            };
        }
    }
}