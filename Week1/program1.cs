using System;

class Program
{
    static void Main()
    {
        Game();
    }

    static void Game()
    {
        Random random = new Random();

        int answer = random.Next(1, 101);
        int count = 0;

        Console.WriteLine("숫자 맞히기 게임");
        Console.WriteLine("1~100 사이의 숫자를 맞혀보세요.");

        while (true)
        {
            Console.Write("숫자 입력: ");
            int number = int.Parse(Console.ReadLine());

            count++;

            if (number < answer)
            {
                Console.WriteLine("UP");
            }
            else if (number > answer)
            {
                Console.WriteLine("DOWN");
            }
            else
            {
                Console.WriteLine("정답!");
                Console.WriteLine("시도 횟수: " + count);
                break;
            }
        }
    }
}
