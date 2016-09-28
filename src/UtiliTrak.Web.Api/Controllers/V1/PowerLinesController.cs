using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Hazeltek.UtiliTrak.Web.Common.Routing;
using Hazeltek.UtiliTrak.Services.Network;
using Hazeltek.UtiliTrak.Web.Api.Models.PowerLines;
using Hazeltek.UtiliTrak.Data.Domain.Network;

namespace Hazeltek.UtiliTrak.Web.Api.Controllers.V1
{
    [ApiVersion1Route("[controller]")]
    public class PowerLinesController: BaseController
    {
        // fields:
        private IPowerLineService powerlineService;

        public PowerLinesController(IPowerLineService powerlineService)
        {
            this.powerlineService = powerlineService;
        }      

        [HttpGet("", Name="GetPowerLines")]
        public IActionResult GetPowerLines([FromQuery] PowerLinePagingFilteringModel command)
        {
            // TODO: get page size from user or default settings
            var pageSize = command.PageSize > 0? command.PageSize: 20;
            var powerlines = powerlineService.GetPowerLines(command.PageIndex,
                    pageSize, command.Type, command.Voltage,
                    command.SourceStationCode);
            
            var models = new List<PowerLineModel>();
            foreach (var pl in powerlines) {
                models.Add(Mapper.Map<PowerLineModel>(pl));
            }
            return Ok(models);
        }

        [HttpGet("{code}", Name="GetPowerLine")]
        public IActionResult GetPowerLine(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) {
                var msg = "Code cannot be null, empty or whitespace.";
                return BadRequest(new { Errors = msg });
            }
            var powerline = powerlineService.GetByCode(code);
            return Ok(Mapper.Map<PowerLineModel>(powerline));
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] PowerLineModel model)
        {
            return Process(() => {
                var powerline = Map(model);
                powerlineService.InsertPowerLine(powerline);
                return CreatedAtRoute("GetPowerLine", new { Code=powerline.Code.ToLower()}, powerline);
            });
        }

        [HttpPut("{code}", Name="UpdatePowerLine")]
        public IActionResult Update(string code, [FromBody]PowerLineModel model)
        {
            return Process(() => {
                var powerline = powerlineService.GetByCode(code);
                if (powerline == null)
                    return NotFound();
                
                model.DateCreated = powerline.DateCreated;
                powerline = model.MapTo(powerline);
                powerlineService.UpdatePowerLine(powerline);
                return Ok(powerline);
            });
        }

        [HttpDelete("{code}", Name="DeletePowerLine")]
        public IActionResult Delete(string code)
        {   
            return Process(() => {
                var powerline = powerlineService.GetByCode(code);
                if (powerline == null)
                    return NotFound();
                
                powerline.Deleted = true;
                powerlineService.UpdatePowerLine(powerline);
                return Ok(powerline);
            });
        }

        private PowerLine Map(PowerLineModel model)
        {
            if (model.Type == PowerLineType.Feeder)
                return Mapper.Map<Feeder>(model);
            return Mapper.Map<Upriser>(model);
        }  
    }


}