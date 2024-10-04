using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MinesweeperLibrary
{
    public class Utils
    {
        public static String GetUserInputStr(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static int GetUserInput(string prompt)
        {
            int intInput;
            Console.WriteLine(prompt);
            while (!int.TryParse(Console.ReadLine(), out intInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return intInput;
        }

        public static void RewardFound(string reward)
        {
            Console.WriteLine($"\u001b[32mYou found a {reward}!\u001b[0m");

            switch (reward)
            {
                case "Detector":
                    Console.WriteLine("A detector has been added to your Inventory\n" +
                        "You can use this item to test if a bomb is in a spot");
                    break;
                case "Scavenge":
                    Console.WriteLine("A bomb has been located for you!");
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Pick a reward from the rewards inventory
        /// Returns the reward selected
        /// </summary>
        /// <param name="rewards"></param>
        /// <returns></returns>
        public static string PickReward(List<string> rewards)
        {

            int choice = -1;

            while (true)
            {
                Console.WriteLine("You have the following rewards");
                for (int i = 0; i < rewards.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {rewards[i]}");
                }
                choice = GetUserInput(" Enter which rewards you would like to use: ");
                if (!(choice > 0) && !(choice <= rewards.Count))
                {
                    Console.WriteLine("Invalid choice. Please select a valid reward.");
                    continue;
                }

                string reward = rewards[choice - 1];

                switch (reward)
                {
                    case "Detector":
                        Console.WriteLine("You have used a detector \n" +
                            "Your next turn will not trigger any bombs but instead\n" +
                            "Will warn you if you selected a bomb ");


                        break;
                    case "Scavenge":
                        Console.WriteLine("You have used a scavenge");
                        break;
                    default:
                        break;
                }
                return reward;
            }



        }
    }
}
