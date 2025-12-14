using System;
// Класс для конвертации из троичной в десятичную систему
class c3to10
{
    public string n;          // Входное число (строка, троичное)
    private int dec;          // Число в десятичной системе
    private bool korrekt = true; // Флаг корректности данных
    private string res;       // Результат в десятичной системе (строка)

    // Конструктор класса
    public c3to10(string number)
    {
        try
        {
            n = number;
            // Проверяем корректность троичного числа
            if (!CheckNumber())
            {
                korrekt = false;
                res = "Неверный формат троичного числа. Используйте только 0, 1, 2.";
                return;
            }
            // Если число корректно, конвертируем в десятичную систему
            ToDec();
        }
        catch (Exception ex)
        {
            korrekt = false;
            res = $"Ошибка при обработке числа: {ex.Message}";
        }
    }

    // Метод проверки корректности введенного троичного числа
    private bool CheckNumber()
    {
        // Проверка на пустую строку
        if (string.IsNullOrEmpty(n))
            return false;

        // Проверка, что все символы - допустимые троичные цифры (0, 1, 2)
        foreach (char c in n)
        {
            if (c != '0' && c != '1' && c != '2')
                return false;
        }

        // Если дошли сюда, строка является корректным троичным числом
        return true;
    }

    // Метод конвертации из троичной в десятичную систему
    private void ToDec()
    {
        dec = 0; // Инициализируем десятичное значение

        // Алгоритм перевода: умножаем на основание (3) и добавляем текущую цифру
        foreach (char digitChar in n)
        {
            int digit = int.Parse(digitChar.ToString()); // Преобразуем символ цифры в int
            dec = dec * 3 + digit;                       // dec = (предыдущее_dec * 3) + текущая_цифра
        }

        res = dec.ToString(); // Преобразуем итоговое десятичное число в строку
    }

    // Метод для отображения результата конвертации (десятичного числа)
    public string show()
    {
        return res;
    }

    // Метод для определения типа числа (четное/нечетное)
    // Определяет четность полученного десятичного числа
    public string type()
    {
        // Проверяем, были ли корректные данные
        if (!korrekt)
        {
            return "Невозможно определить (ошибка в исходном числе)";
        }

        // Проверка четности через остаток от деления на 2 
        if (dec % 2 == 0)
        {
            return "Чётное";
        }
        else
        {
            return "Нечётное";
        }
    }
}
class Program
{
    static void Main()
    {
        bool flag = true; // Флаг для управления циклом продолжения
        while (flag)
        {
            try
            {
                Console.WriteLine("\n--- Конвертер из троичной в десятичную систему ---");
                Console.Write("Введите число в троичной системе (используйте только 0, 1, 2): ");
                string input = Console.ReadLine();
                c3to10 conversion = new c3to10(input);
                Console.WriteLine($"Десятичное значение: {conversion.show()}");
                Console.WriteLine($"Чётность десятичного числа: {conversion.type()}");
                Console.WriteLine("\nХотите продолжить? (1- да, 2- нет)");
                string pv = Console.ReadLine();
                // Самая простая проверка: продолжить, если введено ровно "1".
                flag = (pv == "1");

                if (flag)
                {
                    Console.WriteLine("Продолжаем работу.");
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Завершение работы программы.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                flag = false; // В случае ошибки также завершаем программу
            }
        }
    }
}