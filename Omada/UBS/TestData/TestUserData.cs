using DataGenerator;
using DataGenerator.Sources;

namespace UBS.TestData
{
    public class TestUserData
    {
        public bool Mr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }

    public class GenerateData
    {
        public TestUserData UserData { get; set; }

        public GenerateData()
        {
            UserData = Generator.Default.Single<TestUserData>(
                e =>
                {
                    e.Property(p => p.Mr).Value(true);
                    e.Property(p => p.FirstName).DataSource<FirstNameSource>();
                    e.Property(p => p.LastName).DataSource<LastNameSource>();
                    e.Property(p => p.Address).DataSource<StreetSource>();
                    e.Property(p => p.City).DataSource<CitySource>();
                    e.Property(p => p.PostalCode).DataSource<PostalCodeSource>();
                    e.Property(p => p.Email).DataSource<EmailSource>();
                    e.Property(p => p.Phone).DataSource<PhoneSource>();
                    e.Property(p => p.Note).DataSource<LoremIpsumSource>();
                });
        }
    }
}
