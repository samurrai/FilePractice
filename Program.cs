using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Symbol> symbols = new List<Symbol>();
            for (int i = 0; i < 256; i++)
            {
                Symbol tmp = new Symbol() {
                    Value = (char)i,
                    Counter = 0
                };
                symbols.Add(tmp);
            }
            using (FileStream reader = new FileStream("data.txt", FileMode.Open))
            {
                for (int i = 0; i < reader.Length; i++)
                {
                    int current = reader.ReadByte();
                    for (int j = 0; j < symbols.Count; j++)
                    {
                        if (symbols[j].Value == current)
                        {
                            symbols[j].Counter++;
                            break;
                        }
                    }
                }
            }
            foreach (var symbol in symbols)
            {
                if (symbol.Counter > 0)
                {
                    Console.WriteLine($"{symbol.Value} - {symbol.Counter}");
                }
            }
            
            using (StreamWriter streamWriter = new StreamWriter("text.txt"))
            {
                streamWriter.WriteLine("Руслан");
                streamWriter.WriteLine("Шадикьян");
                streamWriter.WriteLine("15");
            }
        }
    }
}
