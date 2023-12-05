using System.ComponentModel.DataAnnotations;

namespace ProjectMangukiyaBrijMukesh
{
    public class watchlistItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ListId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AddedOn { get; set; }
        public int ItemId { get; set; }
        public string MediaType { get; set; }
        public int GenreId { get; set; }
        public int MediaId { get; set; }
    }
}
