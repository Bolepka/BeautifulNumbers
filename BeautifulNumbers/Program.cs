using System;

namespace BeautifulNumbers
{
    class Program
    {
        //тринадцатиричная система счисления
        static uint DEFAULT_ALPHABET_LENGTH = 13;

        //тринадцатиразрядное число
        static uint DEFAULT_DIMENSION = 13;

        static ulong EntryCount(int sum, uint dimension, uint aLengtn)
        {
            if (sum < 0) return 0;

            if (dimension == 0)
            {
                if (sum == 0) return 1;
                else return 0;

            }

            ulong result = 0;

            for (var charCode = 0; charCode < aLengtn; charCode++)
            {
                result += EntryCount(sum - charCode, dimension - 1, aLengtn);
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            uint alphabetLength;
            Console.WriteLine("Ведите размер алфавита");
            if (!uint.TryParse(Console.ReadLine(),out alphabetLength))
            {
                alphabetLength = DEFAULT_ALPHABET_LENGTH;
                Console.WriteLine($"Не удалось прочитать значение. Будет использовано значение по-умолчанию: {DEFAULT_ALPHABET_LENGTH}");
            }

            uint dimension;
            Console.WriteLine("Ведите разрядность числа");
            if (!uint.TryParse(Console.ReadLine(), out dimension))
            {
                dimension = DEFAULT_DIMENSION;
                Console.WriteLine($"Не удалось прочитать значение. Будет использовано значение по-умолчанию: {DEFAULT_DIMENSION}");
            }

            ulong total = 0;

            //определяем ось симметрии
            uint axis = Divide(dimension);

            var maxBeautySum = Divide(dimension) * ( alphabetLength-1);

            for (var s = 0; s <= maxBeautySum; s++)
            {
                var ecnt = EntryCount(s, axis, alphabetLength);

                total += ecnt * ecnt;
            }

            //при нечётной разрядности ось добавит кратное количетво вариантов
            ulong finish = IsEven(dimension) ? total : total * alphabetLength;

            Console.WriteLine($"Итого: {finish}");
        }

        static bool IsEven(uint dimension)
        {
            return dimension % 2 == 0;
        }

        static uint Divide(uint x)
        {
            return IsEven(x) ? x / 2 : (x - 1) / 2;
        }
    }
}
