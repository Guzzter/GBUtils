using FluentAssertions;
using GBUtils.Extension;
using System;
using Xunit;

namespace GBUtils.Test.Extension
{
    internal enum Importance
    {
        None,
        Trivial,
        Regular,
        Important,
        Critical
    }

    public class WhenUsingEnumExtension
    {
        [Fact]
        public void Given_Enum_Expect_StringValue()
        {
            //Arrange Act Assert
            Importance.Important.ToStringName().Should().Be("Important");
        }

        [Fact]
        public void StringValueShouldBeConvertedToEnum()
        {
            "Critical".ToEnum<Importance>().Should().Be(Importance.Critical);
        }

        [Fact]
        public void UnknownShouldFallbackToDefaultWhenNotFound()
        {
            "Important".ToEnum(Importance.None).Should().Be(Importance.Important);
            "DoesNotMatch".ToEnum(Importance.None).Should().Be(Importance.None);
        }

        [Fact]
        public void UnknownShouldThrowExceptionWhenValueIsNotFoundInEnum()
        {
            //Act
            Action act = () => "Criticalx".ToEnum<Importance>();

            //Assert Exception
            act.Should().Throw<ArgumentException>()
                .WithMessage("Requested value 'Criticalx' was not found.");
        }
    }
}