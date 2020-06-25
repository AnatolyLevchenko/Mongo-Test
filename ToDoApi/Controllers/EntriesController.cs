using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Services;
using ToDo.Domain;
using ToDo.Domain.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IDatabaseSettings _settings;
        private readonly EntryService _entryService;

        public EntriesController(IDatabaseSettings settings, EntryService entryService)
        {
            _settings = settings;
            _entryService = entryService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Entry>> Get()
        {
            return _entryService.GetAll();
        }


        [HttpGet("{id:length(24)}", Name = "GetEntry")]
        public ActionResult<Entry> Get(string id)
        {
            var entry = _entryService.GetById(id);
            if (id == null)
                return NotFound();
            return Ok(entry);
        }


        [HttpPost]
        public ActionResult<Entry> Create(Entry entry)
        {
            _entryService.Create(entry);
            return CreatedAtRoute("GetEntry", new { id = entry.Id });
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, Entry entry)
        {
            var e = _entryService.GetById(entry.Id);
            if (e == null)
                return NotFound(entry.Id);
            _entryService.Update(id, entry);

            return NoContent();
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var entry = _entryService.GetById(id);
            if (entry == null)
                NotFound();
            _entryService.Remove(id);

            return NoContent();
        }
    }
}
