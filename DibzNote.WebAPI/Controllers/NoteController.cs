using DibzNote.Models;
using DibzNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DibzNote.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }
        [HttpPost]
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.CreateNote(note))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            NoteService noteService = CreateNoteService();
            var note = noteService.GetNoteById(id);
            return Ok(note);
        }
        [HttpGet]
        [Route("api/Notes/IsStarred")]
        public IHttpActionResult GetByStar()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNoteByStarred();
            return Ok(notes);
        }
        [HttpPut]
        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.Updatenote(note))
                return InternalServerError();

            return Ok("Score.");
        }
        [HttpPut]
        [Route("api/Notes/AddStar")]
        public IHttpActionResult AddStarToNote(int id)
        {
            {
                var service = CreateNoteService();

                if (!service.AddStar(id))
                    return InternalServerError();

                return Ok($"Star Added to Note number: {id}");
            }
        }
        [HttpPut]
        [Route("api/Notes/RemoveStar")]
        public IHttpActionResult RemoveStarFromNote(int id)
        {
            {
                var service = CreateNoteService();

                if (!service.RemoveStar(id))
                    return InternalServerError();

                return Ok($"Star Removed From Note number: {id}");
            }
        }
    }
}
