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

        public bool AddVehicle(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber)
            { 
                return false;
            }
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                foreach (Vehicle vehicle in customerCard.VehicleList)
                {
                    if (vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        vehicle.CurrentStatus = eCurrentCarStatus.NotFixedYet;  
                        return true;
                    }
                }
            }
        }

        public void AddCustomer(string i_OwnerName, string i_OwnerPhone)
        {
            this.m_CustomerCards.Add(new CustomerCard(string i_OwnerName, string i_OwnerPhone))
          
        }

        //electric car
        public string AddVehicle(string i_CustomerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        {
            if (!IsCustomerExist(i_costomerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone)
            }
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if(customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Car(i_ModelName, i_LicenseNumber, i_CurrentEnergy, 5.2, i_CarColor, i_NumOfDoors))
                    return "Added new electric car to customer card sucssesfuly."
                }
            }
        }
        //fule car
        public string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
        {
            if (!IsCustomerExist(i_costomerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone)
            }
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
        public string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy,
            eLicenseType i_LicenseType, int i_EngineCapacityInCubicCentimeter)
        {
            if (!IsCustomerExist(i_costomerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone)
            }
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
        public string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy,
            eLicenseType i_LicenseType, int i_EngineCapacityInCubicCentimeter)
        {
            if (!IsCustomerExist(i_costomerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone)
            }
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if (customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Motorcycle(i_ModelName, i_LicenseNumber, i_CurrentEnergy, 6.2, Octan98,
                    i_LicenseType, i_EngineCapacityInCubicCentimeter))
                    return "Added new fule motorcycle to customer card sucssesfuly."
                }
            }
        }

        //fule truck
        public string AddVehicle(string i_OwnerName, string i_OwnerPhone, string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, bool i_RefrigeratedTruck, float i_CargoVolume)
        {
            if (!IsCustomerExist(i_costomerName))
            {
                AddCustomer(i_OwnerName, i_OwnerPhone)
            }
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                if (customerCard.OwnerName == i_CustomerName)
                {
                    customerCard.VehicleList.Add(new Truck(i_ModelName, i_LicenseNumber, i_CurrentEnergy, 130, Soler, i_RefrigeratedTruck, i_CargoVolume))
                    return "Added new fule truck to customer card sucssesfuly."
                }
            }
        }

        public bool IsCustomerExist(string i_costomerName)
        {
            foreach(CustomerCard CustomerCard in this.m_CustomerCards)
            {
                if (i_costomerName == CustomerCard.OwnerName)
                {
                    return true;
                }
            }
            return false;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string LicenceNumberOfVehiclesInGarage(eCurrentCarStatus CurrentStatus)
        {
            string LicenceNumberOfVehiclesInGarage = "";

            foreach (CustomerCard CustomerCard in this.m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                {
                    if (CustomerVehicle.CurrentStatus == CurrentStatus)
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
                    LicenceNumberOfVehiclesInGarage += (CustomerVehicle.LicenseNumber + "\n")
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
                foreach (CustomerCard CustomerCard in this.m_CustomerCards)
                {
                    foreach (Vehicle CustomerVehicle in CustomerCard.VehicleList)
                    {
                        if (CustomerVehicle.LicenseNumber == i_LicenceNumber)
                        {
                            CustomerVehicle.CurrentStatus = i_NewState;
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
                foreach (CustomerCard CustomerCard in this.m_CustomerCards)
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
            if (!this.IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, We can't add fuel. There is no vehicle in the garage with the license number: {i_LicenceNumber}");
            }
            else
            {
                foreach (CustomerCard CustomerCard in this.m_CustomerCards)
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

        public void ChargeEngine(string i_LicenceNumber, string i_HoursToCharge)
        {
            if (!IsVehicleInGarage(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, there is no vehicle in the garage with the license number: {i_LicenceNumber}");
            }

            foreach (CustomerCard customerCard in this.m_CustomerCards)
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
                foreach (CustomerCard customerCard in this.m_CustomerCards)
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
        }

        private bool IsVehicleInGarage(string licenseNumber)
        {
            foreach (CustomerCard customerCard in this.m_CustomerCards)
            {
                foreach (Vehicle CustomerVehicle in customerCard.VehicleList)
                {
                    if (CustomerVehicle.LicenseNumber == licenseNumber)
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
