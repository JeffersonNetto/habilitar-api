﻿using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Uow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Controllers
{
    [Route("api/[controller]")]    
    public class UnidadeController : MainController
    {
        private readonly IRepositoryBase<Unidade> _repository;
        private readonly IUnitOfWork _uow;

        public UnidadeController(IRepositoryBase<Unidade> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        // GET: api/Unidade
        [HttpGet]
        public async Task<ActionResult<List<Unidade>>> Get()
        {
            try
            {
                var lst = await _repository.GetAll();

                return CustomSuccessResponse(200, "Unidades obtidas com sucesso", lst);
            }
            catch (Exception ex)
            {
                return CustomErrorResponse(400, ex?.Message ?? ex?.InnerException?.Message);
            }
        }

        // GET: api/Unidade/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var obj = await _repository.GetById(id);

                return obj == null ? NotFound() : Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Unidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Unidade obj)
        {
            try
            {
                if (id != obj.Id)
                    return BadRequest();

                _repository.Update(obj);
                await _uow.Commit();

                return Ok(await Get(obj.Id));
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest(ex);
            }
        }

        // POST: api/Unidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(Unidade obj)
        {
            try
            {
                await _repository.Add(obj);
                await _uow.Commit();

                return CreatedAtAction("Post", await Get(obj.Id));
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest(ex);
            }
        }

        // DELETE: api/Unidade/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _repository.Remove(await _repository.GetById(id));
                await _uow.Commit();

                return NoContent();
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest(ex);
            }
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}