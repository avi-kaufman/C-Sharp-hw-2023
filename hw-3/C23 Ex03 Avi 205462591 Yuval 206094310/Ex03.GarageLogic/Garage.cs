using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///To-do-List:
/// Fix the old code to m_CustomerCards in all functions 
/// Implement AddVhicle
/// check EXCEPTIONs 





namespace Ex03.GarageLogic
{

    //need to fix FormatException
    public class Garage
    {
        private List<CustomerCard> m_CustomerCards;

        public Garage() 
        {
            m_CustomerCards = new List<CustomerCard>();
        }
        //need to imlement 3 cases and split garage to 2 classes ofice and sadna
        //  מקרה ראשון הלקוח קיים במערכת והרכב מטופל כעת במוסךV
        //מקרה שני הלקוח קיים במערכת הרכב גם קיים במערכת במצב תוקן, צריך להעביר למצב תיקוןV
        // מקרה שלישי הלקוח קיים במערכת עם רכבים אחרים ואין את הרכב הנוכחי במערכת
        // מקרה רביעי הלקוח אינו במערכת וצריך לפתוח כרטיס חבר חדש ולהכניס אליו את הרכב
        //מקרה חמישי הרכב קיים במערכת ויושב על כרטיס לקוח של בן אדם אחר  

        public string AddVehicle(string i_LicenseNumber, string i_CustomerName)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                foreach (Vehicle vehicle in customerCard.VehicleList)
                {
                    if (vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        if (customerCard.OwnerName == i_CustomerName)
                        {
                            if (vehicle.CurrentStatus == eCurrentCarStatus.NotFixedYet)
                            {
                                return "The vehicle is in the garage and it is currently in line to be fixed.";
                            }
                            else
                            {
                                vehicle.CurrentStatus = eCurrentCarStatus.NotFixedYet;
                                return "The vehicle has been added to the line of vehicles to be fixed.";
                            }
                        }
                        else
                        {
                            return "This vehicle is associated with another customer.";
                        }
                    }
                }

                // This vehicle isn't in this customer's list, but the customer exists (Scenario 3)
                if (customerCard.OwnerName == i_CustomerName)
                {
                    // You would need to add logic here to add the vehicle to this customer's list.
                    // Since it doesn't communicate directly, you should return an appropriate message.
                    return "The customer exists but the vehicle isn't in the system. Please provide the relevant vehicle details.";
                }
            }

            // Scenario 4: Neither the customer nor the vehicle exists.
            return "The customer and vehicle aren't in the garage. Please provide all the relevant details.";
        }

        public string AddCustomerToCustomerCards(string i_OwnerName, string i_OwnerPhone)
        {
            this.m_CustomerCards.Add(new CustomerCard(string i_OwnerName, string i_OwnerPhone))
            return "Added new Customer sucssesfuly."
        }

        //electric car
        public string AddNewVehicleToCustomerCard(string i_CustomerName, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if(customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Car(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_EngineCapcity, i_CarColor, i_NumOfDoors))
                    return "Added new electric car to customer card sucssesfuly."
                }
            }
        }
        //fule car
        public string AddNewVehicleToCustomerCard(string i_OwnerName, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if (customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Car(i_ModelName, i_LicenseNumber, i_CurrentEnergy, 44, Octan95, i_CarColor, i_NumOfDoors))
                    return "Added new fule car to customer card sucssesfuly."
                }
            }
        }

        //electric motorcycle
        public string AddNewVehicleToCustomerCard(string i_OwnerName, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy,
            eLicenseType i_LicenseType, int i_EngineCapacityInCubicCentimeter)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if (customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Motorcycle(i_OwnerName, i_ModelName, i_LicenseNumber, i_CurrentEnergy, 2.4,
                    i_LicenseType, i_EngineCapacityInCubicCentimeter))
                    return "Added new electric motorcycle to customer card sucssesfuly."
                }
            }
        }

        //fule motorcycle
        public string AddNewVehicleToCustomerCard(string i_OwnerName, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity,
            eLicenseType i_LicenseType, int i_EngineCapacityInCubicCentimeter)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if (customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Motorcycle(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_EngineCapcity, Octan98,
                    i_LicenseType, i_EngineCapacityInCubicCentimeter))
                    return "Added new fule motorcycle to customer card sucssesfuly."
                }
            }
        }

        //fule truck
        public string AddNewVehicleToCustomerCard(string i_OwnerName, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, eFuelType i_FuelType, bool i_RefrigeratedTruck, float i_CargoVolume)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if (customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Truck(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, eFuelType i_FuelType, bool i_RefrigeratedTruck, float i_CargoVolume))
                    return "Added new fule truck to customer card sucssesfuly."
                }
            }
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string LicenceNumberOfVehiclesInGarage(eCurrentCarStatus CurrentStatus)
        {
            string LicenceNumberOfVehiclesInGarage = "";

            foreach (CustomerCard CustomerCard in this.m_CustomerCards)
            {
                foreach(Vehicle CustomerVehicle in CustomerCard.VehicleList)
                {
                    if(CustomerVehicle.CurrentStatus == CurrentStatus)
                    {
                        LicenceNumberOfVehiclesInGarage += (CustomerVehicle.LicenseNumber + "\n")
                    }
                }
            }
            return LicenceNumberOfVehiclesInGarage;
        }

        public string LicenceNumberOfVehiclesInGarage()
        {
            string LicenceNumberOfVehiclesInGarage = "";

            foreach (CustomerCard CustomerCard in this.m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                {
                    LicenceNumberOfVehiclesInGarage += (CustomerVehicle.LicenseNumber + \n)  
                }
            }
            return LicenceNumberOfVehiclesInGarage;
        }

        public void ChangeStateOfVehicle(string i_LicenceNumber, string i_NewState)
        {
            bool flag = false;
            try
            {
                foreach (CustomerCard CustomerCard in this.m_CustomerCards)
                {
                    foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                    {
                        if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                        {
                            CustomerVehicle.CurrentStatus = i_NewState;
                            flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    throw new ArgumentException($"Sorry. There is no vehicle in the garage under this lisence: {i_LicenceNumber}");
                }
            }
            catch (Exception e)
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
                foreach (CustomerCard CustomerCard in this.m_CustomerCards)
                {
                    foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                    {
                        if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                        {
                            foreach (Wheels wheel in CustomerVehicle.Wheels)
                            {
                                wheel.PumpToMax();
                            }
                        }
                    }
                }
            }
        }


        ///need to correct the code to m_CustomerCards format  
        public void AddFuel(string i_LicenceNumber, string i_FuelType, string i_FuelToAdd)
        {
            if (!this.IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, We can't add fuel. There is no vehicle in the garage with the license number: {i_LicenceNumber}");
            }
            else
            {
                if (m_VehicleInGarage[i_LicenceNumber] is ElectricEngine)
                {
                    throw new ArgumentException($"Sorry, We can't add fuel to your electric car with license number: {i_LicenceNumber}");
                }
                else
                {
                    try
                    {
                        float fuelToAdd = float.Parse(i_FuelToAdd);
                        m_VehicleInGarage[i_LicenceNumber].FuelEngine.AddFuel(fuelToAdd, i_FuelType);
                    }
                    catch (FormatException)
                    {
                        throw new ArgumentException($"Invalid fuel amount provided: {i_FuelToAdd}");
                    }
                }
            }
        }

        ///need to correct the code to m_CustomerCards format  
        public void ChargeEngine(string i_LicenceNumber, string i_HoursToCharge)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, there is no vehicle in the garage with the license number: {i_LicenceNumber}");
            }

            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                foreach (Vehicle vehicle in customerCard.VehicleList)
                {
                    if (vehicle.Engine is ElectricEngine)
                    {
                        try
                        {
                            float hoursToCharge = float.Parse(i_HoursToCharge);
                            m_VehicleInGarage[i_LicenceNumber].ElectricEngine.ChargeEngine(hoursToCharge);
                        }
                        catch (FormatException)
                        {
                            throw new ArgumentException($"Invalid value for hours to charge: {i_HoursToCharge}");
                        }
                    }
                }

            }
            else
            {
                throw new ArgumentException($"Sorry, the vehicle with license number: {i_LicenceNumber} is not electric and cannot be charged.");
            }
        }

        public string VehiclesInformation(string i_LicenceNumber)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, there is no car in the garage under this lisence : {i_LicenceNumber}";
            }
            else
            {
                foreach(CustomerCard customerCard in this.m_CustomerCards)
                {
                    foreach(Vehicle vehicle in customerCard.VehicleList)
                    {
                        if(vehicle.LicenseNumber == i_LicenceNumber)
                        {
                            return vehicle.ToString();
                        }
                    }
                }
            }
        }

        private bool IsVehicleInGarage(string licenseNumber)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                foreach (Vehicle vehicle in customerCard.VehicleList)
                {
                    if (vehicle.LicenseNumber == licenseNumber)
                    {
                        return true;
                        break;
                    }
                }
            }
            return false;
        }
    }
}

