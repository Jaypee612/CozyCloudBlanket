namespace CozyCloudBlanket.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public string Name { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
