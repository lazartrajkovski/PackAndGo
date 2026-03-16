using System.ComponentModel.DataAnnotations;

namespace PackAndGo.DTOs
{
    public class BookReq
    {
        [Required]
        public string OptionCode { get; set; } = string.Empty;
    }
}
