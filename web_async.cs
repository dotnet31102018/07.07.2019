using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static public string FormatBytes(long bytes)
        {
            string[] magnitudes =
                new string[] { "GB", "MB", "KB", "Bytes" };
            long max =
                (long)Math.Pow(1024, magnitudes.Length);

            return string.Format("{1:##.##} {0}",
                magnitudes.FirstOrDefault(
                    magnitude =>
                    bytes > (max /= 1024)) ?? "0 Bytes",
              (decimal)bytes / (decimal)max);
        }


        private static async Task WriteWebRequestSizeAsync(string url)
        {
            try
            {
                WebRequest webRequest =
                    WebRequest.Create(url);
                WebResponse response =
                    await webRequest.GetResponseAsync();
                using (StreamReader reader =
                    new StreamReader(
                        response.GetResponseStream()))
                {
                    string text =
                        await reader.ReadToEndAsync();
                    Console.WriteLine(
                        FormatBytes(text.Length));
                }
            }
            catch (WebException)
            {
                // ...
            }
            catch (IOException)
            {

                // ...
            }
            catch (NotSupportedException)
            {
                // ...
            }
        }

        public static void Main(string[] args)
        {
            string url = "http://www.IntelliTect.com";
            if (args.Length > 0)
            {
                url = args[0];
            }

            Console.Write(url);

            Task task = WriteWebRequestSizeAsync(url);

            while (!task.Wait(100))
            {
                Console.Write(".");
            }
            // ...

        }

    }
}
