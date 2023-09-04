using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    //need to fix FormatException
    public class Garage
    {
        private List<CustomerCard> m_CustomerCards;

        public Garage() 
        {
            m_CustomerCards = new List<CustomerCard>();
            m_CustomerCards = new List<CustomerCard>();
        }
        //need to imlement 3 cases and split garage to 2 classes ofice and sadna
        public string AddNewVehiclForGarageCare(string i_LicenceNumber)
        {
            foreach (CustomerCard CustomerCard in this.m_CustomerCards)
            {
                for(int i = 0; i < CustomerCard.VehicleList.Count; i++)
                {
                    if (CustomerCard.VehicleList[i].LicenseNumber  == i_LicenceNumber)
                    {
                        CustomerCard.VehicleList[i].CurrentStatus = VehicleStatus.NotFixedYet;
                        return "The vehicle has been entered successfully";
                            
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
        ///need to correct the syntax 
        public void PumpToMaximumAir(string i_LicenceNumber)
        {
            if (!m_VehicleInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("Sorry, We cant pump air. There is no vehicle in the garage under this lisence: {0}"
                    , i_LicenceNumber);
            }
            else
            {
                foreach (Wheels wheel in m_VehicleInGarage[i_LicenceNumber].Wheels)
                {
                    wheel.PumpToMax();
                }
            }
        }
        ///need to correct the syntax 
        public void AddFuel(string i_LicenceNumber, string i_FuelType, string i_FuelToAdd)
        {
            if (!m_VehicleInGarage.ContainsKey(i_LicenceNumber))
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

        ///need to correct the syntax 
        public void ChargeEngine(string i_LicenceNumber, string i_HoursToCharge)
        {
            if (!m_VehicleInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException($"Sorry, there is no vehicle in the garage with the license number: {i_LicenceNumber}");
            }

            if (m_VehicleInGarage[i_LicenceNumber] is ElectricEngine)
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
            else
            {
                throw new ArgumentException($"Sorry, the vehicle with license number: {i_LicenceNumber} is not electric and cannot be charged.");
            }
        }

        ///need to correct the syntax 
        public string VehiclesInformation(string i_LicenceNumber)
        {
            if (!m_VehicleInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("Sorry, there is no car in the garage under this lisence : {0}"
                    , i_LicenceNumber);
            }
            else
            {
                return [i_LicenceNumber].CustomerCard.ToString(); // need to find the car 
            }
        }
    }
}

