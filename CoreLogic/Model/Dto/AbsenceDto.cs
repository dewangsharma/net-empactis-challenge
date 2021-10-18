using CoreLogic.Model.Objects.Entities;
using System;

namespace Core.Model.Dto
{
    public class AbsenceDto
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The employee
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// Start of the absence
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End of the absence
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Type of the absence
        /// </summary>
        public AbsenceType Type { get; set; }
    }
}
