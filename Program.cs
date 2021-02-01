using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace A1_TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaring ticket properties
            string file = "Tickets.txt";

            int ticketID = 1;
            bool isOpen = true;
            string status;
            string priority;
            string choice;

            //array for 'watchers' that a user can have
            string[] array = new string[10];

            //array for the tickets created by user
            ArrayList TicketList = new ArrayList();


            do
            {
                // ask user a question
                Console.WriteLine("1.) Read data from file.");
                Console.WriteLine("2.) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            //writes the current ticket to the console.
                            Console.WriteLine(TicketList[ticketID]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);

                    //user ticket summary
                    Console.WriteLine("Provide a Short Summary of Your Ticket");
                    string summary = Console.ReadLine();

                    //user priority status
                    Console.WriteLine("Select a Priority Status:");
                    Console.WriteLine("1 - Low | 2 - Medium | 3 - High");
                    int priorityNum = Convert.ToInt32(Console.ReadLine());

                    //boolean whether the ticket is solved or not. starts as 'open' status
                    if (isOpen){
                        status = "Open";
                    } else {
                        status = "Solved";
                    }

                    //turns the users number into a string for status
                    if (priorityNum.Equals(1)){
                        priority = "Low";
                    } else if (priorityNum.Equals(2)){
                        priority = "Medium";
                    } else if (priorityNum.Equals(3)){
                        priority = "High";    
                    } else {
                       priority = "NA"; 
                    }

                    //user name
                    Console.WriteLine("What is Your First and Last Name?");
                    string submitterName = Console.ReadLine();

                    //asks user who their assigned to(?)
                    Console.WriteLine("Who is Assigned to Your Ticket?");
                    string assigned = Console.ReadLine();

                    //asks user how many watchers there are(?)
                    Console.WriteLine("How many Watchers?"); // I dont think that makes sense
                    int amountWatching = Convert.ToInt32(Console.ReadLine());

                    //runs a loop and stores names of each watcher depending on users input
                    for(int i=0; i < amountWatching;i++){
                        Console.WriteLine("Watcher #" + (i+1) +": ");
                        string watcher = Console.ReadLine();
                        //each array index updates as loop continues
                        array[i] = watcher;
                    }
                    
                    //joins the 'watchers' elements into a string, seperated by '|' instead of ','
                    string watching = String.Join("|", array);
                    
                    //concats all elements of the ticket, and pushes it into the ticket array
                    TicketList.Add(ticketID+","+summary+","+status+"," +priority+","+submitterName+","+assigned+","+watching);  
                    //writes to the text file the current ticket
                    sw.WriteLine(TicketList[ticketID]); 

                    //increments by one to start a new ticket so the process can restart.
                    ticketID++;

                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
