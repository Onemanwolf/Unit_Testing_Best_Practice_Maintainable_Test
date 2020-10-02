# Unit Testing Best Practice Maintainable Test

## Test Types

When we are testing we need to consider two things state or interaction. State to test if after the behavior is executed that the properties have the correct values or in the case of interaction wether the behavior or method was invoked or called a number of times.

## Check State or Behavior Invocation

We can check state for correct values which is a state test or we can test if a method or behavior was invoked with a interaction test.

## Test State

Test state after a method or behavior has exited to check if a property has the correct value.

## Test Invocation

Test Interaction to see if a method or behavior was called and how many times the method was called.



![Branch](https://github.com/Onemanwolf/Unit_Testing_Best_Practice_Maintainable_Test/blob/main/Images/State_Interaction.png?raw=true?raw=true 'Request Pipeline')



State Test

## Add Test example State

```C#
State test
```

- Measurable
- Most expose state
- Constraining access to tightly can make code heard to test and more tightly coupled

Make calls interceptable

- Make calls interceptable
- Make certain methods overridable
- Implement an interface

Different test implementations

- State
- Interaction test through class derivation
- Interaction test through interface

Resilience to change

- Class under test (Sut) will change later

Interaction test are fragile when production code is changing

- Change to code may affect interactions

- Interaction test which assume certain interaction is an over-specified test

General rules

- Use interaction test when concrete interaction is the requirement
- Use state tests to test effects

## Interaction Test

- Should test interactions and not implementation
- Proves the interactions occur
- Useful when interactions are required

Interaction Test which proves that dependency was used by object graph

```C#
     public class DoSomething{

     private IDependency _dependency;

     public DoSomething(IDependency dependency)

     public void Method(){
       var value =  _dependency.provideNeedValue();
     }


```

Implementation may change and stop using the dependency breaking test

The test will fail But the implementation is correct! (false positive)

So when testing

- Do not assume any particular implementation
- Verify effects of an operation
- Test Should not stand in the way of a changing implementation

## InterAction Test Here

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

White Box Testing

- Testing internal structure of the method
- Cover all distinct paths through the method
- Cover each of the execution branches in the method

Path vs Branches

- Number of paths grow exponentially
- Number of branches grow linearly
- Prefer Branch testing

[Path Vs Branch](https://sites.google.com/site/swtestingconcepts/home/test-design-techniques/for-white-box/statement-branch-and-path-coverage)

## Remeber

Test do not prove the code is correct the prove that code is functioning in one particular way.

```C#
//Branch if statement
if(id == null){
    //Branch id = GetId();
    id = GetId();

}

```

## Team Testing Review
```C#
public class DoSomething{

        public int ReturnedTarget {get; set;}

        void AddTarget(AddService service, int value){
                //interaction test if Add AddService method was called

            //test State to see if the expect value was set or returned from the method after calling
            this.ReturnedTarget = service.Add(value)
        }



}

```