﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shorten_Links.context;
using Shorten_Links.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shorten_Links.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutLinksController : ControllerBase
    {

        LogicaNegocios.LogicaCutLink lcl = new LogicaNegocios.LogicaCutLink();
        private readonly DBContext context;
        public CutLinksController(DBContext context)
        {
            this.context = context;
        }

        // GET: api/<CutLinksController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {

                return Ok(context.Registros.ToList()); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CutLinksController>/5
        [HttpGet("{id}", Name ="GetRegistro")]
        public RedirectResult Get(string id)
        {
            dynamic registro = null;
            try
            {
                registro = context.Registros.FirstOrDefault(r=>r.TokenUrl == id);
                if (id.Equals(registro.TokenUrl))
                {
                    context.Entry(lcl.ContadorIngreso(registro)).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Utilitarios.Util ut = new Utilitarios.Util();
            }
            return Redirect(registro.UrlOriginal);
        }

        // POST api/<CutLinksController>
        [HttpPost]
        public ActionResult Post([FromBody]GestorBD gestor)
        {
            try
            {
                context.Registros.Add(lcl.CutLink(gestor));
                context.SaveChanges();
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CutLinksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]GestorBD gestor)
        {
            try
            {
                if (id.Equals(gestor.TokenUrl))
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetRegistro", new { id = gestor.TokenUrl }, gestor);
                }
                else{
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CutLinksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var registro = context.Registros.FirstOrDefault(r => r.CiRegistros == id);
                if (!registro.CiRegistros.Equals(null))
                {
                    context.Entry(registro).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
