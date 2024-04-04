using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Перше завдання - ввести дані користувачем та вивести номери всіх елементів, що не потрапляють в заданий інтервал.");
            Console.WriteLine("2. Друге завдання - ввести розмірність масиву та елементи з клавіатури, знайти кількість пар сусідніх елементів з різницею, яку вводить користувач.");
            Console.WriteLine("3. Третє завдання - підрахувати середнє арифметичне парних елементів, розташованих нижче головної діагоналі.");
            Console.WriteLine("4. Четверте завдання - знайти мінімальний елемент в кожному стовпці та записати дані в новий масив.");
            Console.WriteLine("5. Вийти з програми.");

            int вибір;
            while (!int.TryParse(Console.ReadLine(), out вибір) || (вибір < 1 || вибір > 5))
            {
                Console.WriteLine("Неправильне введення. Будь ласка, введіть номер від 1 до 5.");
            }

            switch (вибір)
            {
                case 1:
                    Перше_завдання();
                    break;
                case 2:
                    Друге_завдання();
                    break;
                case 3:
                    Третє_завдання();
                    break;
                case 4:
                    Четверте_завдання();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void Перше_завдання()
    {
        Console.WriteLine("Введіть початок інтервалу:");
        int початокІнтервалу = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введіть кінець інтервалу:");
        int кінецьІнтервалу = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введіть розмірність масиву:");
        int розмір = Convert.ToInt32(Console.ReadLine());

        int[] масив = new int[розмір];

        Console.WriteLine("Введіть елементи масиву:");

        for (int i = 0; i < розмір; i++)
        {
            масив[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Елементи, що не потрапляють в заданий інтервал:");

        foreach (var елемент in масив)
        {
            if (елемент < початокІнтервалу || елемент > кінецьІнтервалу)
            {
                Console.WriteLine(елемент);
            }
        }
    }

    static void Друге_завдання()
    {
        Console.WriteLine("Введіть розмірність масиву:");
        int розмір = Convert.ToInt32(Console.ReadLine());

        int[] масив = new int[розмір];

        Console.WriteLine("Введіть елементи масиву:");

        for (int i = 0; i < розмір; i++)
        {
            масив[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Введіть задане число для різниці між сусідніми елементами:");
        int заданеЧисло = Convert.ToInt32(Console.ReadLine());

        int кількістьПар = 0;

        for (int i = 0; i < розмір - 1; i++)
        {
            if (Math.Abs(масив[i] - масив[i + 1]) == заданеЧисло)
            {
                кількістьПар++;
            }
        }

        Console.WriteLine("Кількість пар сусідніх елементів, різниця між якими дорівнює {0}, становить: {1}", заданеЧисло, кількістьПар);
    }

    static void Третє_завдання()
    {
        Console.WriteLine("Введіть розмірність масиву:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] масив = new int[n, n];

        Console.WriteLine("Введіть елементи масиву:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                масив[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int кількістьПарнихЕлементів = 0;
        int сума = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i > j && масив[i, j] % 2 == 0)
                {
                    кількістьПарнихЕлементів++;
                    сума += масив[i, j];
                }
            }
        }

        if (кількістьПарнихЕлементів > 0)
        {
            double середнєАрифметичне = (double)сума / кількістьПарнихЕлементів;
            Console.WriteLine("Середнє арифметичне парних елементів, розташованих нижче головної діагоналі, становить: {0}", середнєАрифметичне);
        }
        else
        {
            Console.WriteLine("У масиві немає парних елементів, розташованих нижче головної діагоналі.");
        }
    }

    static void Четверте_завдання()
    {
        Console.WriteLine("Введіть кількість рядків масиву:");
        int рядки = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введіть кількість стовпців масиву:");
        int стовпці = Convert.ToInt32(Console.ReadLine());

        int[,] масив = new int[рядки, стовпці];
        int[] мінімальніЕлементи = new int[стовпці];

        Console.WriteLine("Введіть елементи масиву:");

        // Заповнення масиву та знаходження мінімальних елементів в кожному стовпці
        for (int i = 0; i < рядки; i++)
        {
            for (int j = 0; j < стовпці; j++)
            {
                масив[i, j] = Convert.ToInt32(Console.ReadLine());

                if (i == 0 || масив[i, j] < мінімальніЕлементи[j])
                {
                    мінімальніЕлементи[j] = масив[i, j];
                }
            }
        }

        Console.WriteLine("Мінімальні елементи в кожному стовпці:");

        // Виведення мінімальних елементів в кожному стовпці
        for (int j = 0; j < стовпці; j++)
        {
            Console.WriteLine($"Стовпець {j + 1}: {мінімальніЕлементи[j]}");
        }
    }
}