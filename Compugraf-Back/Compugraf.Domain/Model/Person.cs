namespace Compugraf.Domain.Model
{
    public class Person
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Nationality { get; private set; }
        public string CPF { get; private set; }
        public string ZipCode { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
