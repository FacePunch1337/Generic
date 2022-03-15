using System;
using System.Linq;
using System.Collections.Generic;


namespace Generic
{
    class Program
    {
        
      
       class Element
        {
            public String Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        class ElementOne : Element
        {
            public ElementOne()
            {
                base.Name = "ElementOne";
            }
        }

        class ElementTwo : Element
        {
            public ElementTwo()
            {
                base.Name = "ElementTwo";
            }
        }

        class ElementThree : Element
        {
            public ElementThree()
            {
                base.Name = "ElementThree";
            }
        }

        class Set<T> where T : class
        {
            private static List<T> list = new List<T>();
            public bool Add<T2>() where T2 : T, new()
            {
                var tn = typeof(T).Name;

                if (!list.Any(x => x is T2))
                {
                   list.Add(new T2());
                }
                else throw new Exception($"The list cannot contain elements of the same type");

               

                return true;

            }

            public T2 Get<T2>() where T2 : class
            {
                
                foreach (T item in list)
                {
                    if (item is T2) return (T2) Convert.ChangeType(item, typeof(T2));
                }
                return null;
               


            }


            public void Print()
            {

                foreach (T item in list)
                {
                    Console.WriteLine(item);
                }

                


            }
        }


        private static Random random = new Random();

        class Number<T> where T : struct
        {
            public T Value { get; set; }
            public Number()
            {

            }
            public Number<T> Plus(Number<T> n)
            {
                var tn = typeof(T).Name;
                if (tn == "Int32")
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



            public static Number<T> operator +(Number<T> a, Number<T> b)
            {
                var tn = typeof(T).Name;
                if (tn == "Int32")
                {
                    return new Number<T>
                    {
                        Value = (T)(object)(Convert.ToInt32(a.Value) + Convert.ToInt32(b.Value))
                    };

                }

                if (tn == "Single")
                {
                    return new Number<T>
                    {
                        Value = (T)(object)(Convert.ToSingle(a.Value) + Convert.ToSingle(b.Value))
                    };

                }

                throw new Exception("Types noes not support");
            }

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
                    sum = n + n;
                    //sum = sum.Plus(n);
                }
                return sum;
            }


        }

        class MyClass
        {

            public MyClass()
            {
                if (random.Next(20) > 10) throw new Exception("error");
            }
        }


        private static T MakeInstance<T>() where T : class, new()
        {
            T ret;
            try
            {
                ret = new T();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = null;
            }

            return ret;

        }

        private static T MakeRandom<T>() where T : struct { 
            var tn = typeof(T).Name;
            if (tn == "Int32")
            {

                    return (T)(object)random.Next(100);

            }

            if (tn == "Single")
            {
                return (T)(object)Convert.ToSingle(random.NextDouble());
            }

            throw new Exception("error");
        }

        static void Main(string[] args)
        {
            Set<Element> set = new Set<Element>();
            set.Add<ElementOne>();
            set.Add<ElementTwo>();
            set.Add<ElementThree>();
            set.Add<ElementThree>();

   
            set.Print();
            Console.WriteLine("--------------------");
            var element1 = set.Get<ElementOne>();
            Console.WriteLine(element1);


            var element2 = set.Get<Random>();
            Console.WriteLine(element2 == null ? "null" : "not null");

            var element3 = set.Get<ElementThree>();
            Console.WriteLine(element3 == null ? "null" : "not null");
        }

        static void Main2(string[] args)
        {

            var x = MakeRandom<int>();
            var y = MakeRandom<float>();
            Console.WriteLine($"{x}\n{y}");
        }
    }

            
         

        /*static void Main1(string[] args)
        {
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

        }*/

}


