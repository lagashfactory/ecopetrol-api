using AutoMapper;
using Ecopetrol.Api.API.DataContracts.Requests;
using Ecopetrol.Api.API.DataContracts;
using Ecopetrol.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using S = Ecopetrol.Api.Services.Model;
using System.Collections.Generic;

namespace Ecopetrol.Api.API.Controllers
{
    
    [Route("api/faq")]//required for default versioning    
    public class FAQController : Controller
    {
        private readonly IFAQService _service;
        private readonly IMapper _mapper;

        public FAQController(IFAQService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Comments and descriptions can be added to every endpoint using XML comments.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IEnumerable<S.FAQ>> GetAll()
        {
            var data = await _service.GetAllAsync();

            if (data != null)
                return data;
            else
                return null;
        }

        /// <summary>
        /// Comments and descriptions can be added to every endpoint using XML comments.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<FAQ> Get(string id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<FAQ>(data);
            else
                return null;
        }


        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created user.</returns>
        /// <response code="201">Returns the newly created item.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<FAQ> Create([FromBody]S.FAQ value)
        {

            //TODO: include exception management policy according to technical specifications
            if (value == null)
                throw new ArgumentNullException("value");

            if (value == null)
                throw new ArgumentNullException("value.FAQ");


            var data = await _service.CreateAsync(value);

            if (data != null)
                return _mapper.Map<FAQ>(data);
            else
                return null;

        }

        [HttpPut()]
        public async Task<bool> Update(S.FAQ parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            return await _service.UpdateAsync(parameter);
        }


        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _service.DeleteAsync(id);
        }
       
    }
}
