using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using FluentAssertions;
using Moq;
using Xunit;

namespace Math.Test {
    public class MathShould {

        public MathClass _sut { get; set; }
        public Mock<IMathClass> _mock;

        public MathShould () {
            _sut = new MathClass ();
            _mock = new Mock<IMathClass> ();
        }

        [Fact]
        public void Add () {

            var result = _sut.Add (1, 2);

            result.Should ().Be (3);
        }

        [Fact]
        public void AddWrong () {

            var result = _sut.Add (1, 2);

            result.Should ().Be (3);
        }

        [Fact]
        public void VoidMethodTest_SetResults_IsCalledOnce () {
            //Arrange
            var Result = 0;
            _mock.Setup (x => x.SetResults (It.IsAny<int> (), It.IsAny<int> (), It.IsAny<string> ())).Callback (() =>
                Result = 3);

            //Act
            _mock.Object.SetResults (1, 2, "add");

            //Assert
            //Interaction test
            _mock.Verify (s => s.SetResults (It.IsAny<int> (), It.IsAny<int> (), It.IsAny<string> ()), Times.Once);

        }

    }
}