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

        public CustomerCard(string i_OwnerName, string i_OwnerPhone)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
            this.m_VehicleList = new List<Vehicle>(1);
        }

        public string OwnerName
        {
            get { return m_OwnerName; } 
            set { m_OwnerName = value; }
        }

        public string OwnerPhone
        {
            get { return this.m_OwnerPhone; }
            set { m_OwnerPhone = value; }
        }

        public List<Vehicle> VehicleList
        {
            get { return m_VehicleList; }
            set { m_VehicleList = value; }
        }

        public override string ToString()
        {
            string VehicleListToString = "";
            for (int i = 0; i < this.m_VehicleList.Count; i++)
            {
                VehicleListToString = string.Format("{0}Vehicle {1}: {2}\n", VehicleListToString, i + 1, m_VehicleList[i]);
            }

            return string.Format("Owner Name: {0}\nOwner Phone: {1}\nOwner Vehicles: {2}", this.m_OwnerName, this.m_OwnerPhone, VehicleListToString);
        }
    }

}
