using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CoreLogic.Model.Objects.Entities
{
    /// <summary>
    /// The absence entity
    /// </summary>
    [Table( "absences" ) ]
    public class Absence
    {
        /// <summary>
        /// The identifier
        /// </summary>
        [Key]
        [Column( "id" )]
        public int Id{ get; set; }

        /// <summary>
        /// The employee
        /// </summary>
        [ForeignKey( "employee_id" )]
        public Employee Employee { get; set; }
        // public int EmployeeId { get; set; }

        /// <summary>
        /// Start of the absence
        /// </summary>
        [Column( "start" )]
        public DateTime Start { get; set; }

        /// <summary>
        /// End of the absence
        /// </summary>
        [Column( "end" )]
        public DateTime End { get; set; }

        /// <summary>
        /// Type of the absence
        /// </summary>
        [Column( "type" )]
        public AbsenceType Type { get; set; }

        public static Absence FromCsv( string csvLine, List<Employee> employees )
        {
            string[] values = csvLine.Split( ',' );
            var absenceValues = new Absence();
            absenceValues.Id = int.Parse( values[0] );
            absenceValues.Start = DateTime.Parse( values[1] );
            absenceValues.End = DateTime.Parse( values[2] );
            AbsenceType type;
            AbsenceType.TryParse( values[3], out type );
            absenceValues.Type = type;
            // absenceValues.EmployeeId = int.Parse(values[4]);
            absenceValues.Employee = employees.Where( x => x.Id == int.Parse( values[4] ) ).FirstOrDefault();
            return absenceValues;
        }
    }

    /// <summary>
    /// Absence Type
    /// Note: I assumed that this is some type of the absence
    /// </summary>
    public enum AbsenceType
    {
        AbsenceType1 = 1,
        AbsenceType2 = 2,
    }
}
