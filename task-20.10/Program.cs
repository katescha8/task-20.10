using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace ClassWork6
{
    class Program
    {
        enum BankAccountType
        {
            Current,
            Saving
        }
        class BankAccount
        {
            private int account_number;
            private double balance;
            private BankAccountType type;
            public int Number
            {
                get => account_number;
                set => account_number = value;
            }
            public double Balance
            {
                get => balance;
                set => balance = value;
            }
            public BankAccountType Type
            {
                get => type;
                set => type = value;
            }
            static Random r = new Random();
            private static int generic_number = r.Next(999, 10000);
            public int Generic
            {
                get => generic_number;
                set => generic_number++;
            }
            public double PutOnAccount(double balance )
            {
                Console.Write("Введите сумму для пополнения ");
                double temp = Convert.ToDouble(Console.ReadLine());
                return balance + temp;
            }
            public double WithdrawFromAccount(double balance)
            {
                Console.Write("Введите сумму для снятия ");
                double temp = Convert.ToDouble(Console.ReadLine());
                if (balance >= temp)
                { return balance - temp; }
                else
                { Console.WriteLine("На вашем счёте недостаточно средств!");  return balance; }
            }
        }
        class Building
        {
            private int number;
            public int Number
            {
                get => number;
                set => number = value;
            }
            private ushort height;
            public ushort Height
            {
                get => height;
                set => height = value;
            }
            private byte number_of_floors;
            public byte Floors
            {
                get => number_of_floors;
                set => number_of_floors = value;
            }
            private ushort number_of_flats;
            public ushort Flats
            {
                get => number_of_flats;
                set => number_of_flats = value;
            }
            private byte number_of_entrances;
            public byte Entrance
            {
                get => number_of_entrances;
                set => number_of_entrances = value;
            }
            static Random r = new Random();
            public static int generic_number = r.Next(1000);
            public Building(int n, ushort h, byte floors, ushort flats, byte entrances)
            { 
                this.number = n;
                this.height = h;
                this.number_of_floors = floors;
                this.number_of_flats = flats;
                this.number_of_entrances = entrances;
            }
            public int FloorHeight(ushort h, byte f)
            {
                int temp = h / f;
                return temp;
            }
            public int FlatsInEntrance(ushort f, byte e)
            {
                int temp = f / e;
                return temp;    
            }
            public int FlatsOnFloor(ushort flats, byte e, byte floors)
            {
                int temp = (flats / e) / (floors-1) ;
                return temp;
            }
        }
        public static void Task_7_1()
        {
            BankAccount acc1 = new BankAccount();
            acc1.Number = 1000;
            acc1.Balance = 2300;
            acc1.Type = BankAccountType.Current;
            Console.WriteLine("Bank acccount №" + acc1.Number + " balance-" + acc1.Balance + "$ type-" + acc1.Type);
        }
        public static void Task_7_2()
        {
            BankAccount acc2 = new BankAccount();
            acc2.Balance = 3000;
            acc2.Type = BankAccountType.Saving;
            Console.WriteLine("Bank acccount №" + acc2.Generic + " balance-" + acc2.Balance + "$ type-" + acc2.Type);
        }
        public static void Task_7_3()
        {
            BankAccount acc3 = new BankAccount();
            acc3.Balance = 4000;
            acc3.Type = BankAccountType.Current;
            acc3.Balance = acc3.PutOnAccount(acc3.Balance);
            Console.WriteLine("Bank acccount №" + acc3.Generic + " balance-" + acc3.Balance + "$ type-" + acc3.Type);
            acc3.Balance = acc3.WithdrawFromAccount(acc3.Balance);
            Console.WriteLine("Bank acccount №" + acc3.Generic + " balance-" + acc3.Balance + "$ type-" + acc3.Type);
        }
        public static void HomeTask_7_1()
        {
            Building building = new Building(1,50,16,300,5);
            Console.WriteLine($"Высота одного этажа {building.FloorHeight(building.Height, building.Floors)} метра, количество квартир в подъезде {building.FlatsInEntrance(building.Flats, building.Entrance)}, количество квартир на этаже {building.FlatsOnFloor(building.Flats, building.Entrance, building.Floors)}");
        }
        static void Main(string[] args)
        {
            HomeTask_7_1();
        }
    }
}