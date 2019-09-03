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
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            _settings = settings?.Value;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
                Question = "¿En Ecopetrol los cargos están sujetos a nombramientos oficiales?",
                Answer = "Con ocasión a la entrada en vigencia de la Ley 1118 de 2006, la totalidad del personal vinculado a Ecopetrol S.A., para efectos de la regulación de sus relaciones de trabajo, tienen el carácter de trabajadores particulares, y por tanto se rigen por las normas contenidas en el Código Sustantivo del Trabajo. En ese sentido, en Ecopetrol los cargos no están sujetos a nombramientos oficiales; y por tanto los mismos son provistos a través de procesos de selección directa adelantados por la Vicepresidencia de Talento Humano."
            };
        }
        public async Task<IEnumerable<FAQ>> GetAllAsync()
        {
            return new List<FAQ>()
            {
                new FAQ
                {
                    Id = 1,
                    Question = "¿En Ecopetrol los cargos están sujetos a nombramientos oficiales?",
                    Answer ="Con ocasión a la entrada en vigencia de la Ley 1118 de 2006, la totalidad del personal vinculado a Ecopetrol S.A., para efectos de la regulación de sus relaciones de trabajo, tienen el carácter de trabajadores particulares, y por tanto se rigen por las normas contenidas en el Código Sustantivo del Trabajo. En ese sentido, en Ecopetrol los cargos no están sujetos a nombramientos oficiales; y por tanto los mismos son provistos a través de procesos de selección directa adelantados por la Vicepresidencia de Talento Humano."
                },
                new FAQ
                {
                    Id = 2,
                    Question = "¿Quiénes pueden participar en una convocatoria de selección?",
                    Answer ="Todas las personas de Colombia y el mundo que se encuentren interesadas en aplicar a la convocatoria y cumplan con el perfil requerido para el cargo."
                },
            };
        }
    }
}
