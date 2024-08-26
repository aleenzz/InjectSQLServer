using System;
using System.IO;
using System.Text;

namespace GetByteArray
{
    internal class Program
    {
        public static void Main()
        {

            string filePath = @"HarmonyHook.exe";

            try
            {

                byte[] fileBytes = File.ReadAllBytes(filePath);


                string byteArrayString = ConvertToByteArrayString(fileBytes);


                Console.WriteLine("byte[] data = new byte[] {");
                Console.WriteLine(byteArrayString);
                Console.WriteLine("};");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private static string ConvertToByteArrayString(byte[] byteArray)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byteArray.Length; i++)
            {
                if (i > 0 && i % 12 == 0)
                {
                    sb.AppendLine(); 
                }
                sb.AppendFormat("0x{0:X2}", byteArray[i]);
                if (i < byteArray.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }
    }
}
