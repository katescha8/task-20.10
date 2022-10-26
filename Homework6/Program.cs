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
            private int price_big = 3000;
            private int price_middle = 1500;
            private int price_little = 500;
            public Ritual_Shop(string name) : base(name) { }
            public void Coffin()
            {
                Console.Write("Выберите, из какого материала будет изготовлен гроб(сосна, лиственница, липа, дуб): ");
                string s = Console.ReadLine();
                Console.Write("Введите размеры гроба в формате a*b*c: ");
                string sizes = Console.ReadLine();
                switch (s)
                {
                    case "сосна": Console.WriteLine($"Гроб из сосны размером {sizes} будет стоить 16859"); break;
                    case "лиственница": Console.WriteLine($"Гроб из лиственницы размером {sizes} будет стоить 25759"); break;
                    case "липа": Console.WriteLine($"Гроб из липы размером {sizes} будет стоить 21895"); break;
                    case "дуб": Console.WriteLine($"Гроб из дуба размером {sizes} будет стоить 30999"); break;
                }
            }
            public void Wreath()
            {
                Console.Write($"Выберите венок и введите его размер(большой с белыми лилиями-{price_big}, средний с красными розами-{price_middle}, маленький с красными гвоздиками-{price_little}): ");
                string s = Console.ReadLine();
                Console.Write("Введите количество ");
                byte c = Convert.ToByte(Console.ReadLine());
                if (s.Equals("б"))
                { Console.WriteLine($"Сумма к оплате {price_big * c}"); }
                else if (s.Equals("с"))
                { Console.WriteLine($"Сумма к оплате {price_middle * c}"); }
                else
                { Console.WriteLine($"Сумма к оплате {price_little * c}"); }
            }
            public void Gravestone()
            {
                Console.Write("Выберите надгробие(крест, стела, плита): ");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "крест": Console.WriteLine("Надгробие из креста будет стоить 9999"); break;
                    case "стела": Console.WriteLine("Надгробие из креста будет стоить 50000"); break;
                    case "плита": Console.WriteLine("Надгробие из креста будет стоить 30000"); break;
                }
            }
        }
        class Chapel : Building
        {
            private DateTime date;
            public Chapel(string name) : base(name) { }
            public void Candle()
            {
                Console.Write("Сделайте пожертвование от 20 рублей и наш священнослужитель поставит свечку за упокой Вашего близкого ");
                try
                {
                    int sum = Convert.ToInt32(Console.ReadLine());
                    if (sum >= 20)
                    { Console.WriteLine("Спасибо за пожертвование! Благодати Вам!"); }
                }
                catch (FormatException)
                { }
            }
            public void Burial_Service()
            {
                Console.Write("На какую дату назначить отпевание? ");
                date = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Отпевание назначено на " + date.ToString("g"));
            }
            public void Prayer()
            {
                Console.Write("Всем нам становится спокойнее в эти трудные дни, когда мы молимся. Помолитесть, братья и сестры! ");
                string s = Console.ReadLine();
                if (!s.Equals(""))
                { Console.WriteLine("Ваша молитва была услышана"); }
            }
        }
        class Graves
        {
            private int pollution_level;
            public int PollutionLevel
            {
                get { return pollution_level; }
                set { pollution_level = value; }
            }

            public void Get_Information(StreamReader sr, ref List<string> people)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    people.Add(line);
                }
            }
            public void Set_Information(StreamWriter sw, List<string> people)
            {
                Console.WriteLine("Введите номер могилы в формате: Могила №_");
                people.Add(Console.ReadLine());
                Console.WriteLine("Введите имя в фомате ФИО: ");
                people.Add(Console.ReadLine());
                Console.WriteLine("Введите годы жизни в формате: гггг-гггг");
                people.Add(Console.ReadLine());
                foreach (string s in people)
                {
                    sw.WriteLine(s);
                }
                sw.Close();
            }
            public void Clear()
            {
                if (PollutionLevel > 2)
                {
                    Console.Write("Хотите почистить могилу?(да/нет) ");
                    string s = Console.ReadLine();
                    if (s.Equals("да"))
                    { PollutionLevel = 0; Console.WriteLine("Могила убрана"); }
                }
                else
                { Console.WriteLine("Могила достаточно чистая"); }
            }
        }
        class Ghosts
        {
            private string cause_of_death;
            public string name;
            public string Cause_of_death
            {
                get { return cause_of_death; }
                set { cause_of_death = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public void Howl()
            { Console.WriteLine("Вы слышите пугающие завывыния..."); }
            public void Scare()
            { Console.WriteLine("Получена ачивка \"Вы напугали деда\""); }
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
                { holy_water_supply--; Console.WriteLine("Вы не попали, но привидение испугалось. Зарядов осталось: " + holy_water_supply); }
                else
                { holy_water_supply--; Console.WriteLine("Одно привидение уничтожено! Зарядов осталось: " + holy_water_supply); }
            }
            public void Sleep()
            { Console.WriteLine("Охраннник спит..."); }
            public void Punish_Children()
            {
                Console.Write("Вы слышите назойливый детский смех и видите, как дети воруют конфеты с надгробий. Как вы с ними поступите?(Простой разговор - введите \"р\", выстрелить в них солью из ружья - введите \"с\"): ");
                string s = Console.ReadLine();
                if (s.Equals("с"))
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
            Graves graves1 = new Graves();
            Graves graves2 = new Graves();
            Ghosts ghost1 = new Ghosts();
            Guardian guardian = new Guardian();
            //guardian.Name = "Петрович";
            //guardian.Sleep();
            //guardian.Punish_Children();
            //guardian.Wander();
            //guardian.Kill_Ghost();
            //ritual_shop.Coffin();
            //ritual_shop.Wreath();
            //ritual_shop.Gravestone();
            //chapel.Candle();
            //chapel.Burial_Service();
            //chapel.Prayer();
            //StreamReader sr1 = new StreamReader("C:\\Users\\admin\\Desktop\\Dead1.txt");
            //StreamWriter sw2 = new StreamWriter("C:\\Users\\admin\\Desktop\\Dead2.txt");
            //List<string> people1 = new List<string>();
            //List<string> people2 = new List<string>();
            //graves1.Get_Information(sr1, ref people1);
            //graves2.Set_Information(sw2, people2);
            //Random r = new Random();
            //graves1.PollutionLevel = r.Next(0, 6);
            //graves1.Clear();
            //ghost1.name = "Володимир";
            //ghost1.Cause_of_death = "посадили на кол";
            //ghost1.Howl();
            //ghost1.Scare();
        }
    }
}

