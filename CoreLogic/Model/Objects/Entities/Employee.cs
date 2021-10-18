using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLogic.Model.Objects.Entities
{
    /// <summary>
    /// Employee entity
    /// </summary>
    [Table( "employees" )]
    public class Employee
    {
        /// <summary>
        /// The identifier
        /// </summary>
        [Key]
        [Column( "id" )]
        public int Id { get; set; }

        /// <summary>
        /// Employee Number
        /// </summary>
        [Column("employee_number")]
        public int EmployeeNumber { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Department of the Employee
        /// </summary>
        [Column("department")]
        public string Department { get; set; }

        public static Employee FromCsv( string csvLine )
        {
            string[] values = csvLine.Split( ',' );
            var employeeValues = new Employee();
            employeeValues.Id = int.Parse( values[0] );
            employeeValues.EmployeeNumber = int.Parse( values[1] );
            employeeValues.Name = values[2];
            employeeValues.Department = values[3];

            return employeeValues;
        }
    }
}
