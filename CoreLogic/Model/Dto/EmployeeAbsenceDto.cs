namespace Core.Model.Dto
{
    /// <summary>
    /// The employee and absece, object to return
    /// </summary>
    public class EmployeeAbsenceDto
    {
        /// <summary>
        /// Employee
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// Count of absence occurance for that employee
        /// </summary>
        public int AbsenceCount { get; set; }
    }
}
