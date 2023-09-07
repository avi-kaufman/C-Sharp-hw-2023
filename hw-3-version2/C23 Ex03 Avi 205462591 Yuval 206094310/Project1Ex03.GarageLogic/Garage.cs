using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.FuelEngine;
using static Ex03.GarageLogic.Motorcycle;
using static Ex03.GarageLogic.Vehicle;

///To-do-List:
/// Fix the old code to m_CustomerCards in all functions 
/// Implement AddVhicle
/// check EXCEPTIONs 





namespace Ex03.GarageLogic
{
    public class Garage
    {
        private static List<CustomerCard> m_CustomerCards = new List<CustomerCard>();

        public Garage()
        {

        }


        public static bool AddVehicle(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                return false;
            }
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                foreach (Vehicle vehicle in customerCard.VehicleList)
                {
                    if (vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        vehicle.CurrentStatus = eCurrentCarStatus.NotFixedYet;
                        break;
                    }
                }
            }
            return true;
        }

        public static void AddCustomer(string i_OwnerName, string i_OwnerPhone)
        {
            m_CustomerCards.Add(new CustomerCard(i_OwnerName, i_OwnerPhone));
        }

        //electric car
        public string AddVehicle(string i_CustomerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy, string i_CarColor, string i_NumOfDoors)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int numOfDoors = int.Parse(i_NumOfDoors);
            if (!(System.Enum.IsDefined(eCarColor, i_CarColor) || currentEnergy < 0 || currentEnergy > 5.2 || numOfDoors < 2 || numOfDoors > 5))
            {
                throw new ArgumentException("Invalid input.");
            }
            if (!IsCustomerExist(i_CustomerName))
            {
                AddCustomer(i_CustomerName, i_OwnerPhone);
            }
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                if (customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Car(i_ModelName, i_LicenseNumber, currentEnergy, 5.2f, Enum.TryParse(carColor), numOfDoors));

                }
            }
            return "Added new electric car to customer card sucssesfuly.";
        }
        //fule car
        public string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy, string i_CarColor, string i_NumOfDoors)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int numOfDoors = int.Parse(i_NumOfDoors);
            if (!(System.Enum.IsDefined(eCarColor, i_CarColor) || currentEnergy < 0 || currentEnergy > 44 || numOfDoors < 2 || numOfDoors > 5))
            {
                throw new ArgumentException("Invalid input.");
            }
            if (!IsCustomerExist(i_OwnerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone);
            }
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                if (customerCard.OwnerName == i_OwnerName)
                {
                    customerCard.VehicleList.Add(new Car(i_ModelName, i_LicenseNumber, currentEnergy, 44, eFuelType.Octan95, Enum.TryParse(i_CarColor), numOfDoors));
                }
            }
            return "Added new fule car to customer card sucssesfuly.";
        }

        //electric motorcycle
        public static string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy,
            string i_LicenseType, string i_EngineCapacityInCubicCentimeter)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int engineCpacity = int.Parse(i_EngineCapacityInCubicCentimeter);
            if (!(System.Enum.IsDefined(eLicenseType, i_LicenseType) || currentEnergy < 0 || currentEnergy > 2.4 || engineCpacity < 0))
            {
                throw new ArgumentException("Invalid input.");
            }
            if (!IsCustomerExist(i_OwnerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone);
            }
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                if (customerCard.OwnerName == i_OwnerName)
                {
                    customerCard.VehicleList.Add(new Motorcycle(i_ModelName, i_LicenseNumber, currentEnergy, 2.4f,
                    Enum.TryParse(i_LicenseType), engineCpacity));
                }
            }
            return "Added new electric motorcycle to customer card sucssesfuly.";
        }


        //// NEED TO ADD IN UI i_EngineCapacityInCubicCentimeter!



        //fule motorcycle
        public static string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy,string i_MotorcyclFuelType
            string i_LicenseType, string i_EngineCapacityInCubicCentimeter)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int engineCpacity = int.Parse(i_EngineCapacityInCubicCentimeter);
            if (!(System.Enum.IsDefined(eLicenseType, i_LicenseType) || !(System.Enum.IsDefined(eFuelType, i_MotorcyclFuelType) || currentEnergy < 0 || currentEnergy > 6.3 || engineCpacity < 0))
            {
                throw new ArgumentException("Invalid input.");
            }
            if (!IsCustomerExist(i_OwnerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone);
            }
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                if (customerCard.OwnerName == i_OwnerName)
                {
                    customerCard.VehicleList.Add(new Motorcycle(i_ModelName, i_LicenseNumber, currentEnergy, 6.2f, eFuelType.Octan98,
                    Enum.TryParse(i_LicenseType), engineCpacity));
                }
            }
            return "Added new fule motorcycle to customer card sucssesfuly.";

        }

        /// REMOVE FUELTYPE FROM THE UI FUNCTION
        //fule truck
        public static string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy, string i_RefrigeratedTruck, float i_CargoVolume)
        {

            truckCurrentEnergy, trucklFuelType, isRefrigerated, truckCargoVolume

            float currentEnergy = float.Parse(i_CurrentEnergy);
            bool refrigeratedTruck = bool.Parse(i_RefrigeratedTruck);
            int cargoVolume = int.Parse(i_CargoVolume);
            if (currentEnergy < 0 || currentEnergy > 130 || cargoVolume < 0) || )
            {
                throw new ArgumentException("Invalid input.");
            }
            if (!IsCustomerExist(i_OwnerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone);
            }
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                if (customerCard.OwnerName == i_OwnerName)
                {
                    customerCard.VehicleList.Add(new Truck(i_ModelName, i_LicenseNumber, i_CurrentEnergy, 130, eFuelType.Soler, refrigeratedTruck, cargoVolume));
                }
            }
            return "Added new fule truck to customer card sucssesfuly.";

        }

        public static bool IsCustomerExist(string i_costomerName)
        {
            foreach (CustomerCard CustomerCard in m_CustomerCards)
            {
                if (i_costomerName == CustomerCard.OwnerName)
                {
                    return true;
                }
            }
            return false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string LicenceNumberOfVehiclesInGarage(eCurrentCarStatus CurrentStatus)
        {
            string LicenceNumberOfVehiclesInGarage = "";

            foreach (CustomerCard CustomerCard in m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                {
                    if (CustomerVehicle.CurrentStatus == CurrentStatus)
                    {
                        LicenceNumberOfVehiclesInGarage += (CustomerVehicle.LicenseNumber + "\n");
                    }
                }
            }
            return LicenceNumberOfVehiclesInGarage;
        }

        public static string LicenceNumberOfVehiclesInGarage()
        {
            string LicenceNumberOfVehiclesInGarage = "";

            foreach (CustomerCard CustomerCard in m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                {
                    LicenceNumberOfVehiclesInGarage += (CustomerVehicle.LicenseNumber + "\n");
                }
            }
            return LicenceNumberOfVehiclesInGarage;
        }

        public static void ChangeStateOfVehicle(string i_LicenceNumber, string i_NewState)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry. There is no vehicle in the garage under this lisence: {i_LicenceNumber}");
            }
            try
            {
                foreach (CustomerCard CustomerCard in m_CustomerCards)
                {
                    foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                    {
                        if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                        {
                            CustomerVehicle.CurrentStatus = (eCurrentCarStatus)Enum.Parse(typeof(eCurrentCarStatus), i_NewState);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                throw new FormatException("The input is not a valid vehicle State");
            }
        }

        public static void PumpToMaximumAir(string i_LicenceNumber)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, We cant pump air. There is no vehicle in the garage under this lisence: {i_LicenceNumber}");
            }
            else
            {
                foreach (CustomerCard CustomerCard in m_CustomerCards)
                {
                    foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                    {
                        if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                        {
                            foreach (Wheel wheel in CustomerVehicle.Wheels)
                            {
                                wheel.PumpToMax();
                            }
                        }
                    }
                }
            }
        }


        public static void AddFuel(string i_LicenceNumber, string i_FuelType, string i_FuelToAdd)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, We can't add fuel. There is no vehicle in the garage with the license number: {i_LicenceNumber}");
            }
            else
            {
                foreach (CustomerCard CustomerCard in m_CustomerCards)
                {
                    foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                    {
                        if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                        {
                            if (CustomerVehicle.Engine is ElectricEngine)
                            {
                                throw new ArgumentException($"Sorry, We can't add fuel to your electric car with license number: {i_LicenceNumber}");
                            }
                            else
                            {
                                try
                                {
                                    float fuelToAdd = float.Parse(i_FuelToAdd);
                                    ((FuelEngine)CustomerVehicle.Engine).AddFuel(fuelToAdd, i_FuelType)
                                }
                                catch (FormatException)
                                {
                                    throw new FormatException($"Invalid fuel amount provided: {i_FuelToAdd}");
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void ChargeEngine(string i_LicenceNumber, string i_HoursToCharge)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, there is no vehicle in the garage with the license number: {i_LicenceNumber}");
            }

            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in customerCard.VehicleList)
                {
                    if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                    {
                        if (CustomerVehicle.Engine is ElectricEngine)
                        {
                            try
                            {
                                float hoursToCharge = float.Parse(i_HoursToCharge);
                                ((ElectricEngine)CustomerVehicle.Engine).ChargeEngine(hoursToCharge);
                            }
                            catch (FormatException)
                            {
                                throw new FormatException($"Invalid value for hours to charge: {i_HoursToCharge}");
                            }
                        }
                    }
                }
            }
            throw new ArgumentException($"Sorry, the vehicle with license number: {i_LicenceNumber} is not electric and cannot be charged.");
        }

        public static string VehiclesInformation(string i_LicenceNumber)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, there is no car in the garage under this lisence : {i_LicenceNumber}");
            }
            else
            {
                foreach (CustomerCard customerCard in m_CustomerCards)
                {
                    foreach (Vehicle CustomerVehicle in customerCard.VehicleList)
                    {
                        if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                        {
                            return CustomerVehicle.ToString();
                        }
                    }
                }
            }
            return "";
        }

        private static bool IsVehicleInGarage(string licenseNumber)
        {
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in customerCard.VehicleList)
                {
                    if (CustomerVehicle.LicenseNumber == licenseNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}