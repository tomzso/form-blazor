namespace BlazorApp4.Models
{
    public class OptionModel
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public string OptionValue { get; set; }
        public int Order { get; set; }
        public bool IsCorrect { get; set; }
        public int ResponseCount { get; set; }

    }
}
