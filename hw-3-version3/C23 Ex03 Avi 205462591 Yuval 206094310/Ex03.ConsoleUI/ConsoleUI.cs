using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {

        public static void UI()
        {
            Garage m_Garage = new Garage();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine(@"Welcome to the garage! What would you like to do?:
                 1 - Add a vehicle to the garage
                 2 - Present the vehicles in the garage
                 3 - Change a vehicle's status
                 4 - Inflate maximum air in the wheels 
                 5 - Refuel a vehicle (with fuel)
                 6 - Charge an electric vehicle
                 7 - Present Vehicle's data");

                string userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out int intChoice))
                {
                    if (intChoice >= 1 && intChoice <= 7)
                    {
                        switch (userChoice)
                        {
                            case "1":
                                AddVehicleUI(m_Garage);
                                break;
                            case "2":
                                LicenceNumberOfVehiclesInGarageUI(m_Garage);
                                break;
                            case "3":
                                ChangeStateOfVehicleUI(m_Garage);
                                break;
                            case "4":
                                PumpToMaximumAirUI(m_Garage);
                                break;
                            case "5":
                                AddFuelUI(m_Garage);
                                break;
                            case "6":
                                chargeElectricalVehicleUI(m_Garage);
                                break;
                            case "7":
                                VehiclesInformationUI(m_Garage);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                    }
                }
            }
        }

        ///add owner phone and add it to the functions
        public static void AddVehicleUI(Garage i_Garage)
        {
            bool flag = true;
            bool isExistInGarage = false;
            while (flag)
            {
                System.Console.WriteLine("Please enter a vehicle licence number");
                string licenceNumber = Console.ReadLine();
                System.Console.WriteLine("Please enter your name");
                string customerName = Console.ReadLine();
                System.Console.WriteLine("Please enter your phone number");
                string customerPhone = Console.ReadLine();
                isExistInGarage = i_Garage.AddVehicle(licenceNumber);
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
                    case "1":
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
                        System.Console.WriteLine("Please enter the current air presure in your wheels");
                        string airPresure = Console.ReadLine();
                        try
                        {
                            i_Garage.AddFuleCar(customerName, customerPhone, carModel, licenceNumber, carCurrentEnergy, carColor, carNumberOfDoors, airPresure);
                            Console.WriteLine("The car has been added to the garage, thank you.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                       
                        break;
                    case "2":
                        System.Console.WriteLine("Please enter the car model");
                        carModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter the amount of energy in the car");
                        carCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the color of your car");
                        carColor = Console.ReadLine();
                        System.Console.WriteLine("Please enter the number of doors of your car");
                        carNumberOfDoors = Console.ReadLine();
                        System.Console.WriteLine("Please enter the current air presure in your wheels");
                         airPresure = Console.ReadLine();
                        try
                        {
                            i_Garage.AddElectricCar(customerName, customerPhone, carModel, licenceNumber, carCurrentEnergy, carColor, carNumberOfDoors, airPresure);
                            Console.WriteLine("The car has been added to the garage, thank you.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                     
                        break;
                    case "3":
                        System.Console.WriteLine("Please enter the motorcycle model");
                        string motorcycleModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter the amount of fuel in the motorcycle");
                        string motorcycleCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the type of your motorcycle licence");
                        string typeOfLicence = Console.ReadLine();
                        System.Console.WriteLine("Please enter the fuel type of your motorcycle");
                        string motorcyclFuelType = Console.ReadLine();
                        System.Console.WriteLine("Please enter the Engine capacity of your motorcycle");
                        string EngineCapacity = Console.ReadLine();
                        System.Console.WriteLine("Please enter the current air presure in your wheels");
                         airPresure = Console.ReadLine();
                        try
                        {
                            i_Garage.AddFuleMotorcycle(customerName, customerPhone, motorcycleModel, licenceNumber, motorcycleCurrentEnergy, motorcyclFuelType, typeOfLicence, EngineCapacity, airPresure);
                            Console.WriteLine("The motorcycle has been added to the garage, thank you.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                       
                        break;
                    case "4":
                        System.Console.WriteLine("Please enter the motorcycle model");
                        motorcycleModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter how much hours of energy left in your motorcycle");
                        motorcycleCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the type of your motorcycle licence");
                        typeOfLicence = Console.ReadLine();
                        System.Console.WriteLine("Please enter the Engine capacity of your motorcycle");
                        string userEngineCapacity = Console.ReadLine();
                        System.Console.WriteLine("Please enter the current air presure in your wheels");
                         airPresure = Console.ReadLine();
                        try { 
                            i_Garage.AddEclectricMotorcycle(customerName, customerPhone, motorcycleModel, licenceNumber, motorcycleCurrentEnergy, typeOfLicence, userEngineCapacity, airPresure);
                            Console.WriteLine("The motorcycle has been added to the garage, thank you.");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                    case "5":
                        System.Console.WriteLine("Please enter the trunk model");
                        string truckModel = Console.ReadLine();
                        System.Console.WriteLine("Please enter how much energy left in your truck");
                        string truckCurrentEnergy = Console.ReadLine();
                        System.Console.WriteLine("Please enter the fuel type of your truck");
                        string trucklFuelType = Console.ReadLine();
                        System.Console.WriteLine("Is it a refrigerated truck? <Y/N>");
                        string isRefrigerated = Console.ReadLine();
                        System.Console.WriteLine("What is the cargo volume?");
                        string truckCargoVolume = Console.ReadLine();
                        System.Console.WriteLine("Please enter the current air presure in your wheels");
                         airPresure = Console.ReadLine();
                        try
                        {
                            i_Garage.AddTruck(customerName, customerPhone, truckModel, licenceNumber, truckCurrentEnergy, isRefrigerated, truckCargoVolume, airPresure);
                            Console.WriteLine("The truck has been added to the garage, thank you.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                }
                flag = false;
            }
        }

        public static void LicenceNumberOfVehiclesInGarageUI(Garage i_Garage)
        {
           
                Console.WriteLine("Do you want to see licence number of all the vehicles in the garage? <Y/N>");
                string userInput = Console.ReadLine();

                while (userInput != "Y" && userInput != "N")
                {
                    Console.WriteLine("invalid input. please type <Y/N>");
                    userInput = Console.ReadLine();
                }

                if (userInput == "Y")
                {
                    Console.WriteLine(i_Garage.LicenceNumberOfVehiclesInGarage());
                    
                  
                }
                else
                {
                    if (userInput == "N")
                    {
                        Console.WriteLine("Please enter a vehicle status");
                        userInput = Console.ReadLine();
                        Console.WriteLine(i_Garage.LicenceNumberOfVehiclesInGarage(userInput));
                      
                    }
                }
            
        }

        public static void ChangeStateOfVehicleUI(Garage i_Garage)
        {
           
                Console.WriteLine("Please type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                Console.WriteLine("Please type the desired state");
                string newState = Console.ReadLine();
                try
                {
                    i_Garage.ChangeStateOfVehicle(licenceNumber, newState);
                    Console.WriteLine("The vhiecle status has been changed.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Not a proper choise. Please try again");
                }
            
          
        }

        public static void PumpToMaximumAirUI(Garage i_Garage)
        {
          
                Console.WriteLine("Please type a vhiecle licence number.");
                string LicenceNumber = Console.ReadLine();
                try
                {
                    i_Garage.PumpToMaximumAir(LicenceNumber);
                    Console.WriteLine("All the wheels pumped to max, thank you.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Not a proper licence. Please try again");
                }
            
           
        }

        public static void AddFuelUI(Garage i_Garage)
        {
            
                Console.WriteLine("Please type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                Console.WriteLine("please enter the type of fuel you wish to fill.");
                string typeOfFuel = Console.ReadLine();
                Console.WriteLine("please enter the amout of fuel you wish to fill.");
                string fuelToAdd = Console.ReadLine();
                try
                {
                    i_Garage.AddFuel(licenceNumber, typeOfFuel, fuelToAdd);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error happend. Please try again");
                }
            
        }

        public static void chargeElectricalVehicleUI(Garage i_Garage)
        {
           
                Console.WriteLine("Please type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                Console.WriteLine("plese enter the amout of hours you wish to charge.");
                string hoursToCharge = Console.ReadLine();
                try
                {
                    i_Garage.ChargeEngine(licenceNumber, hoursToCharge);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error happend. Please try again");
                }
            
        }

        public static void VehiclesInformationUI(Garage i_Garage)
        {
            
                Console.WriteLine("Plaese type a vhiecle licence number.");
                string licenceNumber = Console.ReadLine();
                try
                {
                    Console.WriteLine(i_Garage.VehiclesInformation(licenceNumber));
                  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error happend. Please try again");
                }
           
        }
    }
}