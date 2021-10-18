using CoreLogic.Model.Objects.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess.Concrete
{
    /// <summary>
    /// Data seeder
    /// Save data to DB from the csv files
    /// </summary>
    public static class EFDBSeeder
    {
        /// <summary>
        /// Seed data from the csv files (provided by the Empactis)
        /// </summary>
        /// <param name="context"></param>
        public static void SeedData( this EFDBContext context ) 
        {
            // Get data from the employees csv
            string employeesFile = $"{AppContext.BaseDirectory}Resources\\Employees.csv";
            List<Employee> allEmployees = File.ReadAllLines( employeesFile )
                                          .Skip( 1 )
                                          .Select( v => Employee.FromCsv( v ) )
                                          .ToList();

            // Get data from the absences csv
            string absencesFile = $"{AppContext.BaseDirectory}Resources\\Absences.csv";
            List<Absence> allAbsences = File.ReadAllLines( absencesFile )
                                       .Skip( 1 )
                                       .Select( v => Absence.FromCsv( v, allEmployees ) )
                                       .ToList();

            // Add to DB
            context.Employees.AddRange( allEmployees );
            context.Absences.AddRange( allAbsences );

            // Persist the DB
            context.SaveChanges();
        }
    }
}
