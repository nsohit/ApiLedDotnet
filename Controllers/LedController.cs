using System.ComponentModel;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Led.Models;

namespace Led.Controller;
[Produces("application/json")]
[ProducesResponseType(typeof(StatusOk), 200)]

public class LedController:ControllerBase{
    private readonly ILedService _led;

    public LedController(ILedService led) {
        _led = led;
    }
    
    [HttpPost("/led")]
    public async Task<IActionResult> SetEnvirontmentLed(
        [FromBody] LedModel? req,
        [FromQuery] double? value
    ) {
        // try {
        if (req is not null) {
            // var v = req.Value / 100.0;
            // if (v > 1) v = 1.0;
            // if (v < 0) v = 0.0;
            await _led.SetLedEnvirontment(req.Value);
        } else if (value is not null) {
            // var v = value.Value / 100.0;
            // if (v > 1) v = 1.0;
            // if (v < 0) v = 0.0;
            await _led.SetLedEnvirontment(value.Value);
        } else {
            return BadRequest("Nilai tidak didefinikan");
        }

        return StatusOk.Create();
        // } catch (Exception ex) {
        //     return BadRequest(ex.Message);
        // }
    }

}
    
