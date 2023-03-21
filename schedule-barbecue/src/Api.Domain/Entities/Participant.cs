using System;

namespace Api.Domain.Entities
{
    public class Participant : BaseEntity
    {
        public string Name { get; private set; }

        public decimal ContribuitionValue { get; private set; }

        public Barbecue Barbecue { get; set; }

        public int BarbecueId { get; set; }

        private decimal _sugestedValue;

        public decimal SugestedValue
        {
            get => _sugestedValue;
            set => _sugestedValue = value > 0 ? value : 0;
        }

        private decimal _sugestedValueWithDink;

        public decimal SugestedValueWithDink
        {
            get => _sugestedValueWithDink;
            set => _sugestedValueWithDink = value > 0 ? value : 0;
        }

        private Participant()
        {
        }

        public Participant(string name, decimal contribuitionValue, decimal sugestedValue, decimal sugestedValueWithDink)
        {
            Validations(name, contribuitionValue);

            Name = name;
            ContribuitionValue = contribuitionValue;
            SugestedValue = sugestedValue;
            SugestedValueWithDink = sugestedValueWithDink;
        }

        private void Validations(string name, decimal contribuitionValue)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name is required!");

            if (contribuitionValue <= 0)
                throw new ArgumentException("Contribuition value not valid!");
        }
    }
}
