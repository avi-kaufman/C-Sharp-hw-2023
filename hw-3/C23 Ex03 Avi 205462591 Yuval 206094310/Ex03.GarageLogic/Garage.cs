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
        public string AddNewVehiclForGarageCare(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhone, Vehicle i_NewVehicle)
        {
            foreach (CustomerCard CustomerCard in this.m_CustomerCards)
            {
                for(int i = 0; i < CustomerCard.VehicleList.Count; i++)
                {
                    if (CustomerCard.VehicleList[i].LicenseNumber  == i_LicenceNumber)
                    {
                        CustomerCard.VehicleList[i].CurrentStatus = Vehicle.eCurrentVehicleStatus.NotFixedYet;
                        return string.Format("There is already a vehicle in the garage under this lisence: {0}, and it's not fixed yet", i_LicenceNumber);                
                    }
                }
            }
            // how to take the params for new car from user?
            this.m_CustomerCards.Add(new CustomerCard(i_OwnerName, i_OwnerPhone, i_NewVehicle));
        }

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
            if (!IsVehicleInGarage(i_LicenceNumber))
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
                    foreach()
                    if (vehicle.LicenseNumber == licenseNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

