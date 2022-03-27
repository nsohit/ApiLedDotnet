using System.ComponentModel;

namespace Led.Models;

public class StatusOk {
    [DefaultValue("ok")]
    public string Status { get; set; } = "ok";

    public static IActionResult Create() {
        return new OkObjectResult(new StatusOk());
    }
}
