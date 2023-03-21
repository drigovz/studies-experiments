using Api.Domain.Entities;
using Bogus;

namespace Api.Test.Builders
{
    public class ParticipantBuilder
    {
        static Faker faker = new Faker();

        public string Name = faker.Person.FullName;
        public decimal ContribuitionValue = faker.Finance.Amount(10, 40);
        public decimal SugestedValue = faker.Finance.Amount(0, 20);
        public decimal SugestedValueWithDink = faker.Finance.Amount(0, 60);

        public static ParticipantBuilder New()
        {
            return new ParticipantBuilder();
        }

        public ParticipantBuilder ParticipantWithName(string name)
        {
            Name = name;
            return this;
        }

        public ParticipantBuilder ParticipantWithContribuitionValue(decimal contribuitionValue)
        {
            ContribuitionValue = contribuitionValue;
            return this;
        }

        public ParticipantBuilder ParticipantWithSugestedValue(decimal sugestedValue)
        {
            SugestedValue = sugestedValue;
            return this;
        }

        public ParticipantBuilder ParticipantWithSugestedValueWithDink(decimal sugestedValueWithDink)
        {
            SugestedValueWithDink = sugestedValueWithDink;
            return this;
        }

        public Participant Build()
        {
            return new Participant(Name, ContribuitionValue, SugestedValue, SugestedValueWithDink);
        }
    }
}
