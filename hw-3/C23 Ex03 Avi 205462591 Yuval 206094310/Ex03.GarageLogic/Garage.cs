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
        }

        public string AddNewVehiclForGarageCare(string i_LicenceNumber)
        {
            foreach (CustomerCard CustomerCard in this.m_CustomerCards)
            {
                for(int i = 0; i < CustomerCard.VehicleList.Count; i++)
                {
                    if (CustomerCard.VehicleList[i].LicenseNumber  == i_LicenceNumber)
                    {
                        CustomerCard.VehicleList[i].CurrentStatus = NotFixedYet;
                        return "The vehicle has been entered successfully"
                            
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
                        LicenceNumberOfVehiclesInGarage += (CustomerVehicle.LicenseNumber + \n)
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

        public void AddFuel(string i_LicenceNumber, string i_FuelType, string i_FuelToAdd)
        {
            if (!m_VehicleInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("Sorry, We cant add fuel. There is no vehicle in the garage under this lisence: {0}"
                    , i_LicenceNumber);
            }
            else
            {
                if (m_VehicleInGarage[i_LicenceNumber] is ElectricEngine)
                {
                    throw new FormatException("Sorry, We cant add fuel to your electric car under this lisence: {0}"
                        , i_LicenceNumber);
                }
                else
                {
                    m_VehicleInGarage[i_LicenceNumber].FuelEngine.AddFuel(float.Parse(i_FuelToAdd), i_FuelType);

                }
            }
        }

        public void ChargeEngine(string i_LicenceNumber, string i_HoursToCharge)
        {
            if (!m_VehicleInGarage.ContainsKey(i_LicenceNumber))
            {
                throw new ArgumentException("Sorry, We cant add fuel. There is no vehicle under this lisence in the garage: {0}"
                    , i_LicenceNumber);
            }
            else
            {
                if (m_VehicleInGarage[i_LicenceNumber] is ElectricEngine)
                {
                    m_VehicleInGarage[i_LicenceNumber].ElectricEngine.ChargeEngine(int.Parse(i_HoursToCharge)); //maybe use 'as'?
                }
                else
                {
                    throw new FormatException("Sorry, We cant charge the engine of your unelectrical car under this lisence: {0}"
                        , i_LicenceNumber);
                }
            }
        }

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

