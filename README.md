# Unit Testing Best Practice Maintainable Test

When we are testing we need to consider two things state to test if the behavior is executed as expected and the properties have the correct values or interaction wether the behavior or method was invoked

We can check state for correct values which is a state test or we can test if a method or behavior was invoked with a interaction test.

Test state after a method or behavior has exited to check if a property has the correct value.

Test Interaction to see if a method or behavoir was called and how many times the method was called.

![]()

![Branch](https://github.com/Onemanwolf/Code_Coverage_How_Session/blob/master/How_Session/Images/BranchCoverage.png?raw=true?raw=true 'Request Pipeline')



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

State Test

- Measurable
- Most expose state

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

Interaction Test

- Should test interactions and not implementation
- Proves the interactions occur
- Useful when interactions are required

Interaction Test which proves that dependency was used by object graph

Implementation may change and stop using the dependency breaking test

The test will fail But the implementation is correct! (false positive)

So when testing

- Do not assume any particular implementation
- Verify effects of an operation
- Test Should not stand in the way of a changing implementation

White Box Testing

- Testing internal structure of the method
- Cover all distinct paths through the method
- Cover each of the execution branches in the method

Path vs Branches

- Number of paths grow exponentially
- Number of branches grow linearly

Counting How many a method is interaction testing

Test do not prove the code is correct the prove that code is functioning in one particular way.

```C#
//Branch
if(value == 0){
    //Branch    value = -1;
}

```
