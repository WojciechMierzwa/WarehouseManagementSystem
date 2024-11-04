namespace ConsoleInventoryManagerV2
{
    internal class Order
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        public Order(int id, int status, DateTime date, int customerId, int employeeId)
        {
            Id = id;
            Status = status;
            Date = date;
            CustomerId = customerId;
            EmployeeId = employeeId;
        }
    }
}
