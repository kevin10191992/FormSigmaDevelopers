using FormSigmaDevelopers.Models;
using System.Threading.Tasks;

namespace FormSigmaDevelopers.Interfaces
{
    public interface IFormService
    {
        Task<ResultResponse> SaveForm(Contacts Contact);
        Task<ResultResponse> GetCatalog();
    }
}
