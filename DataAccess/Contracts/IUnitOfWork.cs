namespace DataAccess.Contracts
{
    /// <summary>
    /// The persistance unit of work interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Employee Repository
        /// </summary>
        IEmployeeRepository EmployeeRepository { get; }

        /// <summary>
        /// Absence Repository
        /// </summary>
        IAbsenceRepository AbsenceRepository { get; }
    }
}
