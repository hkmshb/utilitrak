using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Hazeltek.Infrastructure;
using Hazeltek.UtiliTrak.Web.Common.Routing;
using Hazeltek.UtiliTrak.Data.Domain.Network;
using Hazeltek.UtiliTrak.Web.Api.Models.Stations;
using Hazeltek.UtiliTrak.Services.Network;
using Hazeltek.UtiliTrak.Web.Common.TypeMapping;



namespace Hazeltek.UtiliTrak.Web.Api.Controllers.V1
{
    [ApiVersion1Route("[controller]")]
    public class StationsController: BaseController
    {
        // fields:
        private IStationService stationService;

        public StationsController(IStationService stationService)
        {
            this.stationService = stationService;
        }
 
        [HttpGet("", Name="GetStations")]
        public IActionResult GetStations([FromQuery]StationPagingFilteringModel command)
        {
            // TODO: get page size from user or default settings
            var pageSize = command.PageSize > 0? command.PageSize: 20;
            var stations = stationService.GetStations(command.PageIndex, pageSize,
                    command.Type, command.VoltageRatio, command.SourcePowerLineCode,
                    command.IsPublic);
            
            var models = new List<StationModel>();
            foreach (var station in stations) {
                models.Add(Mapper.Map<StationModel>(station));
            }
            return Ok(models);
        }

        [HttpGet("{code}", Name="GetStation")]
        public IActionResult GetStation(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) {
                var msg = "Code cannot be null, empty or whitespace.";
                return BadRequest(new { Errors = msg });
            }

            var station = stationService.GetByCode(code);
            return Ok(Mapper.Map<StationModel>(station));
        }


        [HttpPost("")]
        public IActionResult Create([FromBody]StationModel model)
        {
            return Process(() => {
                var station = Map(model);
                stationService.InsertStation(station);
                return CreatedAtRoute("GetStation", new { Code=station.Code.ToLower()}, station);
            });
        }

        [HttpPut("{id:int}", Name="UpdateStationById")]
        public IActionResult Update(int id, [FromBody]StationModel model)
        {
            return Process(() => {
                var station = stationService.GetById(id);
                if (station == null) 
                    return NotFound();
                
                model.DateCreated = station.DateCreated;
                station = model.MapTo(station);
                stationService.UpdateStation(station);
                return Ok(station);
            });
        }

        [HttpPut("{code}", Name="UpdateStation")]
        public IActionResult Update(string code, [FromBody]StationModel model)
        {
            return Process(() => {
                var station = stationService.GetByCode(code);
                if (station == null)
                    return NotFound();
                
                model.DateCreated = station.DateCreated;
                station = model.MapTo(station);
                stationService.UpdateStation(station);
                return Ok(station);
            });
        }

        [HttpDelete("{code}", Name="DeleteStation")]
        public IActionResult Delete(string code)
        {
            return Process(() => {
                var station = stationService.GetByCode(code);
                if (station == null)
                    return NotFound();
                
                station.Deleted = true;
                stationService.UpdateStation(station);
                return Ok(station);
            });
        }

        private Station Map(StationModel model)
        {
            switch (model.Type) {
                case StationType.Transmission:
                    return Mapper.Map<TransmissionStation>(model);
                case StationType.Injection:
                    return Mapper.Map<InjectionSubstation>(model);
                default:
                    return Mapper.Map<DistributionSubstation>(model); 
            }
        }
    }

    
}