﻿using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Uow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Habilitar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController<T> : ControllerBase where T :  Funcao
    {
        private readonly IRepositoryBase<T> _repository;
        private readonly IUnitOfWork _uow;

        public FuncaoController(IRepositoryBase<T> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lst = await _repository.GetAll();

                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
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

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, T obj)
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

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(T obj)
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

        // DELETE: api/Empresa/5
        [HttpDelete("{id}")]
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
