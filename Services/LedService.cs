
using System.Diagnostics;
using System.Drawing;
using System.Text.Json;
namespace Led.Services;

public interface ILedService{
    Task SetLedEnvirontment(double value);
}

public class LedService : ILedService{
    public async Task SetLedEnvirontment(double value){
        if (value < 0) return;
        if (value > 100) value=100;
        using var httpClient = new HttpClient();

        var req = new {
            value
        };
        await httpClient.PostAsJsonAsync<object>("http://localhost:9001/pwmpins", req);
    }
    
}