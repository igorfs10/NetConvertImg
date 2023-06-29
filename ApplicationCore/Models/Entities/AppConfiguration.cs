using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models.Entities
{
    [Table("TB_CONFIGURATION")]
    public class AppConfiguration
    {
        [Key, Column("CONF_ID")]
        public byte Id { get; set; }

        [Column("CONF_TYPE")]
        public string? FileType { get; set; }

        [Column("CONF_OUTPUT")]
        public string? OutputFolder { get; set; }

        [Column("CONF_HEIGHT")]
        public int? Height { get; set; }

        [Column("CONF_WIDTH")]
        public int Width { get; set; }
    }
}
