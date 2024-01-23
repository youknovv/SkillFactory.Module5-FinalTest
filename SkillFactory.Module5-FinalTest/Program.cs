using System;

internal class Program
{
    private static void Main()
    {
        byte petNumb = 0; byte colorNumb = 0;
        ReturnCort(ref petNumb, ref colorNumb);
        ShowData(User);

        Console.ReadKey();
    }
    static (string Name, string Famaly, byte Age, bool isPets, string[] petArr, string[] colorArr) User;
    static void ReturnCort(ref byte petNumb, ref byte colorNumb)
    {
        Console.WriteLine("Введите имя пользователя");
        User.Name = Console.ReadLine();

        Console.WriteLine("Введите фамилию пользователя");
        User.Famaly = Console.ReadLine();

        User.Age = CheckInputByte("Введите возраст пользователя", 100);
        Console.WriteLine("Есть ли у вас питомец ? (Ответьте Да/Нет)");
        var result = Console.ReadLine();
        while (result != "Да" && result != "Нет")
        {
            Console.WriteLine("Некорректный ответ, пожалуйста, ответьте Да или Нет");
            result = Console.ReadLine();
        }
        if (result == "Да")
        {
            User.isPets = true;
            petNumb = CheckInputByte("Укажите количество питомцев", 10);
            while (petNumb == 0)
            {
                Console.WriteLine("Количество питомцев не может быть равно 0");
                petNumb = CheckInputByte("Укажите количество питомцев", 10);
            }
            User.petArr = NumPetsName(ref petNumb);
        }
        else
        {
            User.isPets = false;
        }
        colorNumb = CheckInputByte("Укажите количество ваших любимых цветов", 10);
        User.colorArr = NumColor(ref colorNumb);
    }
    static string[] NumPetsName(ref byte petNumb)
    {
        string[] petName = new string[petNumb];
        Console.WriteLine("Назовите кличку(ки) своего(их) питомцев");
        for (int i = 0; i < petNumb; i++)
        {
            petName[i] = Console.ReadLine();
        }
        return petName;
    }
    static string[] NumColor(ref byte colorNumb)
    {
        string[] color = new string[colorNumb];
        Console.WriteLine("Назовите ваши любимые цвета");
        for (int j = 0; j < colorNumb; j++)
        {
            color[j] = Console.ReadLine();
        }
        return color;
    }
    static byte CheckInputByte(string message, byte maxAllowedValue)
    {
        byte result; bool isValidInput;
        do
        {
            Console.WriteLine(message);
            isValidInput = byte.TryParse(Console.ReadLine(), out result) && result <= maxAllowedValue;
            if (!isValidInput)
            {
                Console.WriteLine($"Некорректное значение. Введите число от 0 до {maxAllowedValue}.");
            }
        } while (!isValidInput);
        return result;
    }
    static void ShowData((string Name, string Famaly, byte Age, bool isPets, string[] petArr, string[] colorArr) anketa)
    {
        Console.WriteLine($"Имя: {anketa.Name}");
        Console.WriteLine($"Фамилия: {anketa.Famaly}");
        Console.WriteLine($"Возраст: {anketa.Age}"); if (anketa.isPets)
        {
            Console.WriteLine($"Количество питомцев: {anketa.petArr.Length}");
            Console.WriteLine("Клички питомцев:"); foreach (string pet in anketa.petArr)
            {
                Console.WriteLine(pet);
            }
        }
        else
        {
            Console.WriteLine("У пользователя нет питомцев");
        }
        Console.WriteLine($"Количество любимых цветов: {anketa.colorArr.Length}");
        Console.WriteLine("Любимые цвета:");
        foreach (string col in anketa.colorArr)
        {
            Console.WriteLine(col);
        }
    }
}