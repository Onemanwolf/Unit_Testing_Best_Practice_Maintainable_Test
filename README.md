# Unit Testing Best Practice Maintainable Test UnderStanding Test Types

## Test Types

When we are testing we need to consider two things, state or interaction. State is used to test if after the behavior is executed that the properties have the correct values or the system under test is in the right state. In the case of interaction wether the behavior or method was invoked or called a number of times.

Interaction we are not trying to test the Object Graph but the system under test.

## Check State or Behavior Invocation

We can check state for correct values which is a state test or we can test if a method or behavior was invoked with a interaction test.

## Test State

Test state after a method or behavior has completed to check if a property has the correct value to ensure that the System under test is in the correct State. State test tend to by less brittle that interaction test.

## Test Invocation

Test Interaction to see if a method or behavior was called and how many times the method was called.

![Branch](https://github.com/Onemanwolf/Unit_Testing_Best_Practice_Maintainable_Test/blob/main/Images/State_Interaction.png?raw=true?raw=true 'Request Pipeline')

# State Test

### Test example State


```C#
       [Fact]
        public void Add () {

            var result = _sut.Add (1, 2);

            result.Should ().Be (3);
        }
```

## State Test

- Measurable
- Must expose state
- Constraining access to tightly can make code heard to test and more tightly coupled

### Make calls interceptable

- Make calls interceptable
- Make certain methods overrideable (for mocking concrete class but avoid by using interface instead)
- Implement an interface

### Different test implementations Best pratices

- State use concrete system under test
- Interaction test through interface

### Resilience to change

- Class under test (Sut) will change later
  - Use AutoFixture to handle changes where possible

### Interaction test are fragile when production code is changing

- Changes to code may affect interactions making Interaction test more brittle

- Interaction test which assume certain interaction is an over-specified test

### General rules

- Use interaction test when concrete interaction is the requirement
- Use state tests to test effects of behavior

# Interaction Test

### Interaction test

- Should test interactions and not implementation
- Proves the interactions occur
- Useful when interactions are required

### Interaction Test which proves that dependency was used by object graph

```C#
     public class DoSomething{

     private IDependency _dependency;

     public DoSomething(IDependency dependency)

     public void Method(){
       var value =  _dependency.provideNeedValue();
     }

```

### Implementation may change and stop using the dependency breaking test

- Setup Mocking of dependencies in the constructor of test configuration factory class

```C#
public class CalculatorShould {

        private Fixture _fixture;
        private Mock<ICalculatorViewModel> _mockCalculatorViewModel;

        private DecimalCalculator _sut;

        public CalculatorShould () {

            this._fixture = new Fixture ();

            this._mockCalculatorViewModel = new Mock<ICalculatorViewModel> ();

            this._sut = new DecimalCalculator (_mockCalculatorViewModel);

        }

```

### The test will fail But the implementation is correct! (false positive)

### So when testing

- Do not assume any particular implementation
- Verify effects of an operation
- Test Should not stand in the way of a changing implementation

### InterAction Test Example

```C#

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
```

## Regression

- When implementation changes and test break
- Avoid by using tools like AutoFixture, Mock
- Setup Dependency Graphs in your Test Class Constructor

# White Box Testing

### White Box testing test internals of class

- Testing internal structure of the method
- Cover all distinct paths through the method
- Cover each of the execution branches in the method

### Path vs Branches

- Number of paths grow exponentially
- Number of branches grow linearly
- Prefer Branch testing

## Branch

```C#
//Branch if statement
if(id == null){
    //Branch id = GetId();
    id = GetId();

}

```

[Path Vs Branch](https://sites.google.com/site/swtestingconcepts/home/test-design-techniques/for-white-box/statement-branch-and-path-coverage)

## Remeber

Test do not prove the code is correct the prove that code is functioning in one particular way.

## Team Testing Review Discussion

### Lets examine some of the test you have created and determine if it is a State or Interaction test
