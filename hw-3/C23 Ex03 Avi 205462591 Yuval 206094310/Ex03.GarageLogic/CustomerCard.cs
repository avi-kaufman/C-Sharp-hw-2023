using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class CustomerCard
    {
        enum eCurrentCarStatus
        {
            NotFixedYet,
            Fixed,
            Paid,
        }
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eCurrentCarStatus m_CurrentCarStatus;
        private List<Vehicle> m_VehicleList;

        public CustomerCard(string i_OwnerName, string i_OwnerPhone, Vehicle i_NewVehicle)
        {
            this.m_OwnerName = i_OwnerName; 
            this.m_OwnerPhone = i_OwnerPhone;
            this.m_CurrentCarStatus = eCurrentCarStatus.NotFixedYet;
            this.m_VehicleList = new List<Vehicle>(1);
            this.m_VehicleList.Add(i_NewVehicle);
        }
        /// <summary>
        /// /////////////////
        /// </summary>
        /// <returns></returns>
        /// 
        public void AddVehicleToCustomerCard(Vehicle i_Vehicle)
        {
            this.m_VehicleList.Add(i_Vehicle);
        }
        public override string ToString()
        {
            return string.Format(,this.m_OwnerName, this.m_OwnerPhone, this.m_CurrentCarStatus.ToString(), this.m_VehicleList.ToString());
        }
        public override bool Equals(Object i_Obj)
        {
            return false;
        }
    }
    
}
