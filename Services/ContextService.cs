namespace BlazorApp4.Services
{
    public class ContextService
    {
        public string Token { get; set; } = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI3NjQ1ZjE0NC1mYTZhLTRjYTUtYTM2NC1hYWU5OWQ4MDMwYWEiLCJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJnaXZlbl9uYW1lIjoidG9tenNvIiwibmFtZWlkIjpbIjc2NDVmMTQ0LWZhNmEtNGNhNS1hMzY0LWFhZTk5ZDgwMzBhYSIsIjc2NDVmMTQ0LWZhNmEtNGNhNS1hMzY0LWFhZTk5ZDgwMzBhYSJdLCJuYmYiOjE3NTc2ODIxNTQsImV4cCI6MTc1ODI4Njk1NCwiaWF0IjoxNzU3NjgyMTU0LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjcyNjciLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjcyNjcifQ._IbbazGWw_oTSgpkgGdrkvgc7JLK8e9BhbRnvX5AAvHJUBb5Gj0bAjgHpHgVsDfFADGHngAH-4JZKL_S3wBhiA";


        // You can also use events to notify changes
        public event Action OnChange;

        public void SetMessage(string message)
        {
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
