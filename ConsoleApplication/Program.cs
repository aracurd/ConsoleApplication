using System.Collections.Generic;
using System.Linq;
using Bank.Classes;
using static System.Console;

namespace Bank
{
    internal class Program
    {
        static Banks banks = new Banks();
        public static void Main(string[] args)
        {
            Title = "Менеджер банка";
            WriteLine(Title);
            //Создание тестовых счетов
            AddTestAccounts(5);
            banks.ShoveAllAccounts();
            ReadKey();
            while (true)
            {
              StartMessage();
              ReadKey();
            }
        }

        private static void AddTestAccounts(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                banks.CreateAccount(1, (i+2)*100, i+1);
            }
        }

        private static void Actions(int action)
        {
            switch (action)
            {
                case 0:
                {
                    return;
                }
                case 1:
                {
                    banks.ShoveAllAccounts();
                    break;
                }
                case 2:
                {
                    WriteLine("Выберите те тип счета и старовый баланс");
                    WriteLine("Типы счетов: Депозитный - 1,\nКредитный - 2,\nВалютный - 3");
                    WriteLine("Введите данные через пробел у порядке \"Тип Стартовый баланс\"");
                    WriteLine("если счет кредитный или депозитный \"Тип Стартовый баланс Процентная ставка(без знака %)\"");
                    
                    var val = ReadLine()?.Split(' ');

                    if (val == null)
                    {
                        break;
                    }
                    
                    var values = ToInt(val);
                    
                    if (values.Length >2)
                    {
                        banks.CreateAccount(values[0], values[1], values[3]);
                        break;
                    }
                    banks.CreateAccount(values[0], values[1]);
                    break;
                }
                case 3:
                {
                    WriteLine("Выберите те номер счета и количество зачисляемых денег");
                    WriteLine("Введите данные через пробел у порядке \"Номер Зачисляемые денеги\"");
                    
                    
                    var val = ReadLine()?.Split(' ');

                    if (val == null)
                    {
                        break;
                    }
                    var values = ToInt(val);
                    
                    if (!banks.Accounts.Keys.Contains(values[0]))
                    {
                        WriteLine("Такого счета не суцествует");
                        break;
                    }

                    if (banks.Accounts[values[0]].AccountStatus != true)
                    {
                        WriteLine("Операции с закрытым счетом не возможны!");
                        break;
                    }

                    banks.CreateAccount(values[0], values[1]);
                    
                    break;
                }
                    
                case 4:
                {
                    WriteLine("Выберите те номер счета который нужно закрыть");
                    WriteLine("Введите данные через пробел у порядке \"Номер Зачисляемые денеги\"");
                    
                    
                    var val = ReadLine();

                    if (val == null)
                    {
                        break;
                    }
                    
                    var values = int.Parse(val);
                    if (!banks.Accounts.Keys.Contains(values))
                    {
                        WriteLine("Такого счета не суцествует");
                        break;
                    }

                    banks.CloseAccount(values);
                    break;
                }
                default: {WriteLine("Неверный ввод!"); break;}
            }
        }

        private static void StartMessage()
        {
            Clear();
            WriteLine("Выберите одну из следующих операций:");
            WriteLine("Вывод списка счетов - 1,\nСоздать счет - 2,\nПополнить счет - 3,\nЗакрыть счет - 4,\nВыход - 0");
            int val; int.TryParse(ReadLine(), out val);
            if (val > 4)
            {
              WriteLine("Неверный ввод!");  
              return;
            }
            Actions(val);
        }

        private static int[] ToInt(string[] val) => val.Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToArray();
    }
}