using Workshops.Models;

namespace Workshops.Repositórios.Interfaces
{
    public interface IColaborador
    {
        Task<List<ColaboradorModel>> BuscarColaboradores();
        Task<ColaboradorModel> BuscarPorId(int Id);
        Task<ColaboradorModel> Adicionar(ColaboradorModel colaborador);
        Task<ColaboradorModel> Atualizar (ColaboradorModel colaborador, int Id);
        Task<bool> Apagar(int Id);

    }
}
