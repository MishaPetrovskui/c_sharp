using System.Drawing;
using System.Text;

Console.OutputEncoding = UTF8Encoding.UTF8;
Console.InputEncoding = UTF8Encoding.UTF8;

void printArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]}, ");
    }
    Console.WriteLine("\b\b.");
}

void fillArray(int[] array, int min, int max)
{
    Random rand = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = rand.Next(min, max+1);
    }
}

void parni(int[] array)
{
    int j = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] % 2 == 0)
            j++;
    }
    Console.WriteLine(j);
}

void neparni(int[] array)
{
    int j = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] % 2 != 0)
            j++;
    }
    Console.WriteLine(j);
}

void unikalni(int[] array)
{
    int h = 0;
    bool maccasins = true;
    for (int i = 0; i < array.Length; i++)
    {
        maccasins = true;
        for (int k = 0; k < i; k++)
        {
            if (array[i] == array[k])
            {
                maccasins = false;
                break;
            }
        }
        if (maccasins)
            h++;
    }
    Console.WriteLine(h);
}

string zashifrovat(string str, int offset)
{
    string encoded_text = "";
    for (int i = 0; i < str.Length;i++)
        encoded_text += Convert.ToChar(str[i] + offset);
    return encoded_text;
}

string rashifrovat(string str, int offset)
{
    string encoded_text = "";
    for (int i = 0; i < str.Length; i++)
        encoded_text += Convert.ToChar(str[i] - offset);
    return encoded_text;
}

/*int size = 0;
Console.Write("Enter len massive: ");
size = int.Parse(Console.ReadLine());
int[] array = { 7, 4, 8, 3, 2 };
int[] array2 = new int[size];


//printArray(array);
fillArray(array2, 0, 10);
printArray(array2);
parni(array2);
neparni(array2);
unikalni(array2);*/

Console.Write("1)Зашифрувати 2)Разшифрувати: ");
int action = int.Parse(Console.ReadLine());
Console.Write("Напишите текст: ");
string str = Console.ReadLine();
Console.Write("Offset: ");
int offset = int.Parse(Console.ReadLine());
if (action == 1)
    Console.Write($"Зашифрованый текст: {zashifrovat(str, offset)}");
else if (action == 2)
    Console.Write($"Росшифрованый текст: {rashifrovat(str, offset)}");
else
    Console.WriteLine("ERROR!");
