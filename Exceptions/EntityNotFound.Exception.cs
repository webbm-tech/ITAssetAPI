 public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Constructor accounting for just a custom message.
        /// </summary>
        /// <param name="message">The custom exception message.</param>
        /// <returns>The EntityNotFoundException to return.</returns>
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}