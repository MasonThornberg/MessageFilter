using Microsoft.Extensions.DependencyInjection;
using System;
using MessageFilter.Service;
using MessageFilter.Common.Models;
using MessageFilter.Repository;

namespace MessageFilter.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                                    .AddSingleton<ISensitiveTermsRepository, SensitiveTermsRepository>()
                                    .AddSingleton<IFilterService, FilterService>()
                                    .BuildServiceProvider();

            var filterService = serviceProvider.GetService<IFilterService>();

            bool isContinuing = true;

            do
            {
                Console.WriteLine("Enter your test message: \n");
                string messageBody = Console.ReadLine();
                FilterEmailResponseModel response = filterService.EmailFilter(messageBody);

                if (response.IsFlagged)
                {
                    Console.WriteLine("Result:\n\n" + response.MessageBody);
                }
                else
                {
                    Console.WriteLine("There was no issue with your message.");
                }


                Console.WriteLine("\nType \"exit\" to end, or any key to continue. \n" );
                string userInput = Console.ReadLine();

                if (userInput == "exit") isContinuing = false; 

            } while (isContinuing);

            

        }
    }
}
