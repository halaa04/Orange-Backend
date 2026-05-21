namespace CompanySystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // One department has many employees
        public ICollection<Employee> Employees { get; set; }
    }
}