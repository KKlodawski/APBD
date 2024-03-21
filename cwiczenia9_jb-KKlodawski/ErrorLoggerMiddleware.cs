namespace Zadanie9;

public class ErrorLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _file;
    

    public ErrorLoggerMiddleware(RequestDelegate next,string file)
    {
        _next = next;
        _file = file;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            SaveToFile(ex);
            throw;
        }
    }

    private void SaveToFile(Exception ex)
    {
        string msg = $"[{DateTime.Now}] {ex.Message}\n{ex.StackTrace}\n";
        
        File.AppendAllText(_file, msg);
    }

}