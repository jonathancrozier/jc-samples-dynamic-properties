namespace JC.Samples.DynamicProperties.Models
{
    /// <summary>
    /// Represents a set of additional dynamic values to be added to a Todo item at runtime.
    /// </summary>
    public class TodoDynamicValue
    {
        #region Properties

        /// <summary>
        /// The ID of the Todo item the values belong to.
        /// </summary>
        public int TodoId { get; set; }

        /// <summary>
        /// Custom Flag to determine if the Todo item is important.
        /// </summary>
        public bool Important { get; set; }

        /// <summary>
        /// Custom Notes for the Todo item.
        /// </summary>
        public string Notes { get; set; }

        #endregion
    }
}