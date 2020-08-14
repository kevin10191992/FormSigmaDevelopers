using FormSigmaDevelopers.Context;
using FormSigmaDevelopers.Interfaces;
using FormSigmaDevelopers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormSigmaDevelopers.Services
{
    public class FormServices : IFormService
    {
        private readonly ContextoPrincipal _context;

        public FormServices(ContextoPrincipal context)
        {
            _context = context;
        }

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
