using System.Collections.Generic;

namespace Strategy
{
    public interface IStrategy
    {
        object AlgorithmActions();
        string Shot();
        string Jump();
        string Dodge();
        string Run();
    }

    class DragonBattleStrategy : IStrategy
    {
        List<string> steps = new List<string>();

        public object AlgorithmActions()
        {
            steps.Add(Shot());
            steps.Add(Jump());
            steps.Add(Shot());
            steps.Add(Dodge());
            steps.Add(Shot());
            steps.Add(Run());
            return steps;
        }

        public string Dodge()
        {
            return "уворачиваться от дракона";
        }

        public string Jump()
        {
            return "прыгать в дракона";
        }

        public string Run()
        {
            return "бежать от дракона";
        }

        public string Shot()
        {
            return "стрелять";
        }
    }

    class GiantBattleStrategy : IStrategy
    {
        List<string> steps = new List<string>();

        public object AlgorithmActions()
        {
            steps.Add(Shot());
            steps.Add(Jump());
            steps.Add(Shot());
            steps.Add(Dodge());
            steps.Add(Shot());
            steps.Add(Run());
            return steps;
        }

        public string Dodge()
        {
            return "уворачиваться от гиганта";
        }

        public string Jump()
        {
            return "прыгать в гиганта";
        }

        public string Run()
        {
            return "бежать от гиганта";
        }

        public string Shot()
        {
            return "стрелять в гиганта";
        }
    }

    class TurretBattleStrategy : IStrategy
    {
        List<string> steps = new List<string>();

        public object AlgorithmActions()
        {
            steps.Add(Shot());
            steps.Add(Jump());
            steps.Add(Shot());
            steps.Add(Dodge());
            steps.Add(Shot());
            steps.Add(Run());
            return steps;
        }

        public string Dodge()
        {
            return "уворачиваться от  турели";
        }

        public string Jump()
        {
            return "прыгать в  турели";
        }

        public string Run()
        {
            return "бежать от  турели";
        }

        public string Shot()
        {
            return "стрелять в  турель";
        }
    }

    class Context
    {
        private IStrategy _strategy;

        public Context()
        { }

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void Logica()
        {

            foreach (var item in _strategy.AlgorithmActions() as List<string>)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("**********************************");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Нападение дракона на персонажа....\n " +
                "Применен алгоритм защиты от дракона");
            Context context = new Context(new DragonBattleStrategy());
            context.Logica();

            System.Console.WriteLine("Нападение ГИГАНТА на персонажа....\n " +
                "Применен алгоритм защиты от ГИГАНТА");
            context = new Context(new GiantBattleStrategy());
            context.Logica();

            System.Console.WriteLine("Нападение Турели на персонажа....\n " +
                "Применен алгоритм защиты от Турели");
            context = new Context(new TurretBattleStrategy());
            context.Logica();
        }
    }
}
