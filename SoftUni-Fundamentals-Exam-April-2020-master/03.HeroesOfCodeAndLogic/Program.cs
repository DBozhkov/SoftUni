using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogic
{
    class Program
    {
        static void Main()
        {
            int heroCount = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> hero = new Dictionary<string, Hero>();

            for (int i = 0; i < heroCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string heroName = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);

                Hero specs = new Hero() { HP = hp, MP = mp };

                hero.Add(heroName, specs);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command.Contains("CastSpell"))
                {
                    var arr = command.Split(" - ");

                    string name = arr[1];
                    int mpNeeded = int.Parse(arr[2]);
                    string spellName = arr[3];

                    hero[name].MP -= mpNeeded;

                    if (hero[name].MP >= 0)
                    {
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {hero[name].MP} MP!");
                    }

                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                        hero[name].MP += mpNeeded;
                    }
                }

                if (command.Contains("TakeDamage"))
                {
                    var arr = command.Split(" - ");

                    string name = arr[1];
                    int damage = int.Parse(arr[2]);
                    string attacker = arr[3];

                    hero[name].HP -= damage;

                    if (hero[name].HP > 0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {hero[name].HP} HP left!");
                    }

                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        hero.Remove(name);
                    }
                }

                if (command.Contains("Recharge"))
                {
                    var arr = command.Split(" - ");

                    string name = arr[1];
                    int recharge = int.Parse(arr[2]);

                    if (hero[name].MP + recharge > 200)
                    {
                        recharge = 200 - hero[name].MP;
                    }

                    hero[name].MP += recharge;


                    Console.WriteLine($"{name} recharged for {recharge} MP!");
                }

                if (command.Contains("Heal"))
                {
                    var arr = command.Split(" - ");

                    string name = arr[1];
                    int healAmount = int.Parse(arr[2]);

                    if (hero[name].HP + healAmount > 100)
                    {
                        healAmount = 100 - hero[name].HP;
                    }

                    hero[name].HP += healAmount;


                    Console.WriteLine($"{name} healed for {healAmount} HP!");
                }
            }

            var sortedHeroes = hero.OrderByDescending(x => x.Value.HP).ThenBy(x => x.Key).ToDictionary(h => h.Key, v => v.Value);

            foreach (var pair in sortedHeroes)
            {
                Console.WriteLine(pair.Key);
                Console.WriteLine($"  HP: {pair.Value.HP}");
                Console.WriteLine($"  MP: {pair.Value.MP}");
            }
        }
    }

    class Hero
    {
        public int HP { get; set; }
        public int MP { get; set; }
    }
}
