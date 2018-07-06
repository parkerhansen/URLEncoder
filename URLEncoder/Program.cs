using System;
using System.Collections.Generic;

namespace URLEncoder
{
    class Program
    {
        static List<int> controlChars = new List<int>(new int[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04,
                0x05, 0x06, 0x07, 0x08, 0x09,
                0x0A, 0x0B, 0x0C, 0x0D, 0x0E,
                0x0F, 0x10, 0x11, 0x12, 0x13,
                0x14, 0x15, 0x16, 0x17, 0x18,
                0x19, 0x1A, 0x1B, 0x1C, 0x1D,
                0x1E, 0x1F, 0x7F
            }
        );
        static Dictionary<string, string> changes = new Dictionary<string, string>
        {
            {" ", "%20"},   {"<", "%3C"},   {">", "%3E"},
            {"#", "%23"},   {"\"", "%22"},  {";", "%3B"},
            {"/", "%2F"},   {"?", "%3F"},   {":", "%3A"},
            {"@", "%40"},   {"&", "%26"},   {"=", "%3D"},
            {"+", "%2B"},   {"$", "%24"},   {",", "%2C"},
            {"{", "%7B"},   {"}", "%7D"},   {"|", "%7C"},
            {"\\", "%5C"},  {"^", "%5E"},   {"[", "%5B"},
            {"]", "%5D"},   {"`", "%60"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("URL Encoder");

            do
            {
                Console.Write("Project name: ");
                string projectName = Replace(UserInput());
                Console.Write("Activity name: ");
                string activityName = Replace(UserInput());
                Console.WriteLine("https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf", projectName, activityName);
                Console.Write("Would you like to make another url? (y/n): ");
            }
            while (Console.ReadLine().ToLower().Equals("y"));
        }

        static string UserInput()
        {
            bool valid = false;
            string input = null;
            while (!valid)
            {
                input = Console.ReadLine();
                valid = true;
                foreach (char c in input.ToCharArray())
                {
                    if (controlChars.Contains(c))
                    {
                        Console.WriteLine("Invalid character was inputed, try again: ");
                        valid = false;
                    }
                }
            }
            return input;
        }

        static string Replace(string name)
        {
            name = name.Replace(" ", "%20");
            foreach (var change in changes)
            {
                name = name.Replace(change.Key, change.Value);
            }
            return name;
        }
    }
}

