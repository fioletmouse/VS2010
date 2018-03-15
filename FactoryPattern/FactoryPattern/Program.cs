using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPattern
{
    class Program
    {
        interface IProduct
        {
            string GetType1();
        }

        class ConcreteProductA : IProduct
        {
            public string GetType1() { return "ConcreteProductA"; }
        }

        class ConcreteProductB : IProduct
        {
            public string GetType1() { return "ConcreteProductB"; }
        }



        abstract class Creator
        {
            public abstract IProduct FactoryMethod();
        }

        class ConcreteCreatorA : Creator
        {
            public override IProduct FactoryMethod() { return new ConcreteProductA(); }
        }

        class ConcreteCreatorB : Creator
        {
            public override IProduct FactoryMethod() { return new ConcreteProductB(); }
        }



        static void Main(string[] args)
        {
            // an array of creators
            Creator[] creators = { new ConcreteCreatorA(), new ConcreteCreatorB() };
            // iterate over creators and create products
            foreach (Creator creator in creators)
            {
                IProduct product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType1());
            }
            // Wait for user
            Console.Read();
        }
    }
}
