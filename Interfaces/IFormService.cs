using FormSigmaDevelopers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormSigmaDevelopers.Interfaces
{
    public interface IFormService
    {
        Task<ResultResponse> SaveForm(Contacts Contact);
    }
}
