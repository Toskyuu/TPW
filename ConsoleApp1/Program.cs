
using System.Runtime.CompilerServices;
namespace Programisko
{
    public class Program
    {
        private int liczba1;
        private int liczba2;

        public Program(int liczba1, int liczba2)
        {
            this.liczba1 = liczba1;
            this.liczba2 = liczba2;
        }
        public Program() { }
        public void pobierzLiczbe2()
        {
            Console.WriteLine("Podaj teraz druga liczbe:");
            liczba2 = Int32.Parse(Console.ReadLine());
        }
        public void pobierzLiczbe1()
        {
            Console.WriteLine("Podaj teraz pierwsza liczbe:");
            liczba1 = Int32.Parse(Console.ReadLine());
        }

        public void dodaj()
        {
            liczba1 += liczba2;
        }

        public void odejmij()
        {
            liczba1 -= liczba2;
        }

        public void pomnoz()
        {
            liczba1 *= liczba2;
        }

        public void podziel() {
            liczba1 /= liczba2;

        }

        public int zwrocWynik()
        {
            return liczba1;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.pobierzLiczbe1();
            program.pobierzLiczbe2();   
            program.odejmij();
            Console.WriteLine(program.zwrocWynik());
        }

    }

}