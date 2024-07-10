namespace DesignPrinciples_EncapsulateWhatVaries
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = Pizza.Order(PizzaConstants.HotDogPizza);
            Console.WriteLine(pizza);
            Console.ReadKey();
        }
    }
    class Pizza
    {
        public virtual string Title => $"{nameof(Pizza)}";
        public virtual decimal Price => 10m;
        private static Pizza Create(string type)
        {
            Pizza pizza;
            if (type.Equals(PizzaConstants.CheesePizza))
                pizza = new Cheese();
            else if (type.Equals(PizzaConstants.ChickenPizza))
                pizza = new Chicken();
            else
                pizza = new HotDog();
            return pizza;
        }

        public static Pizza Order(string type)
        {
            Pizza pizza = Create(type);
            Preaper();
            Cook();
            Cut();
            return pizza;
        }
        public static void Preaper()
        {
            Console.Write("Preapering...");
            Thread.Sleep(1000);
            Console.WriteLine("Completed");
        }
        public static void Cook()
        {
            Console.Write("Cooking...");
            Thread.Sleep(1000);
            Console.WriteLine("Completed");
        }
        public static void Cut()
        {
            Console.Write("Cutting and Boxing...");
            Thread.Sleep(1000);
            Console.WriteLine("Completed");
        }
        public override string ToString()
        {
            return $"\n{Title}" + $"\n\tPrice: {Price.ToString("C")}";
        }
    }
    class Cheese : Pizza
    {
        public override string Title => $"{base.Title} {nameof(Cheese)}";
        public override decimal Price => base.Price + 2m;
    }
    class Chicken : Pizza
    {
        public override string Title => $"{base.Title} {nameof(Chicken)}";
        public override decimal Price => base.Price + 5m;
    }
    class HotDog : Pizza
    {
        public override string Title => $"{base.Title} {nameof(HotDog)}";
        public override decimal Price => base.Price + 3m;
    }
}