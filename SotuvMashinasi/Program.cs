namespace SotuvMashinasi
{
    internal class Program
    {
        private static int userCardId = -1;
        private static VendingMachine vendingMachine;

        static void Main(string[] args)
        {
            vendingMachine = new VendingMachine();
            Login();
        }


        public class Dog : Animal
        {
            
            
        }
        public class Animal
        {
            public static int MyProperty { get; set; }
            public static void name()
            {

            }
            public Animal(string name)
            {

            }
            public Animal()
            {

            }
        }


        static void Login()
        {
            Console.WriteLine("\nCarta ID orqali tizimga kirish: ");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out int cardId))
            {
                Console.Clear();
                Console.WriteLine("To'g'ri formatta kiriting...");
                Login();
                return;
            }
            userCardId = cardId;

            if (vendingMachine.GetCredit(cardId) == -1)
            {
                Console.Clear();
                Console.WriteLine("Carta Topilmadi, Qo'shilsinmi?");
                Console.Write("\nY / N >> ");
                string? yesNo = Console.ReadLine();
                switch (yesNo)
                {
                    case "Y": case "y":
                        {
                            Console.Write("\nCarta ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int newCardId))
                            {
                                Console.Clear();
                                Console.WriteLine("To'g'ri formatta kiriting...");
                                Login();
                                return;
                            }

                            Console.Write("\nCarta Balansi: ");
                            if (!int.TryParse(Console.ReadLine(), out int newCardBalace))
                            {
                                Console.Clear();
                                Console.WriteLine("To'g'ri formatta kiriting...");
                                Login();
                                return;
                            }

                            vendingMachine.Cards.Add(new Cards()
                            {
                                id = newCardId,
                                credit = newCardBalace
                            });

                            Console.Clear();

                            Console.WriteLine("Carta muvaffaqiyatli qo'shildi");
                            Login();
                            return;
                        }
                        break;
                    case "N": case "n":
                        {
                            Console.Clear();
                            Login();
                            return;
                        }
                        break;
                    default:
                        {
                            Console.Clear();
                            Login();
                            return;
                        }
                        break;
                }
            }
            else
            {
                Console.Clear();
                Menu();
                return;
            }
        }

        public static void Menu()
        {
            Console.WriteLine("\n1 => Ichimliklar ro'yxati");
            Console.WriteLine("2 => Ichimlik sotib olish");
            Console.WriteLine("3 => Ichimlik qo'shish");
            Console.WriteLine("4 => Kartaga pul qo'shish");
            Console.WriteLine("5 => Karta balansi");
            Console.WriteLine("0 => Chiqish");
            Console.Write(">> ");

            if (!int.TryParse(Console.ReadLine(), out int item))
            {
                Console.Clear();
                Console.WriteLine("To'g'ri formatta kiriting...");
                Menu();
                return;
            }

            switch (item)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("---------------------IchimliklarRo'yxati------------------------");
                        vendingMachine.RefillColumn();
                        Menu();
                        return;
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("---------------------IchimliklarRo'yxati------------------------");
                        vendingMachine.RefillColumn();
                        Console.WriteLine("\nIchimlik nomini kiriting: ");
                        Console.Write(">> ");
                        string? name = Console.ReadLine();

                        if (vendingMachine.Sell(userCardId, name) == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Ichimlik sotib olindi");
                            Menu();
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Xatolik yuz berdi");
                            Menu();
                            return;
                        }
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.Write("\nIchimlik nomi: ");
                        string? name = Console.ReadLine();

                        Console.Write("\nIchimlik narxi: ");
                        if (!int.TryParse(Console.ReadLine(), out int narx))
                        {
                            Console.Clear();
                            Console.WriteLine("To'g'ri formatta kiriting...");
                            Menu();
                            return;
                        }

                        vendingMachine.AddBeverage(new Drinks()
                        {
                            drinkName = name,
                            price = narx
                        });
                        Console.Clear();
                        Console.WriteLine("Ichimlik qo'shildi");
                        Menu();
                        return;
                    }
                    break;
                case 4:
                    {
                        Console.Clear();
                        Console.Write("Card ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int cartaId))
                        {
                            Console.Clear();
                            Console.WriteLine("To'g'ri formatta kiriting...");
                            Menu();
                            return;
                        }
                        Console.Write("Money: ");
                        if (!int.TryParse(Console.ReadLine(), out int cartaMoney))
                        {
                            Console.Clear();
                            Console.WriteLine("To'g'ri formatta kiriting...");
                            Menu();
                            return;
                        }

                        Console.Clear();
                        vendingMachine.RechargeCard(cartaId, cartaMoney);
                        Menu();
                        return;
                    }
                    break;
                case 5:
                    {
                        Console.Clear();
                        Console.WriteLine("Cart ID: ");
                        Console.Write(">> ");
                        if (!int.TryParse(Console.ReadLine(), out int cartaId))
                        {
                            Console.Clear();
                            Console.WriteLine("To'g'ri formatta kiriting...");
                            Menu();
                            return;
                        }

                        if (vendingMachine.GetCredit(cartaId) == -1)
                        {
                            Console.Clear();
                            Console.WriteLine("Carta mavjud emas");
                            Menu();
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(vendingMachine.GetCredit(cartaId));
                            Menu();
                            return;
                        }
                    }
                    break;
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("Xaridingiz uchun raxmat");
                    }
                    break;
                default:
                    Console.Clear();
                    Menu();
                    return;
            }

        }

    }
}