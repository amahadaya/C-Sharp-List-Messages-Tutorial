using System;
using System.Collections.Generic;
using freeclimb.Api;
using freeclimb.Client;
using freeclimb.Model;


namespace ListRecordings
{

    public class Program
    {
        public static string getFreeClimbAccountId()
        {
            return System.Environment.GetEnvironmentVariable("ACCOUNT_ID");
        }
        public static string getFreeClimbApiKeys()
        {
            return System.Environment.GetEnvironmentVariable("API_KEY");
        }

        public static string getFromNumber()
        {
            return System.Environment.GetEnvironmentVariable("FROM_NUMBER");
        }

        public static string getToNumber()
        {
            return System.Environment.GetEnvironmentVariable("TO_NUMBER");
        }

        static void Main(string[] args)
        {
            // Create FreeClimbClient object
            //FreeClimbClient client = new FreeClimbClient(getFreeClimbAccountId(), getFreeClimbApiKeys());
            Configuration config = new Configuration();
            config.BasePath = "https://www.freeclimb.com/apiserver/";
            config.Username = getFreeClimbAccountId();
            config.Password = getFreeClimbApiKeys();
            DefaultApi Api = new DefaultApi(config);

            string to = getToNumber();
            Console.WriteLine(to);
            // Use as env variable rather than defining it in the code
            string from = getFromNumber();

            MessagesList response = Api.ListSmsMessages(to, from, "2022-12-12 15:00:00", "2022-12-12 22:00:00", "outbound");

            Console.WriteLine(response.Messages);

            for (int i = 0; i < response.Messages.Count; i++)
            {
                Console.WriteLine(response.Messages[i].Text);
            }

        }

    }
}