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
        private List<CustomerCard> m_CustomerCards;

        public Garage()
        {
            m_CustomerCards = new List<CustomerCard>();
        }


        public bool AddVehicle(string i_LicenseNumber)
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

        public void AddCustomer(string i_OwnerName, string i_OwnerPhone)
        {
            m_CustomerCards.Add(new CustomerCard(i_OwnerName, i_OwnerPhone));
        }

        //electric car
        public string AddElectricCar(string i_CustomerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy, string i_CarColor, string i_NumOfDoors)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int intNumOfDoors = int.Parse(i_NumOfDoors);

            // Corrected the Enum.IsDefined check.
            if (!System.Enum.IsDefined(typeof(eCarColor), i_CarColor) || currentEnergy < 0 || currentEnergy > 5.2 || intNumOfDoors < 2 || intNumOfDoors > 5)
            {
                throw new ArgumentException("Invalid input.");
            }

            if (!IsCustomerExist(i_CustomerName))
            {
                AddCustomer(i_CustomerName, i_OwnerPhone);
            }
            foreach(CustomerCard customerCard in m_CustomerCards)
            {
                if(customerCard.OwnerName == i_CustomerName)
                {
                    // Parse the enum value
                    if (Enum.TryParse<eCarColor>(i_CarColor, true, out eCarColor CarColor) && Enum.TryParse<eNumOfDoors>(i_NumOfDoors, true, out eNumOfDoors numOfDoors))
                    {
                        customerCard.VehicleList.Add(new Car(i_ModelName, i_LicenseNumber, currentEnergy, 5.2f, CarColor, numOfDoors));
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid car color value: {i_CarColor}");
                    }
                }
            }
            return "Added new electric car to customer card successfully.";
        }

        //fule car
        public string AddFuleCar(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy, string i_CarColor, string i_NumOfDoors)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int intNumOfDoors = int.Parse(i_NumOfDoors);
            if (!(System.Enum.IsDefined(typeof(eCarColor), i_CarColor) || currentEnergy < 0 || currentEnergy > 44 || intNumOfDoors < 2 || intNumOfDoors > 5))
            {
                throw new ArgumentException("Invalid input.");
            }
            if (!IsCustomerExist(i_OwnerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone);
            }
            foreach (CustomerCard customerCard in m_CustomerCards)
            {
                 if (Enum.TryParse<eCarColor>(i_CarColor, true, out eCarColor CarColor) && Enum.TryParse<eNumOfDoors>(i_NumOfDoors, true, out eNumOfDoors numOfDoors))
                 {
                    if (customerCard.OwnerName == i_OwnerName)
                    { 
                        customerCard.VehicleList.Add(new Car(i_ModelName, i_LicenseNumber, currentEnergy, 44, eFuelType.Octan95, CarColor, numOfDoors));
                    }
                 }
                 else
                 {
                     throw new ArgumentException($"Invalid input");
                 }
            }
            return "Added new fule car to customer card sucssesfuly.";
        }

        //electric motorcycle
        public string AddEclectricMotorcycle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy,
            string i_LicenseType, string i_EngineCapacityInCubicCentimeter)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int engineCpacity = int.Parse(i_EngineCapacityInCubicCentimeter);
            if (!(System.Enum.IsDefined(typeof(eLicenseType), i_LicenseType) || currentEnergy < 0 || currentEnergy > 2.4 || engineCpacity < 0))
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
                    if(Enum.TryParse<eLicenseType>(i_LicenseType, true, out eLicenseType LicenseType))
                    {
                        customerCard.VehicleList.Add(new Motorcycle(i_ModelName, i_LicenseNumber, currentEnergy, 2.4f,
                        LicenseType, engineCpacity));
                    }
                    else
                    {
                        throw new FormatException("Invalid input");
                    }
                    
                }
            }
            return "Added new electric motorcycle to customer card sucssesfuly.";
        }


        //// NEED TO ADD IN UI i_EngineCapacityInCubicCentimeter!



        //fule motorcycle
        public string AddFuleMotorcycle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy,string i_MotorcyclFuelType,
            string i_LicenseType, string i_EngineCapacityInCubicCentimeter)
        {
            float currentEnergy = float.Parse(i_CurrentEnergy);
            int engineCpacity = int.Parse(i_EngineCapacityInCubicCentimeter);
            if (!(System.Enum.IsDefined(typeof(eLicenseType), i_LicenseType) || !(System.Enum.IsDefined(typeof(eFuelType), i_MotorcyclFuelType)) || currentEnergy < 0 || currentEnergy > 6.3 || engineCpacity < 0))
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
                    if(Enum.TryParse<eLicenseType>(i_LicenseType, true, out eLicenseType LicenseType))
                    {
                        customerCard.VehicleList.Add(new Motorcycle(i_ModelName, i_LicenseNumber, currentEnergy, 6.2f, eFuelType.Octan98,
                        LicenseType, engineCpacity));
                    }
                   
                }
                
            }
            return "Added new fule motorcycle to customer card sucssesfuly.";

        }

        
        //fule truck
        public string AddTruck(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, string i_CurrentEnergy, string i_RefrigeratedTruck, string i_CargoVolume)
        {

            float currentEnergy = float.Parse(i_CurrentEnergy);
            bool refrigeratedTruck = bool.Parse(i_RefrigeratedTruck);
            int cargoVolume = int.Parse(i_CargoVolume);
            if (currentEnergy < 0 || currentEnergy > 130 || cargoVolume < 0)
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

        public bool IsCustomerExist(string i_costomerName)
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

        public string LicenceNumberOfVehiclesInGarage(string CurrentStatus)
        {
            string LicenceNumberOfVehiclesInGarage = "";

            if (!Enum.TryParse<eCurrentCarStatus>(CurrentStatus, true, out eCurrentCarStatus parsedStatus))
            {
                throw new ArgumentException("Invalid input");
            }

            foreach (CustomerCard CustomerCard in m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                {
                    if (CustomerVehicle.CurrentStatus == parsedStatus)
                    {
                        LicenceNumberOfVehiclesInGarage += (CustomerVehicle.LicenseNumber + "\n");
                    }
                }
            }
            return LicenceNumberOfVehiclesInGarage;
        }


        public string LicenceNumberOfVehiclesInGarage()
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

        public void ChangeStateOfVehicle(string i_LicenceNumber, string i_NewState)
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

        public void PumpToMaximumAir(string i_LicenceNumber)
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


        public void AddFuel(string i_LicenceNumber, string i_FuelType, string i_FuelToAdd)
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
                                    ((FuelEngine)CustomerVehicle.Engine).AddFuel(fuelToAdd, i_FuelType);
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

        public void ChargeEngine(string i_LicenceNumber, string i_HoursToCharge)
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

        public string VehiclesInformation(string i_LicenceNumber)
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

        private bool IsVehicleInGarage(string licenseNumber)
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