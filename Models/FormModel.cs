using Microsoft.AspNetCore.Http;

namespace BlazorApp4.Models
{
    public class FormModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Url { get; set; }
        public Guid UserId { get; set; }

        public List<FormFieldModel> FormFields { get; set; } = new();
    }

}
