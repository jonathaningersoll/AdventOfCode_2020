using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_07
{
    public class Bag
    {
        public string Name { get; set; }
        public List<string> Containers { get; set; }
    }

    class HandyHaversacksvFour
    {

        public List<string> RuleList { get; set; } = new List<string>();
        public List<Bag> BagList { get; set; } = new List<Bag>();
        public Queue<int> EvalList { get; set; } = new Queue<int>();
        public List<string> NodeList { get; set; } = new List<string>();
        public Queue<string> ChildList { get; set; } = new Queue<string>();
        public int Counter { get; set; }
        private char[] trimCharsHhTwo = { ' ', '.'};



        public void Run()
        {
            Ui();
        }

        private void Ui()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("Which process do you wish to run?\n" +
                    "1. Handy Haversacks pt. 1\n" +
                    "2. Handy Haversacks pt. 2\n" +
                    "3. Exit");
                string ans = Console.ReadLine();

                switch (ans)
                {
                    case "1":
                        {
                            run = HandyHaversacksPartOne();
                            break;
                        }
                    case "2":
                        {
                            run = HandyHaversacksPartTwo();
                            break;
                        }
                    case "3":
                        {
                            run = false;
                            break;
                        }
                }
            }
        }

        private bool HandyHaversacksPartOne()
        {
            bool hh = true;
            while (hh)
            {
                RuleList = CreateRuleList();
                CreateBagListFromRules();

                Console.WriteLine("Which bag do you want to check?");
                ChildList.Enqueue(Console.ReadLine());

                do
                {
                    ProcessList();
                } while (ChildList.Count > 0);

                UnionChildren();
                Console.WriteLine("-----------------------\n" +
                    " End of program.\n" +
                    "Run again [y/n]?");

                string ans = Console.ReadLine();
                switch (ans.ToLower())
                {
                    case "y":
                        {
                            hh = true;
                            break;
                        }
                    case "n":
                        {
                            hh = false;
                            Console.WriteLine("Leaving HandyHaversacks pt. One. Press any key to continue...");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Leaving HandyHaversacks pt. One. Press any key to continue...");
                            Console.ReadKey();
                            hh = false;
                            break;
                        }
                }

            }

            return false;
        }

        private bool HandyHaversacksPartTwo()
        {
            ClearProperties();
            bool hhTwo = true;

            while (hhTwo)
            {
                RuleList = CreateRuleList();
                CreateBagListFromRulesTwo();

                Console.WriteLine("Which bag would you like to begin evaluating?");
                string bagToEval = Console.ReadLine();

                EvalList.Enqueue(GetBagIndex(bagToEval));

                do
                {
                    ProcessEvalList();
                } while (EvalList.Count() > 0);

                Console.WriteLine(Counter - 1);
                hhTwo = false;
            }

            

            return false;
        }

        private void ProcessList()
        {
            // Dequeue the first child (shiny gold) and find all its parents
            var child = ChildList.Dequeue();

            // Add the child to the NodeList
            NodeList.Add(child);

            var parents = GetParentBagsByChild(child).Select(x => x.Name).ToList();

            // Add that list of parents to the queue
            parents.ForEach(x => ChildList.Enqueue(x));
        }
        private List<Bag> GetParentBagsByChild(string child)
        {
            return BagList.Where(x => x.Containers.Contains(child)).ToList();
        }
        private void UnionChildren()
        {
            List<string> nodeUnion = NodeList.Union(NodeList).ToList();
            nodeUnion.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-----------------");
            Console.WriteLine(nodeUnion.Count() - 1);
        }


        private char[] trimChars = { ' ', '.', ',' };
        private List<string> CreateRuleList()
        {
            return File.ReadAllLines(@"./input.txt").Select(n => n).ToList();
        }
        private void CreateBagListFromRules()
        {
            foreach (var rule in RuleList)
            {
                BagList.Add(BagMaker(rule));
            }
        }
        private Bag BagMaker(string rule)
        {
            var ruleTitle = rule.Split("bags contain");

            return new Bag()
            {
                Name = ruleTitle[0].Trim(trimChars).ToString(),
                Containers = FormatBags(ruleTitle[1].Trim(trimChars).Split(" ").ToList())
            };
        }
        private List<string> FormatBags(List<string> bagList)
        {
            // remove any references to "bag"
            var newList = bagList.Where(l => !l.Contains("bag") && l.Count() > 1).ToList();

            for (int i = 0; i < newList.Count; i += 1)
            {
                newList[i] = newList[i] + " " + newList[i + 1];
                newList.RemoveAt(i + 1);
            }

            return newList;
        }

        private void ClearProperties()
        {
            RuleList.Clear();
            BagList.Clear();
            NodeList.Clear();
            ChildList.Clear();
        }




        private void CreateBagListFromRulesTwo()
        {
            foreach (var rule in RuleList)
            {
                BagList.Add(BagMakerTwo(rule));
            }
        }
        private Bag BagMakerTwo(string rule)
        {
                // Format the title
            var ruleTitle = rule.Split("s contain ");

                // Trim the ' ', '.' off the ends of the list of containers
            string trimmedListOfContainers = ruleTitle[1].Trim(' ', '.');
            
                // Split the lists on the commas
            var newRuleList = trimmedListOfContainers.Split(",").ToList();
                // set up a new list to contain the bags
            List<string> formattedRuleList = newRuleList.Select(x => FormatBagsList(x)).ToList();

                // Build the bag and return it.
            return new Bag()
            {
                Name = ruleTitle[0].Trim(trimChars).ToString(),
                Containers = formattedRuleList
            };
        }
        // Trims '.',' ' from ends of colors, then removes the 's' from the end of the bag.
        private string FormatBagsList(string bag)
        {
            bag = bag.Trim(trimCharsHhTwo);
            int l = bag.Length - 1;
            if (bag[l] == 's')
            {
                bag = bag.Remove(l);
            }

            return bag;
        }

        // Add how many boxes?
        //foreach(string item in newRuleList)
        //{
        //    string thing = item.Trim(trimCharsHhTwo);
        //    int amount = int.Parse(thing[0].ToString());

        //    for(int i = 1; i<= amount; i++)
        //    {
        //        formattedRuleList.Add(item.Trim(trimCharsHhTwo));
        //    }
        //}




        private int GetBagIndex(string bag)
        {
            return BagList.IndexOf(BagList.Where(x => x.Name == bag).FirstOrDefault());
        }
        private void ProcessEvalList()
        {
            // Get the index from the list
            if(EvalList.Count > 0)
            {
                Counter++;
                int index = EvalList.Dequeue();

                // Get the bag
                Bag bag = BagList[index];

                // enqueue the bag's contents' indices to the EvalList as many times as stated in the rule
                foreach(var item in bag.Containers)
                {
                    if (item != "no other bag")
                    {
                        int amt = Int32.Parse(item[0].ToString());
                        string word = item.Trim('1', '2', '3', '4', '5', '6',' ');

                        for(int i = 0; i< amt; i++)
                        {
                            Bag thing = BagList.Where(x => x.Name == word).FirstOrDefault();
                            EvalList.Enqueue(BagList.IndexOf(BagList.Where(x => x.Name == word).FirstOrDefault()));
                        }
                    }
                }
            }
        }
    }
}
