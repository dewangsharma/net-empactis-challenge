using CoreLogic.Model.Objects.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    /// <summary>
    /// EF implmentation for DBContext
    /// </summary>
    public class EFDBContext : DbContext
    {
        #region Fields
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Absence> Absences { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public EFDBContext( DbContextOptions<EFDBContext> options )
                : base( options )
        { }
        #endregion
    }
}
