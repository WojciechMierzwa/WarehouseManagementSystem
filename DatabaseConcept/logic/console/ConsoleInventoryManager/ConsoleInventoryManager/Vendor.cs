internal class Vendor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Mail { get; set; }
    public string? Nip { get; set; }

    public Vendor(int id, string name, string? phoneNumber, string? mail, string? nip)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Mail = mail;
        Nip = nip;
    }

    public override string ToString()
    {
        return $"Vendor ID: {Id}\nName: {Name}\nPhone: {PhoneNumber}\nEmail: {Mail}\nNIP: {Nip}";
    }
}