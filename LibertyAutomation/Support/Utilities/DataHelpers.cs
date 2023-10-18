using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Faker;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Graph;
using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using LibertyAutomation.Hooks;
using MongoDB.Driver.Core.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace LibertyAutomation.Utilities
{
    class DataHelpers
    {
        public string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        public string GenerateFirstName()
        {
            return NameFaker.FirstName();
        }

        public string GenerateLastName()
        {
            return NameFaker.LastName();
        }

        public string RandomCellDigits(int length)
        {
            var random = new Random();

            var num1 = "0";
            var num2 = random.Next(6, 9);
            var num3 = random.Next(1, 3);
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return num1 + num2 + num3 + s;
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        public String RandomEmail()
        {
            return NameFaker.FirstName() + NameFaker.FirstName() + "@testdata.com";
        }

        public string RangedRandomDigits(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max).ToString();
        }

        public string RandomDate(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max).ToString();
        }



        public bool CheckFileDownloaded2(string filename)
        {
            bool exist = false;
            string username = Environment.GetEnvironmentVariable("USERPROFILE")
                .Substring(Environment.GetEnvironmentVariable("USERPROFILE").LastIndexOf("\\") + 1);
            string Path = "\\\\grp-userdata\\NASCITRIX\\VDIRedirected\\" + username + "\\Downloads";
            string[] filePaths = System.IO.Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {

                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if ((DateTime.Now - thisFile.LastWriteTime.TimeOfDay).Minute <= 3)
                    {
                        exist = true;
                        System.IO.File.Delete(p);
                        break;
                    }

                }
            }
            return exist;
        }

        [Obsolete]
        
        public bool VerifyDownloadedPdf(string filename)
        {
            bool exist = false;
            string username = Environment.GetEnvironmentVariable("USERPROFILE")
                 .Substring(Environment.GetEnvironmentVariable("USERPROFILE").LastIndexOf("\\") + 1);
            string Path = @"\\grp-userdata\\NASCITRIX\\VDIRedirected\\" + username + "\\Downloads\\";
            string[] filePaths = System.IO.Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);

                    if (thisFile.Extension == ".pdf")
                    {
                        exist = true;
                        System.IO.File.Delete(p);
                        break;
                    }

                }

            }

            return exist;

        }




        public String RandomRegNumber(String RegistrationType)

        {
            String year = RangedRandomDigits(1900, DateTime.Now.Year);
            String num = RandomDigits(6);
            String value = null;

            switch (RegistrationType.ToUpper())
            {
                case String a when RegistrationType.ToUpper().Contains("ARTICLE 21"):
                    value = "08";
                    break;
                case String a when RegistrationType.ToUpper().Contains("CLOSE CORPORATION"):
                    value = "23";
                    break;
                case String a when RegistrationType.ToUpper().Contains("EXTERNAL COMPANY"):
                    value = "10";
                    break;
                case String a when RegistrationType.ToUpper().Contains("INC"):
                    value = "21";
                    break;
                case String a when RegistrationType.ToUpper().Contains("LIMITED BY GUARANTEE"):
                    value = "09";
                    break;
                case String a when RegistrationType.ToUpper().Contains("PRIMARY COOPERATIVE"):
                    value = "24";
                    break;
                case String a when RegistrationType.ToUpper().Contains("PRIVATE COMPANY"):
                    value = "07";
                    break;
                case String a when RegistrationType.ToUpper().Contains("PUBLIC COMPANY"):
                    value = "06";
                    break;
                case String a when RegistrationType.ToUpper().Contains("SECONDARY COOPERATIVE"):
                    value = "25";
                    break;
                case String a when RegistrationType.ToUpper().Contains("STATE OWNED COMPANY"):
                    value = "30";
                    break;
                case String a when RegistrationType.ToUpper().Contains("STATUTORY BODY"):
                    value = "31";
                    break;
                case String a when RegistrationType.ToUpper().Contains("TERTIARY COOPERATIVE"):
                    value = "26";
                    break;
                case String a when RegistrationType.ToUpper().Contains("TYPE 11"):
                    value = "11";
                    break;
                case String a when RegistrationType.ToUpper().Contains("TYPE 20"):
                    value = "20";
                    break;
                case String a when RegistrationType.ToUpper().Contains("UNLIMITED"):
                    value = "22";
                    break;
                case String a when RegistrationType.ToUpper().Contains("SECTION 21A"):
                    value = "12";
                    break;
            }
            return year + "/" + num + "/" + value;
        }


        public String generateTax()
        {
            Random rnd = new Random();
            int sum = 0;
            int checkSumNum;
            int[] na = new int[10];

            for (int c = 1; c < 10; c++)
            {
                int month = rnd.Next(0, 9);
                na[c] = month;
            }

            for (int i = 1; i < 10; i++)
            {
                int f;
                if ((i % 2) != 0)
                {

                    if ((na[i] * 2) > 9)
                    {
                        string s1, s2;
                        string v = (na[i] * 2).ToString();
                        s1 = v.Substring(0, 1);
                        s2 = v.Substring(1);
                        f = Convert.ToInt32(s1) + Convert.ToInt32(s2);
                    }
                    else
                    {
                        f = na[i] * 2;
                    }

                }
                else
                {
                    f = na[i];
                }
                sum = sum + f;

            }
            if ((sum % 10) == 0)
                checkSumNum = 0;
            else
                checkSumNum = 10 - sum % 10;
            int temp;
            string tax = null;
            for (int y = 1; y < 10; y++)
            {
                temp = na[y];
                tax = tax + temp.ToString();
            }
            string checkSum = checkSumNum.ToString();
            tax = tax + checkSum;
            return tax;
        }
        public String generateAccountNumber()
        {
            Random rnd = new Random();
            int sum = 0;
            int checkSumNum;
            int[] na = new int[10];

            for (int c = 1; c < 10; c++)
            {
                int month = rnd.Next(0, 9);
                na[c] = month;
            }

            for (int i = 1; i < 10; i++)
            {
                int f;
                if ((i % 2) != 0)
                {

                    if ((na[i] * 2) > 9)
                    {
                        string s1, s2;
                        string v = (na[i] * 2).ToString();
                        s1 = v.Substring(0, 1);
                        s2 = v.Substring(1);
                        f = Convert.ToInt32(s1) + Convert.ToInt32(s2);
                    }
                    else
                    {
                        f = na[i] * 2;
                    }

                }
                else
                {
                    f = na[i];
                }
                sum = sum + f;

            }
            if ((sum % 10) == 0)
                checkSumNum = 0;
            else
                checkSumNum = 10 - sum % 10;
            int temp;
            string tax = null;
            for (int y = 1; y < 10; y++)
            {
                temp = na[y];
                tax = tax + temp.ToString();
            }
            string checkSum = checkSumNum.ToString();
            tax = tax + checkSum;
            return tax;
        }

        /* public String generateAccountNumber()
         {
             Random rnd = new Random();
             int sum = 0;
             int checkSumNum;
             int[] na = new int[10];

             for (int c = 1; c < 10; c++)
             {
                 int month = rnd.Next(0, 9);
                 na[c] = month;
             }

             for (int i = 1; i < 10; i++)
             {
                 int f;
                 if ((i % 2) != 0)
                 {

                     if ((na[i] * 2) > 9)
                     {
                         string s1, s2;
                         string v = (na[i] * 2).ToString();
                         s1 = v.Substring(0, 1);
                         s2 = v.Substring(1);
                         f = Convert.ToInt32(s1) + Convert.ToInt32(s2);
                     }
                     else
                     {
                         f = na[i] * 2;
                     }

                 }
                 else
                 {
                     f = na[i];
                 }
                 sum = sum + f;

             }
             if ((sum % 10) == 0)
                 checkSumNum = 0;
             else
                 checkSumNum = 10 - sum % 10;
             int temp;
             string tax = null;
             for (int y = 1; y < 10; y++)
             {
                 temp = na[y];
                 tax = tax + temp.ToString();
             }
             string checkSum = checkSumNum.ToString();
             tax = tax + checkSum;
             return tax;
         }

 */

        public DateTime RandomDate()
        {
            int startYear = 1960;
            //string outputDateFormat = "yyyyMMdd";
            DateTime start = new DateTime(startYear, 1, 1);
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        public string RandomIDNumber(DateTime date, bool isMale, bool isSouthAfrican)
        {
            int oddSum = 0, evenSum = 0, checksum;
            string ID, gender, citizenship, num, evenConcat = "", evenDouble, dob = date.ToString("yyMMdd"), randoms;

            gender = isMale ? (5 + new Random().Next(5)).ToString() : (new Random().Next(5)).ToString();

            randoms = String.Concat("000", new Random().Next(999).ToString());
            gender += randoms.Substring(randoms.Length - 3);

            citizenship = isSouthAfrican ? "0" : "1";
            num = (8 + new Random().NextDouble() + 0.5).ToString().Substring(0, 1);

            ID = dob + gender + citizenship + num;

            for (int i = 0; i < ID.Length; i++)
            {
                if (i % 2 != 0)
                    evenConcat += ID.Substring(i, 1);
                else
                    oddSum += Int32.Parse(ID.Substring(i, 1));
            }
            evenDouble = (Int64.Parse(evenConcat) * 2).ToString();

            for (int a = 0; a < evenDouble.Length; a++)
                evenSum += Int32.Parse(evenDouble.Substring(a, 1));

            string sumofboth = (evenSum + oddSum).ToString();
            checksum = (Int32.Parse(sumofboth) * 9) % 10;

            return ID + checksum;
        }
        public string addVat(string value)
        {

            string v;
            if (Convert.ToDouble(value) == 0)
            {

                v = value.ToString();
            }
            else
            {
                double finalVal = (Convert.ToDouble(value) * 0.15) + Convert.ToDouble(value);
                v = finalVal.ToString("#.##");

            }
            return v;
        }

        public string convertAmount(string value)
        {
            string vF;
            int l = value.Length;

            if (l >= 4)
            {
                vF = value.Substring(0, l - 3) + "," + value.Substring(l - 3);
            }
            else
            {
                vF = value;
            }
            return vF;
        }
        public double ConvertAmountToNumber(string GrabAmount)
        {


            double amount;
            if (GrabAmount.Length > 8)
            {
                int y = GrabAmount.Length - 8;
                amount = Convert.ToDouble(GrabAmount.Substring(1, y) + GrabAmount.Substring(GrabAmount.Length - 6));


            }
            else
            {
                amount = Convert.ToDouble(GrabAmount.Substring(GrabAmount.Length - 6));
            }
            return amount;
        }

        public static void CreateFolder(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        public static void WriteBrowserLogs(IWebDriver driver)
        {
             string sConsoleLogs = liberty.sPath + "TestData\\BrowserLogs\\Logs.txt";
            if (!System.IO.File.Exists(sConsoleLogs))
            {
                System.IO.File.Create(sConsoleLogs).Dispose();
            }

            using (StreamWriter sw = System.IO.File.AppendText(sConsoleLogs))
            {
                var entries = driver.Manage().Logs.GetLog(LogType.Browser);
                foreach (var entry in entries)
                {
                    sw.WriteLine(entry.ToString());
                }
            }
        }
        public static void ConnectToOracleDatabase()
        {
            string connectionString = "User Id=interface;Password=milktart;Data Source=(DESCRIPTION=" +
            "(ADDRESS=(PROTOCOL=TCP)(HOST=corptudevlz2)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=lcutest)));";

            OracleConnection con = new OracleConnection(connectionString);
            con.Open();
            con.Close();
        }
        public static void QueryDatabase()
        {
        //    SqlCommand command;
        //    SqlDataReader reader;
        //    String sql, Output = "";

        //    sql = "Select * From "
        }
    }
}
