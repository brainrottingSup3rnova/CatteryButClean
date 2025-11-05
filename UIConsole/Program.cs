using Application.UseCases;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System.Reflection.Metadata.Ecma335;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cattery cattery = new Cattery(null);
            Console.WriteLine("Hi, and welcome to our Cat Shelter Management System!");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine("1. Add a new cat to the shelter");
                Console.WriteLine("2. View all cats in the shelter");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("You chose to add a new cat.");

                        string name;
                        Console.WriteLine("Please enter the cat's name:");
                        name = Console.ReadLine();

                        string breed;
                        Console.WriteLine("Please enter the cat's breed:");
                        breed = Console.ReadLine();

                        bool isMale = false;
                        Console.WriteLine("Please enter the cat's sex (M/F):");
                        if (Console.ReadLine() == "M")
                        {
                            isMale = true;
                        }
                        else if (Console.ReadLine() == "F")
                        {
                            isMale = false;
                        }

                        Console.WriteLine("Please enter the cat's arrival date (yyyy-mm-dd):");
                        DateTime arrivalDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Please enter the cat's birthdate (yyyy-mm-dd) (can be null):");
                        string birthdateInput = Console.ReadLine();
                        DateTime? birthdate = string.IsNullOrEmpty(birthdateInput) ? null : DateTime.Parse(birthdateInput);

                        Console.WriteLine("Please enter a description for the cat (can be null):");
                        string? description = string.IsNullOrEmpty(Console.ReadLine()) ? null : Console.ReadLine();

                        try
                        {
                            Console.WriteLine("Creating cat...");
                            Cat cat = new Cat(name, breed, isMale, arrivalDate, null, birthdate, description);
                            cattery.AddCat(cat);

                            Console.WriteLine("Cat created and added successfully!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error creating cat: {ex.Message}");
                        }
                        Console.WriteLine("Do you wish to continue?");
                        string continueInput = Console.ReadLine();
                        if (continueInput == "no")
                        {
                            exit = true;
                        }
                        else
                        {
                            exit = false;
                        }
                        break;
                    case "2":
                        Console.WriteLine("You chose to view all cats.");
                        cattery.GetAllCats();
                        Console.WriteLine("Do you wish to adopt a cat?");
                        string adoptInput = Console.ReadLine();
                        if(adoptInput == "yes")
                        {
                            Console.WriteLine("Please enter the name of the cat you wish to adopt:");
                            string catName = Console.ReadLine();
                            Cat catToAdopt = cattery.GetCatByName(catName);
                            if(catToAdopt != null)
                            {
                                Console.WriteLine("Please enter your name");
                                string adopterName = Console.ReadLine();
                                Console.WriteLine("Please enter your surname");
                                string adopterSurname = Console.ReadLine();
                                Console.WriteLine("Please enter your email");
                                Email email = new Email(Console.ReadLine());
                                Console.WriteLine("Please enter your phone number");
                                PhoneNumber phoneNumber = new PhoneNumber(Console.ReadLine());
                                Console.WriteLine("Please enter your address");
                                Address address = new Address(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                                Console.WriteLine("Please enter your TIN");
                                TIN tin = new TIN(Console.ReadLine());

                                try
                                {
                                    Adopter adopter = new Adopter(adopterName, adopterSurname, email, phoneNumber, address, tin);
                                    cattery.RegisterAdopter(adopter);
                                    Console.WriteLine("Adopter registered successfully!");
                                    Adoption adoption = new Adoption(adopter,catToAdopt, DateTime.Now);
                                    cattery.RegisterAdoption(adoption);
                                    Console.WriteLine("Adoption registered successfully!");
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine($"Error creating adopter: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that cat is not available for adoption.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Do you wish to continue?");
                            string continueInput2 = Console.ReadLine();
                            if (continueInput2 == "no")
                            {
                                exit = true;
                            }
                            else
                            {
                                exit = false;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please restart the application and choose a valid option.");
                        break;
                }
            }
        }
    }
}
