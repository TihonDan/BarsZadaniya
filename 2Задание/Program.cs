using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static List<Entity> person = new List<Entity>()
        {
           new Entity (1, 0, "Root entity"),
           new Entity (2, 1, "Child of 1 entity"),
           new Entity (3 , 1,"Child of 1 entity"),
           new Entity (4, 2, "Child of 2 entity"),
           new Entity (5, 4, "Child of 4 entity")
        };
        static void Main(string[] args)
        {
            foreach (var temp in Method1())
            {
                var pers = temp;
                foreach (var dict in pers)
                {
                    Console.WriteLine($"{dict.Key} " + "\n" + $"{dict.Value} ");
                }
            }
        }

        public class Entity
        {
            public int Id { get; set; }
            public int ParentId { get; set; }
            public string Name { get; set; }

            public Entity(int id, int pID, string name)
            {
                Name = name;
                ParentId = pID;
                Id = id;
            }
        }

        static IEnumerable<Dictionary<int, List<Entity>>> Method1()
        {
            var dict = new Dictionary<int, List<Entity>>();
            for (int i = 0; i < person.Count; i++)
            {
                List<Entity> temp = person.Where(a => a.ParentId == i).ToList();
                if (temp.Count == 0)
                {
                    continue;
                }
                dict.Add(i, temp);
            }
            yield return dict;
        }

    }

}
