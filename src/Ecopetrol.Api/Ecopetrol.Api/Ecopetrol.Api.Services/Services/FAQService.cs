using AutoMapper;
using Ecopetrol.Api.API.Common.Settings;
using Ecopetrol.Api.Services.Contracts;
using Ecopetrol.Api.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecopetrol.Api.Services
{
    public class FAQService : IFAQService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;

        public FAQService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<FAQ> CreateAsync(FAQ faq)
        {
            return faq;
        }

        public async Task<bool> UpdateAsync(FAQ faq)
        {
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return true;
        }

        public async Task<FAQ> GetAsync(string id)
        {
            return new FAQ
            {
                Id = 1,
                Question = "Pregunta 1",
                Answer = "Respuesta 1"
            };
        }
        public async Task<IEnumerable<FAQ>> GetAllAsync()
        {
            return new List<FAQ>()
            {
                new FAQ
                {
                    Id = 1,
                    Question = "Pregunta 1",
                    Answer = "Respuesta 1"
                },
                new FAQ
                {
                    Id = 2,
                    Question = "Pregunta 2",
                    Answer = "Respuesta 2"
                },
            };
        }
    }
}
