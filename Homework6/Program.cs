using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace Homeworkk6
{
    class Program
    {
        abstract class Building
        {
            public string Name { get; }
            public Building(string name)
            {
                Name = name;
            }   
        }
        class Ritual_Shop : Building
        {
            public Ritual_Shop (string name) : base(name) { }
            public void Coffin()
            {

            }
        }
        class Chapel : Building
        {
            public Chapel (string name) : base(name) { }

        }
        class Guardian
        {
            private string name;
            public string Name
            {
                get { return name; } 
                set { name = value; }
            }
            private byte holy_water_supply = 5;
            public void Kill_Ghost()
            {
                Console.WriteLine("На вашем пути встретилось приведение, попытайтесь убить его святой водой!");
                Random r = new Random();
                int temp = r.Next(0, 2);
                Thread.Sleep(2000);
                if (temp == 0)
                { holy_water_supply--; Console.WriteLine("Вы не попали, но привидение испугалось. Зарядов осталось: " + holy_water_supply);}
                else
                { holy_water_supply--; Console.WriteLine("Одно привидение уничтожено! Зарядов осталось: "+ holy_water_supply); }
            }
            public void Sleep()
            { Console.WriteLine("Охраннник спит..."); }
            public void Punish_Children()
            { 
                Console.Write("Вы слышите назойливый детский смех и видите, как дети воруют конфеты с надгробий. Как вы с ними поступите?(Простой разговор - введите \"р\", выстрелить в них солью из ружья - введите \"с\"): "); 
                string s= Console.ReadLine();
                if ( s.Equals("с"))
                { Console.WriteLine("Получена ачивка \"Возмездие\""); }
                else 
                { Console.WriteLine("Получена ачивка \"Добряк\""); }
            }
            public void Wander()
            { Console.WriteLine("Охранник бродит по кладбищу..."); }
        }
        static void Main(string[] args)
        {
            Ritual_Shop ritual_shop = new Ritual_Shop("Магазин с гробами и венками \"В последний путь\" ");
            Chapel chapel = new Chapel("Часовня великомученицы Екатерины Александрийской");
            Guardian guardian = new Guardian();
            guardian.Name = "Петрович";
            guardian.Sleep();
            guardian.Punish_Children();
            guardian.Wander();
            guardian.Kill_Ghost();

            //Console.WriteLine(chapel.Name);
        }
    }
}