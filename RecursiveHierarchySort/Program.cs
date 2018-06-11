using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveHierarchySort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Result> resultList = new List<Result>();
            Person sourcePerson = SetupHierarchy();

            resultList = RecursivePrint(sourcePerson, 0);

            resultList.OrderBy(q => q.Level).ToList().ForEach(p => Console.Write(p.Name));

            Console.ReadKey();

        }

        static List<Result> RecursivePrint(Person p, int level)
        {
            int localLevel = level + 1;
            List<Result> localResults = new List<Result>();

            if (p.Children != null)
            {
                foreach (var child in p.Children)
                {
                    localResults.AddRange(RecursivePrint(child, localLevel));
                }
            }

            localResults.Add(
                            new Result
                            {
                                Name = p.Name,
                                Level = level
                            });
            return localResults;
        }

        static Person SetupHierarchy()
        {
            Person p = new Person
            {
                Name = "A",
                Children = new List<Person>
            {
                new Person
                {
                    Name = "B",
                    Children = new List<Person>
                    {
                        new Person
                        {
                            Name = "E",
                            Children = new List<Person>
                            {
                                new Person
                                {
                                    Name= "I"
                                }

                            }
                        }
                    }
                },
                new Person
                {
                    Name = "C",
                    Children = new List<Person>
                    {
                        new Person
                        {
                            Name = "F",
                            Children = new List<Person>
                            {
                                new Person
                                {
                                    Name= "J"
                                }

                            }
                        },
                        new Person
                        {
                            Name = "G"
                        }

                    }
                },
                new Person
                {
                    Name = "D",
                    Children = new List<Person>
                    {
                        new Person
                        {
                            Name = "H",
                            Children = new List<Person>
                            {
                                new Person
                                {
                                    Name= "K"
                                }

                            }
                        }
                    }
                }
            }
            };
            return p;
        }
    }
}
