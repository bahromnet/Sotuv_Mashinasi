using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotuvMashinasi
{
    internal class VendingMachine
    {
        public List<Drinks> Drinks { get; set; }
        public List<Cards> Cards { get; set; }
        public List<string> Columns { get; set; }

        
        public VendingMachine()
        {
            Drinks = new List<Drinks>();
            Cards = new List<Cards>();
            Columns = new List<string>();
        }

        public void AddBeverage(Drinks drink)
        {
            Drinks.Add(drink);
        }

        public int GetPrice(string drinkName)
        {
            var drinkPrice = Drinks.FirstOrDefault(x => x.drinkName == drinkName);
            if (drinkPrice != null)
                return drinkPrice.price;

            return -1;
        }

        public void RechargeCard(int insertCardId, int insertMoney)
        {
            var cardId = Cards.FirstOrDefault(x => x.id == insertCardId);

            if (cardId != null)
            {
                cardId.credit += insertMoney;
                Console.WriteLine("Cartaga pul qo'shildi");
            }
            else
            {
                Console.WriteLine("Carta topilmadi, Qo'shishni hohlaysizmi?");
                Console.Write("Y / N >> ");
                string? createCard = Console.ReadLine();
                switch (createCard)
                {
                    case "Y": case "y":
                        {
                            Cards.Add(new Cards()
                            {
                                id = insertCardId,
                                credit = insertMoney
                            });
                            Console.WriteLine("Carta yaratildi");
                        }
                        break;
                    case "N": case "n":
                        {
                            Console.WriteLine("Carta yaratilmadi...");
                        }
                        break;
                    default:
                        break;
                }
                
            }
        }

        public int GetCredit(int inserCardId)
        {
            var cardId = Cards.FirstOrDefault(x => x.id == inserCardId);

            if (cardId != null)
                return cardId.credit;

            return -1;
        }

        public void RefillColumn()
        {
            var data = new Dictionary<string, int>();
            int row = 1;

            foreach (var drink in Drinks)
            {
                if (!data.ContainsKey(drink.drinkName))
                    data.Add(drink.drinkName, 1);
                else
                    data[drink.drinkName]++;
            }

            Console.WriteLine("Ustun raqami |".PadRight(20) + "Ichimlik nomi | ".PadRight(20) + "Bankalar soni");

            foreach (var item in data)
            {
                string column = $"{row++} |".PadRight(20) + $"{item.Key} |".PadRight(20) + $"{item.Value}";
                Console.WriteLine(column);
                Columns.Add(column);
            }

        }

        public int AvailableCans(string insertDrinkName)
        {
            var drinks = Drinks.Where(x => x.drinkName.ToLower() == insertDrinkName.ToLower());

            return drinks.Count();
        }

        public int Sell(int insertCardId, string insertDrinkName)
        {
            var drinkName = Drinks.FirstOrDefault(x => x.drinkName.ToLower() == insertDrinkName.ToLower());

            if (drinkName is null)
                return -1;

            var cardId = Cards.FirstOrDefault(x => x.id == insertCardId);

            if (cardId is null) 
                return -1;

            if (drinkName.price > cardId.credit)
                return -1;

            Drinks.Remove(drinkName);
            cardId.credit -= drinkName.price;

            return 1;
        }

    }
}
