namespace JC.Samples.DynamicProperties.Models
{
    /// <summary>
    /// Represents a 'Todo' item.
    /// </summary>
    public class Todo
    {
        #region Properties

        /// <summary>
        /// The unique ID of the Todo item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of the User the Todo item is assigned to.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The Title/Description of the Todo item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Whether or not the Todo item has been completed.
        /// </summary>
        public bool Completed { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Overrides the standard 'ToString' method with the Title of the Todo.
        /// </summary>
        /// <returns>The Title of the Todo with a prefix</returns>
        public override string ToString() => $"Title: {Title}";

        #endregion
    }
}