using System.ComponentModel.DataAnnotations;

namespace ProjectMangukiyaBrijMukesh
{
    public class watchlistsModel
    {
        public string Name { get; set; }
        public int ListId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }

    }
}
