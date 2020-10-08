using System;

namespace CLI_Worker_Composicao.Entities
{
    class HourContract
    {
        public DateTime DateContract { get; set; }

        public double ValuePerHour { get; set; }

        public int HoursContract { get; set; }

        public HourContract()
        {

        }

        public HourContract(double valuePerHour, int hoursContract, DateTime dateContract)
        {
            this.ValuePerHour = valuePerHour;
            this.HoursContract = hoursContract;
            this.DateContract = dateContract;
        }

        public double TotalValue()
        {
            return (ValuePerHour * HoursContract);
        }
    }
}
