using  System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace praktika2
{

    struct People
    {
        public int Id;
        public string Name;
        public string Meaning;
        public string Gender;
        public string Origin;
        public int PeopleCount;

    }



    class Program
    {

        //Сортировка пузырьком
        static void BubbleSort(List<People> people)
        {
            int prerestanovka = 0, sravnenie = 0;
            People temp;
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {
                    sravnenie++;
                    if (people[i].city_id > people[j].city_id)
                    {
                        prerestanovka++;
                        temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }
            }

            Console.WriteLine("Количество перестановок - " + prerestanovka);
            Console.WriteLine("Количество сравнений - " + sravnenie);

        }


        //Сортировка с выборкой
        public static void Selection(List<People> people)
        {

            for (int i = 0; i < people.Count - 1; i++)
            {

                int min = i;

                for (int j = i + 1; j < people.Count; j++)
                    if (people[j].city_id < people[min].city_id) min = j;

                People dummy = people[i];
                people[i] = people[min];
                people[min] = dummy;
            }

        }



        //Считать файл
        static void ReadFile(List<People> list)
        {
            try
            {
                using (StreamReader reader = File.OpenText("D:\\elina\\struct\\foreign_names.csv"))
                {
                    string[] text = new string[6];
                    for (int i = 0; i < 8000; i++)
                    {
                        People ind = new People();
                        text = reader.ReadLine().Split(';');
                        ind.city_id = Convert.ToInt32(text[0]);
                        ind.region_id = Convert.ToInt32(text[1]);
                        ind.country_id = Convert.ToInt32(text[2]);
                        ind.name = Convert.ToString(text[3]);
                       
                        list.Add(ind);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }


        static void Main(string[] args)
        {

            List<People> people = new List<People>();

            //Измерятор времени
            Stopwatch watch = new Stopwatch();


            ReadFile(people);
            Console.WriteLine("Сортировка пузырьком");
            watch.Start();
            BubbleSort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            people.Clear();


            ReadFile(people);
            Console.WriteLine("\nГномья сортировка");
            watch.Start();
            gnomeSort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            people.Clear();



            ReadFile(people);
            Console.WriteLine("\nСортировка Шелла");
            watch.Start();
            shellSort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            people.Clear();



            ReadFile(people);
            Console.WriteLine("\nПирамидальная сортировка");
            watch.Start();
            Pyramid_Sort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();


            Console.ReadKey();
        }
    }
}
