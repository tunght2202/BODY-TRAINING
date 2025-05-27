namespace BODYTRANINGAPI.Models
{
    public class ProgressLogsMedias
    {
        public int PLMId { get; set; }
        public int ProgressLogId { get; set; }
        public string MediaUrl { get; set; }
        public MediaType MediaType { get; set; }
        public DateTime DateCreated { get; set; }
        public ProgressLog ProgressLog { get; set; }

    }
}
