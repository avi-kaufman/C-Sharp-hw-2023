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
        Dictionary<string, Vehicle> m_VehicleInGarage = new Dictionary<string, Vehicle>();

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
                    throw new ArgumentException("Sorry, We cant add fuel to your electric car under this lisence: {0}"
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
                    throw new ArgumentException("Sorry, We cant charge the engine of your unelectrical car under this lisence: {0}"
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

