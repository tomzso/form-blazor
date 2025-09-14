namespace BlazorApp4.Models
{
    public class FormFieldModel
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Label { get; set; }
        public string FieldType { get; set; } // e.g., "radiobox", "checkbox", "textbox"
        public bool Required { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }

        public List<FormFieldOptionModel> Options { get; set; } = new();

        // Placeholder for future responses
        public string? RadioResponse { get; set; } = string.Empty;
        public List<string> CheckboxResponse { get; set; } = new List<string>();
        public string? TextResponse { get; set; } = string.Empty;

    }
}
