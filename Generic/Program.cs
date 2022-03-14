using System;
using System.Collections.Generic;

namespace Generic
{
    class Program
    {
        class Number<T> where T : struct
        {
            public T Value { get; set; }
            public Number()
            {
                    
            }
            
            public Number<T> Plus(Number<T> n)
            {
                var tn = typeof(T).Name;
                if(tn == "Int32")
                {
                    return new Number<T>
                    {
                        Value = (T)(object)(Convert.ToInt32(n.Value) + Convert.ToInt32(this.Value))
                    };


                }

                if (tn == "Single")
                {
                    return new Number<T>
                    {
                        Value = (T)(object)(Convert.ToSingle(n.Value) + Convert.ToSingle(this.Value))
                    };


                }

                throw new Exception("Types noes not support");
            }

            public static Number<T> operator +(Number<T> a, Number<T> b) => a + b;
            
    }

        class NumberArray<T> where T : struct
        {
            private List<Number<T>> numbers;

            public NumberArray()
            {
                numbers = new List<Number<T>>();
            }

            public void Add(Number<T> n)
            {
                numbers.Add(n);
            }

            public Number<T> Mean()
            {
                Number<T> sum = new Number<T>();
                foreach (var n in numbers)
                {
                    sum = sum.Plus(n);
                }
                return sum;
            }


        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            /*var x = new Number<int>() { Value = 10};
            var y = new Number<float>() { Value = .10f };*/

            var arr = new NumberArray<int>();
            arr.Add(new Number<int>() { Value = 10 });
            arr.Add(new Number<int>() { Value = 20 });
            arr.Add(new Number<int>() { Value = 30 });
            Console.WriteLine(arr.Mean().Value);

            var arrf = new NumberArray<float>();
            arrf.Add(new Number<float>() { Value = .10f });
            arrf.Add(new Number<float>() { Value = .20f });
            arrf.Add(new Number<float>() { Value = .30f });
            Console.WriteLine(arrf.Mean().Value);
           
        }

        
            
    }

}
