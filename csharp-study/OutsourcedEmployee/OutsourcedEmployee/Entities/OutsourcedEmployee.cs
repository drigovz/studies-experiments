namespace OutsourcedEmployeeExemple.Entities
{
    class OutsourcedEmployee : Employee
    {
        public double AditionalCharge { get; set; }

        public OutsourcedEmployee()
        {
        }

        public OutsourcedEmployee(string name, int hours, double valuePerHour, double aditionalCharge) : base(name, hours, valuePerHour)
        {
            AditionalCharge = aditionalCharge;
        }

        public override double Payment()
        {
            return (AditionalCharge * (110.0 / 100.0)) + base.Payment();
        }
    }
}
