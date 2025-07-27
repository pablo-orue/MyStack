using System.ComponentModel.DataAnnotations;

namespace MyStack.KeepAlive.Domain
{
    public class VersionInfo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Value { get; set; } = null!;
    }
}
