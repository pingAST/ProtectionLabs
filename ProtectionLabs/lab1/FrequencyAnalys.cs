using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace ProtectionLabs
{
    public static class FrequencyAnalys
    {

        public static string Alph { get; set; } = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static Dictionary<Char, int> Frequency(string patchFile)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();
            using (StreamReader sr = new StreamReader(patchFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower(CultureInfo.CurrentCulture);

                    foreach (char c in line)
                    {
                        var index = Alph.IndexOf(c);
                        if (index >= 0)
                        {
                            if (!freq.ContainsKey(c))
                            {
                                freq[c] = 1;
                            }
                            else
                            {
                                freq[c]++;
                            }

                        }


                    }
                }
            }

            return freq;

        }

        public static Dictionary<string, int> CalculateLetterFrequencies(string patchFile, int gramSize)
        {

            Dictionary<string, int> freq = new Dictionary<string, int>();

           

            int[] gramCounts = new int[(int)Math.Pow(34, gramSize)];
            // Буфер для последних символов для формирования N-граммов
            char[] lastChars = new char[2];
            for (int j = 0; j < gramSize; j++)
            {
                lastChars[j] = 'а';
            }
            string gramString = "";
            int charCount = 0;

            using (StreamReader sr = new StreamReader(patchFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower(CultureInfo.CurrentCulture);

                    foreach (char c in line.ToCharArray())
                    {
                        var index = Alph.IndexOf(c);
                        if (index >= 0) //если это русский символ
                        {
                          
                            for (int j = gramSize - 1; j > 0; j--)
                            {
                                lastChars[j] = lastChars[j - 1];
                            }
                            lastChars[0] = c;

                           // Заполняем N-грамм
                            if (charCount >= gramSize - 1)
                            {
                                gramString = "";
                               
                                for (int j = gramSize - 1; j >= 0; j--)
                                {
                                    
                                    gramString += lastChars[j].ToString(CultureInfo.CurrentCulture);
                                }
                               
                                gramString = gramString.ToLower(CultureInfo.CurrentCulture);
                                int letter = 0;
                                int i = 0;
                                foreach (char l in gramString.ToCharArray()) // Рассчитываем индекс i для подсчета массива
                                {
                                    
                                    i += ((int)l - 1072) * (int)Math.Pow(34, letter);
                                    
                                    
                                    letter++;
                                }
                                gramCounts[i]++; // Увеличение количества
                            }
                            charCount++;

                        }
                    }
                }

                for (int i = 0; i < gramCounts.Length; i++)
                {
                    int gramCount = gramCounts[i];
                    if (gramCount == 0) // Игнорировать N-граммы, которых нет
                    {
                        continue;
                    }
                    
                    string gramName = "";
                    int iCopy = i;
                    for (int b = gramSize - 1; b >= 0; b--) // Реконструируем N-грамм (символы)
                    {
                        gramName = ((char)(iCopy / (int)Math.Pow(34, b) + 1072)).ToString(CultureInfo.CurrentCulture) + gramName;
                        iCopy -= (int)(iCopy / (int)Math.Pow(34, b)) * (int)Math.Pow(34, b);
                    }
                    freq[gramName] = gramCount;
                    
                }

                return freq;

            }

        }
    }
}

