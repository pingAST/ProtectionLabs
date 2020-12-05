using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ProtectionLabs
{
    public class CaesarCipher
    {
        public static string Alph { get; set; } = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        
        public static string Encryption(string text, int shift)
        {
            text = text.ToLower(CultureInfo.CurrentCulture);
            var res = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = Alph.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    res.Append(c.ToString(CultureInfo.CurrentCulture));
                }
                else
                {
                    res.Append(Alph[(Alph.Length + index + shift) % Alph.Length]);
                    
                }
            }
                
           
            return res.ToString();
        }
        
    }
}
