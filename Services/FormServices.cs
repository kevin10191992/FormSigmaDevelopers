using FormSigmaDevelopers.Context;
using FormSigmaDevelopers.Interfaces;
using FormSigmaDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormSigmaDevelopers.Services
{
    public class FormServices : IFormService
    {
        private readonly ContextoPrincipal _context;
        private readonly IConfiguration _configuration;

        public FormServices(ContextoPrincipal context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Permite obtener el catalogo
        /// </summary>
        /// <returns></returns>
        public async Task<ResultResponse> GetCatalog()
        {
            ResultResponse result = new ResultResponse();
            string url = _configuration.GetValue<string>("UrlServicios:DepCity");
            try
            {

                JObject res = await Utils.ConsumirApiRest.ConsumirApiSalidaJObject(url, null, "GET");

                if (res != null)
                {
                    result.Codigo = "01";
                    result.Descripcion = "Datos encontrados";
                    result.Data = res;

                }
                else
                {
                    result.Codigo = "02";
                    result.Descripcion = "No se encontraron datos";
                }


            }
            catch (Exception e)
            {
                result = new ResultResponse();
                result.Codigo = "02";
                result.Descripcion = "Error al obtener los datos";
                result.DetalleError = e.ToString();
            }


            return result;
        }

        /// <summary>
        /// Permite guardar el formulario
        /// </summary>
        /// <param name="Contact"></param>
        /// <returns></returns>
        public async Task<ResultResponse> SaveForm(Contacts Contact)
        {
            ResultResponse result = new ResultResponse();

            try
            {
                if (await _context.Contacts.AnyAsync(a => a.Email.Equals(Contact.Email) && a.Name.Equals(Contact.Name)))
                {
                    result.Codigo = "03";
                    result.Descripcion = "Ya hemos recibido tu información antes";
                }
                else
                {
                    await _context.AddAsync(Contact);
                    await _context.SaveChangesAsync();

                    result.Codigo = "01";
                    result.Descripcion = "Registro Guardado con exito";
                }


            }
            catch (Exception e)
            {
                result = new ResultResponse();
                result.Codigo = "02";
                result.Descripcion = "No se puede guardar el registro";
                result.DetalleError = e.ToString();
            }


            return result;
        }
    }
}
