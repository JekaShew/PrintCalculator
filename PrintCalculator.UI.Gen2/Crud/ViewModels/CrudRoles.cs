namespace PrintCalculator.UI.Gen2.Crud.ViewModels
{
    /// <summary>
    /// Roles for crud actions
    /// </summary>
    public class CrudRoles
    {
        /// <summary>
        /// Allowed role to get
        /// Null if only authentication required
        /// </summary>
        public string Get { get; set; }
        /// <summary>
        /// Allowed role to add
        /// Null if only authentication required
        /// </summary>
        public string Add { get; set; }
        /// <summary>
        /// Allowed role to update
        /// Null if only authentication required
        /// </summary>
        public string Update { get; set; }
        /// <summary>
        /// Allowed role to delete
        /// Null if only authentication required
        /// </summary>
        public string Delete { get; set; }
        /// <summary>
        /// Period when user can edit own created item
        /// </summary>
        public System.TimeSpan OwnExceed { get; set; } = System.TimeSpan.FromHours(24);
    }
}
