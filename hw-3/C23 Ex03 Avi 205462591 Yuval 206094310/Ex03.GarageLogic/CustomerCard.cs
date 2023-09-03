using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class CustomerCard
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private List<Vehicle> m_VehicleList;

        public CustomerCard(string i_OwnerName, string i_OwnerPhone, Vehicle i_NewVehicle)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
            this.m_VehicleList = new List<Vehicle>(1);
            AddVehicleToCustomerCard(i_NewVehicle);
        }


        //Add Vehicle method!



        ///need to do it in polimorfizem for car motorcycle etc...
        public void AddVehicleToCustomerCard(Vehicle i_Vehicle)
        {
            this.m_VehicleList.Add(i_Vehicle);
        }

        public override string ToString()
        {
            string VehicleListToString = "";
            foreach (int i = 0; i < this.m_VehicleList.Count; int++)
            {
                VehicleListToString += "Vehicle " i + ": " + m_VehicleList[i].ToString() + "\n";
            }
            return string.Format("Owner Name: {0}\nOwner Phone: {1}\nOwner Vehicles: {3}", this.m_OwnerName, this.m_OwnerPhone, VehicleListToString);
        }
    }

}
