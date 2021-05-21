﻿using Habilitar.Core.Helpers;
using Habilitar.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Habilitar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly StorageConfig _storageConfig;
        private readonly IAzureBlobStorage _azureBlobStorage;

        public ValuesController(IOptions<StorageConfig> storageConfig, IAzureBlobStorage azureBlobStorage)
        {
            _storageConfig = storageConfig.Value;
            _azureBlobStorage = azureBlobStorage;            
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<string> Post([FromBody] string file)
        {
           return await _azureBlobStorage.Upload(file, Guid.NewGuid().ToString() + ".jpg");            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
