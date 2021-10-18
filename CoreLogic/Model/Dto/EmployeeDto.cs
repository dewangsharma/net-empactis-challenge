namespace Core.Model.Dto
{
    public class EmployeeDto
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Employee Number
        /// </summary>
        public int EmployeeNumber { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Department of the Employee
        /// </summary>
        public string Department { get; set; }
    }
}
