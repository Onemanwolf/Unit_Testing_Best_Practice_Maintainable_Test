using System;

namespace Math
{
    public interface IMathClass
    {
        int Result { get; set; }

        int Add(int a, int b);
        void SetResults(int a, int b, string op);
    }

    public class MathClass : IMathClass
    {
        public int Result { get; set; }

        public int Add(int a, int b) => (a + b);
        public int Subtract(int a, int b) => (a - b);

        public int Divide(int a, int b) => (a / b);

        public int Multiple(int a, int b) => (a * b);



        public void SetResults(int a, int b, string op)
        {
            if(op == "add")
            this.Result = Add(a, b);

            if(op == "subtract")
            this.Result = Subtract(a, b);

            if(op == "divide")
            this.Result = Divide(a, b);

            if(op == "multiple")
            this.Result = Multiple(a, b);
        }


    }





}
