using Cats.Logic.Validators;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Cats.Logic.Tests.Validators
{
    public class GetBreedsValidatorTests
    {
        private GetBreedsValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new GetBreedsValidator();
        }

        [Test]
        public void SearchTerm_Empty_Invalid()
        {
            var searchTerm = "";

            validator.TestValidate(searchTerm, strategy => strategy.IncludeAllRuleSets())
                .ShouldHaveValidationErrorFor(s => s);
        }

        [Test]
        public void SearchTerm_Over50Chars_Invalid()
        {
            var searchTerm = new string('a', 51);

            validator.TestValidate(searchTerm, strategy => strategy.IncludeAllRuleSets())
                .ShouldHaveValidationErrorFor(s => s);
        }

        [Test]
        public void SearchTerm_50Chars_Valid()
        {
            var searchTerm = new string('a', 50);

            validator.TestValidate(searchTerm, strategy => strategy.IncludeAllRuleSets())
                .ShouldNotHaveValidationErrorFor(s => s);
        }

        [Test]
        public void SearchTerm_Under50Chars_Valid()
        {
            var searchTerm = new string('a', 49);

            validator.TestValidate(searchTerm, strategy => strategy.IncludeAllRuleSets())
                .ShouldNotHaveValidationErrorFor(s => s);
        }
    }
}
