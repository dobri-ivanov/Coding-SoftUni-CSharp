using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sentMessages = new Dictionary<string, int>();
            Dictionary<string, int> receivedMessages = new Dictionary<string, int>();

            int capacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] tokens = input.Split('=',StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        string username = tokens[1];
                        int sent = int.Parse(tokens[2]);
                        int received = int.Parse(tokens[3]);

                        if (!sentMessages.ContainsKey(username))
                        {
                            sentMessages.Add(username, sent);
                            receivedMessages.Add(username, received);
                        }
                        break;
                    case "Message":
                        string sender = tokens[1];
                        string receiver = tokens[2];

                        if (sentMessages.ContainsKey(sender) && sentMessages.ContainsKey(receiver))
                        {
                            sentMessages[sender]++;
                            receivedMessages[receiver]++;

                            if (sentMessages[sender] + receivedMessages[sender] >= capacity)
                            {
                                Console.WriteLine($"{sender} reached the capacity!");
                                sentMessages.Remove(sender);
                                receivedMessages.Remove(sender);
                            }
                            if (sentMessages[receiver] + receivedMessages[receiver] >= capacity)
                            {
                                Console.WriteLine($"{receiver} reached the capacity!");
                                sentMessages.Remove(receiver);
                                receivedMessages.Remove(receiver);
                            }
                        }

                        break;
                    case "Empty":
                        string user = tokens[1];
                        if (user == "All")
                        {
                            sentMessages.Clear();
                            receivedMessages.Clear();
                        }
                        else
                        {
                            if (sentMessages.ContainsKey(user) && receivedMessages.ContainsKey(user))
                            {
                                sentMessages.Remove(user);
                                receivedMessages.Remove(user);
                            }
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {sentMessages.Count}");

            foreach (var item in sentMessages)
            {
                string username = item.Key;
                int count = sentMessages[username] + receivedMessages[username];
                Console.WriteLine($"{username} - {count}");
            }
        }
    }
}
