namespace Films.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Ідентифікатор запиту, під час якого виникла помилка.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Вказує, чи потрібно показувати ідентифікатор запиту.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
