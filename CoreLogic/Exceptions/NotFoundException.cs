using System;

namespace Core.Exceptions
{
    /// <summary>
    /// Responds to the client with exception if an item cannot be found
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// Default empty constructor
        /// </summary>
        public NotFoundException( ) { }

        /// <summary>
        /// Constructs the message
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException( string message ) : base( message ) { }
    }
}
