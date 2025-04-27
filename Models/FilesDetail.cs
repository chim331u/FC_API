using System.ComponentModel.DataAnnotations;

namespace OneApp_minimalApi.Models
{
    public class FilesDetail : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public double FileSize { get; set; }
        public DateTime LastUpdateFile { get; set; }

        public string? FileCategory { get; set; }
        public bool IsToCategorize { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNotToMove { get; set; }

    }
}