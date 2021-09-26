using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;
using тестове_xn__80aafim4ba8l_2.Data.Interfaces;
using тестове_xn__80aafim4ba8l_2.Models;

namespace тестове_xn__80aafim4ba8l_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IMapper _mapper;

        public IncidentsController(IIncidentRepository incidentRepository, IMapper mapper)
        {
            _incidentRepository = incidentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentReadModel>>> GetAllIncidentsAsync()
        {
            var incidents = await _incidentRepository.GetAllIncidentsAsync();

            if (!incidents.Any())
            {
                return NotFound("Sorry, the list of incidents is empty.");
            }

            return Ok(_mapper.Map<IEnumerable<IncidentReadModel>>(incidents));
        }

        [HttpGet("{name}", Name = "GetIncidentByNameAsync")]
        public async Task<ActionResult<IncidentReadModel>> GetIncidentByNameAsync(string name)
        {
            var incident = await _incidentRepository.GetIncidentByNameAsync(name);

            if (incident == null)
            {
                return NotFound($"Sorry. No incident found for the specified name: {name}.");
            }

            return Ok(_mapper.Map<IncidentReadModel>(incident));
        }

        [HttpPost]
        public async Task<ActionResult<IncidentCreateModel>> CreateIncidentAsync(IncidentCreateModel incidentCreateModel)
        {
            var incidentModel = _mapper.Map<Incident>(incidentCreateModel);
            try
            {
                await _incidentRepository.PostIncidentAsync(incidentModel);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            await _incidentRepository.SaveChangesAsync();

            var incidentReadModel = _mapper.Map<IncidentReadModel>(incidentModel);

            return CreatedAtRoute(nameof(GetIncidentByNameAsync), new { incidentReadModel.Name }, incidentReadModel);
        }
    }
}
