using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static long totalGold = 0;
        static long totalGem = 0;
        static long totalMoney = 0;

        static void Main(string[] args)
        {
            long maxCapacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var bag = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < safe.Length; i += 2)
            {
                string itemName = safe[i];
                long quantity = long.Parse(safe[i + 1]);
                string itemType = GetItemType(itemName);

                if (itemType == "" || maxCapacity < (totalGold + totalGem + totalMoney + quantity))
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (totalGem + quantity > totalGold)
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (totalMoney + quantity > totalGem)
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, long>();
                }

                if (!bag[itemType].ContainsKey(itemName))
                {
                    bag[itemType][itemName] = 0;
                }

                bag[itemType][itemName] += quantity;

                IncreaseAmount(quantity, itemType);
            }

            Print(bag);
        }

        private static void IncreaseAmount(long quantity, string itemType)
        {
            if (itemType == "Gold")
            {
                totalGold += quantity;
            }
            else if (itemType == "Gem")
            {
                totalGem += quantity;
            }
            else if (itemType == "Cash")
            {
                totalMoney += quantity;
            }
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var pair in bag)
            {
                Console.WriteLine($"<{pair.Key}> ${pair.Value.Values.Sum()}");
                foreach (var item in pair.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static string GetItemType(string name)
        {
            string itemType = string.Empty;

            if (name.Length == 3)
            {
                itemType = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                itemType = "Gold";
            }

            return itemType;
        }
    }
}