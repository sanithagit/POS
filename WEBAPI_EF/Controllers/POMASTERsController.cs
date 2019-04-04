﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPI_EF.Models;

namespace WEBAPI_EF.Controllers
{
    public class POMASTERsController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/POMASTERs
        public IQueryable<POMASTER> GetPOMASTERs()
        {
            return db.POMASTERs;
        }

        // GET: api/POMASTERs/5
        [ResponseType(typeof(POMASTER))]
        public IHttpActionResult GetPOMASTER(int id)
        {
            POMASTER pOMASTER = db.POMASTERs.Find(id);
            if (pOMASTER == null)
            {
                return NotFound();
            }

            return Ok(pOMASTER);
        }

        // PUT: api/POMASTERs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPOMASTER(int id, POMASTER pOMASTER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pOMASTER.PONO)
            {
                return BadRequest();
            }

            db.Entry(pOMASTER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POMASTERExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/POMASTERs
        [ResponseType(typeof(POMASTER))]
        public IHttpActionResult PostPOMASTER(POMASTER pOMASTER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.POMASTERs.Add(pOMASTER);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pOMASTER.PONO }, pOMASTER);
        }

        // DELETE: api/POMASTERs/5
        [ResponseType(typeof(POMASTER))]
        public IHttpActionResult DeletePOMASTER(int id)
        {
            POMASTER pOMASTER = db.POMASTERs.Find(id);
            if (pOMASTER == null)
            {
                return NotFound();
            }

            db.POMASTERs.Remove(pOMASTER);
            db.SaveChanges();

            return Ok(pOMASTER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool POMASTERExists(int id)
        {
            return db.POMASTERs.Count(e => e.PONO == id) > 0;
        }
    }
}