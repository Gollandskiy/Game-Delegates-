using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game_Delegates_
{
    public delegate void Del();
   public class Game
    {
        public void NGame()
        {
            Console.WriteLine("Создана новая игра!\n");
        }
        public void LGame()
        {
            Console.WriteLine("Загружена игра!\n");
        }
        public void Rules()
        {
            Console.WriteLine("Первое правило Бойцовского клуба: не упоминать о Бойцовском клубе.\n" +
                "Второе правило Бойцовского клуба: не упоминать нигде о Бойцовском клубе.\n" +
                "Третье правило Бойцовского клуба: боец крикнул «стоп», выдохся, отключился — бой окончен.\n" +
                "Четвертое: в бою участвуют лишь двое.\n");
        }
        public void Avtor()
        {
            Console.WriteLine("https://github.com/Gollandskiy\n");
        }
        public void Exit()
        {
            Console.WriteLine("Вы вышли!\n");
        }
        public void Menu()
        {
            Console.WriteLine("1.Новая игра\n2.Загрузить игру\n3.Правила\n4.Автор\n5.Выход\n");
        }
    }
    public delegate void MyDel();

    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            MyDel del = new MyDel(game.NGame);
            del += new MyDel(game.LGame);
            del += new MyDel(game.Rules);
            del += new MyDel(game.Avtor);
            del += new MyDel(game.Exit);
            game.Menu();
            Console.WriteLine("Введите число: ");
            int user = int.Parse(Console.ReadLine());
            Delegate[] invocationList = del.GetInvocationList();
            if (user > 0 && user < invocationList.Length+1)
                ((MyDel)invocationList[user - 1])();
            else
                throw new Exception("ВЫШЛИ ИЗ ДИАПАЗОНА!!!\n");



        }
    }
}
