using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ex03.ConsoleUI;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Vehicle;
using static Ex03.GarageLogic.Garage;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        public static void UI()
        {
            bool flag = true;
            while (flag)
            {   
                System.Console.WriteLine(@"Welcome to the garage! What would you like to do?:
                 1 - Add a vehicle to the garage
                 2 - Present the vehicles in the garage
                 3 - Change a vehicle's status
                 4 - Inflate maximum air in the wheels 
                 5 - Refuel a vehicle (with fuel)
                 6 - Charge an electric vehicle
                 7 - Present Vehicle's data");

                string userChoice = Console.ReadLine();
                int intCoice = 0;

                while (!int.TryParse(userChoice, out intCoice) || intCoice < 1 || intCoice > 7)
                {
                    Console.WriteLine("Invalid input, please try again");
                    userChoice = Console.ReadLine();
                }

                switch (userChoice)
                {
                    case 1:
                        AddVehicleUI();
                        break;
                    case 2:
                        LicenceNumberOfVehiclesInGarageUI();
                        break;
                    case 3:
                        ChangeStateOfVehicleUI();
                        break;
                    case 4:
                        PumpToMaximumAirUI();
                        break;
                    case 5:
                        AddFuelUI();
                        break;
                    case 6:
                        chargeElectricalVehicleUI();
                        break;
                    case 7:
                        VehiclesInformationUI();
                        break;
                }

                Console.WriteLine("If you want to reload the menu please press any key. If you want to quit press Q");
                if (Console.ReadLine() == "Q")
                {
                    continueToAsk = false;
                }
            }
        }

        public static void AddVehicleUI()
        {
            bool flag = true;
            bool isExistInGarage = false;
            while (flag)
            {
                System.Console.WriteLine("Please enter a vehicle licence number");
                string licenceNumber = Console.ReadLine();
                System.Console.WriteLine("Please enter your name");
                string customerName = Console.ReadLine();
                isExistInGarage = Garage.AddVehicle(licenceNumber);
                if (!isExistInGarage)
                {
                    System.Console.WriteLine(@"What is the type of your vehicle? :
                        1 - Car
                        2 - Electric Car
                        3 - Motorcycle
                        4 - Electric Motorcycle 
                        5 - Trunk");
                }

                string userChoice = Console.ReadLine();
                int intCoice = 0;

                while (!int.TryParse(userChoice, out intCoice) || intCoice < 1 || intCoice > 5)
                {
                    Console.WriteLine("Invalid input, please try again");
                    userChoice = Console.ReadLine();
                }

                switch (userChoice)
                {
                    case 1:
                        System.Console.WriteLine("Please enter the car model");
                        string carModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter the amount of fuel in the car");
                        string carCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the color of your car");
                        string carColor = Console.ReadLine();
                        System.Console.WriteLine("Please enter the number of doors of your car");
                        string carNumberOfDoors = Console.ReadLine();
                        System.Console.WriteLine("Please enter the fuel type of your car");
                        string carFuelType = Console.ReadLine();
                        Garage.AddVehicle(customerName, carModel, licenceNumber, carCurrentEnergy, carFuelType, carColor, carNumberOfDoors);
                        break;
                    case 2:
                        System.Console.WriteLine("Please enter the car model");
                        string carModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter the amount of energy in the car");
                        string carCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the color of your car");
                        string carColor = Console.ReadLine();
                        System.Console.WriteLine("Please enter the number of doors of your car");
                        string carNumberOfDoors = Console.ReadLine();
                        Garage.AddVehicle(customerName, carModel, licenceNumber, carCurrentEnergy, carColor, carNumberOfDoors);
                        break;
                    case 3:
                        System.Console.WriteLine("Please enter the motorcycle model");
                        string motorcycleModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter the amount of fuel in the motorcycle");
                        string motorcycleCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the type of your motorcycle licence");
                        string typeOfLicence = Console.ReadLine();
                        System.Console.WriteLine("Please enter the fuel type of your motorcycle");
                        string motorcyclFuelType = Console.ReadLine();
                        Garage.AddVehicle(customerName, motorcycleModel, licenceNumber, motorcycleCurrentEnergy, motorcyclFuelType, typeOfLicence);
                        break;
                    case 4:
                        System.Console.WriteLine("Please enter the motorcycle model");
                        string motorcycleModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter how much hours of energy left in your motorcycle");
                        string motorcycleCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the type of your motorcycle licence");
                        string typeOfLicence = Console.ReadLine();
                        Garage.AddVehicle(customerName, motorcycleModel, licenceNumber, motorcycleCurrentEnergy, typeOfLicence);
                        break;
                    case 5:
                        System.Console.WriteLine("Please enter the trunk model");
                        string truckModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter how much hours of energy left in your motorcycle");
                        string truckCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the fuel type of your truck");
                        string trucklFuelType = Console.ReadLine();
                        System.Console.WriteLine("Is it a refrigerated truck? <Y/N>");
                        string isRefrigerated = Console.ReadLine();
                        System.Console.WriteLine("What is the cargo volume?");
                        string truckCargoVolume = Console.ReadLine();
                        Garage.AddVehicle(customerName, truckModel, licenceNumber, truckCurrentEnergy, trucklFuelType, isRefrigerated, truckCargoVolume);
                        break;
                }
            }
        }

        public static void LicenceNumberOfVehiclesInGarageUI()
        {
            bool flag = true;
            bool validInput = false;
            while (flag)
            {
                Console.WriteLine("Do you want to see licence number of all the vehicles in the garage? <Y/N>");
                string userInput = Console.ReadLine();

                while (userInput != "Y" || userInput != "N")
                {
                    Console.WriteLine("invalid input. please type <Y/N>");
                    string userInput = Console.ReadLine();
                }

                if (userInput = "Y")
                {
                    Garage.LicenceNumberOfVehiclesInGarage();
                    flag = false;
                    validInput = false;
                }
                else
                {
                    if (userInput = "N")
                    {
                        Console.WriteLine("Please enter a vehicle status");
                        string userInput = Console.ReadLine();
                        Garage.LicenceNumberOfVehiclesInGarage(userInput);
                        flag = false;
                        validInput = false;
                    }
                }      
            }
        }

        public static void ChangeStateOfVehicleUI()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                Console.WriteLine("Please type the desired state");
                string newState = Console.ReadLine();
                try
                {
                    Garage.ChangeStateOfVehicle(licenceNumber, newState)
                    flag = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Not a proper choise. Please try again");
                }
            }
            Console.WriteLine("The vhiecle status has been changed.");
        }

        public static void PumpToMaximumAirUI()
        {
            bool flag = true
            while (flag)
            {
                Console.WriteLine("Please type a vhiecle licence number.");
                string LicenceNumber = Console.ReadLine();
                try
                {
                    Garage.PumpToMaximumAir(LicenceNumber);
                    flag = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Not a proper licence. Please try again");
                }
            }
            Console.WriteLine("All the wheels pumped to max, thank you.");
        }

        public static void AddFuelUI()
        {
            bool flag = true
            while (flag)
            {
                Console.WriteLine("Please type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                Console.WriteLine("please enter the type of fuel you wish to fill.");
                string typeOfFuel = Console.ReadLine();
                Console.WriteLine("please enter the amout of fuel you wish to fill.");
                string fuelToAdd = Console.ReadLine();
                try
                {
                    Garage.AddFuel(licenceNumber, typeOfFuel, fuelToAdd);
                    flag = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error happend. Please try again");
                }
            }
        }

        public static void chargeElectricalVehicleUI()
        {
            bool flag = true
            while (flag)
            {
                Console.WriteLine("Please type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                Console.WriteLine("plese enter the amout of hours you wish to charge.");
                string hoursToCharge = Console.ReadLine();
                try
                {
                    Garage.ChargeEngine(licenceNumber, hoursToCharge);
                    flag = false;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error happend. Please try again");
                }
            }
        }

        public static void VehiclesInformationUI()
        {
            bool flag = true
            while (flag)
            {
                Console.WriteLine("Plaese type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                try
                {
                    Garage.VehiclesInformation(licenceNumber);
                    flag = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error happend. Please try again");
                }
            }
        }