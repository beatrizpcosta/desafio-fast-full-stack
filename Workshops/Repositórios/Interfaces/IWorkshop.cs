using Workshops.Models;

namespace Workshops.Repositórios.Interfaces
{
    public interface IWorkshop
    {
        Task<List<WorkshopModel>> BuscarWorkshops();
        Task<WorkshopModel> BuscarPorId(int Id);
        Task<WorkshopModel> Adicionar(WorkshopModel workshop);
        Task<WorkshopModel> Atualizar(WorkshopModel workshop, int Id);
        Task<bool> Apagar(int Id);

    }
}
