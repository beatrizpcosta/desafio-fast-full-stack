using Microsoft.EntityFrameworkCore;
using System;
using Workshops.Data;
using Workshops.Models;
using Workshops.Repositórios.Interfaces;

namespace Workshops.Repositorios
{
    public class ColaboradorRepositorio : IColaborador
    {

        private readonly WorkshopsDB _dbContext;

        public ColaboradorRepositorio(WorkshopsDB workshopsDB) 
        {
            _dbContext = workshopsDB;
        }

        public async Task<ColaboradorModel> Adicionar(ColaboradorModel colaborador)
        {
           await _dbContext.Colaboradores.AddAsync(colaborador);
           await _dbContext.SaveChangesAsync();

            return colaborador;
        }

        public async Task<ColaboradorModel> Atualizar(ColaboradorModel colaborador, int id)
        {
            ColaboradorModel colaboradorId = await BuscarPorId(id);

                if (colaboradorId == null)
            {
                throw new Exception($"Colaborador do referente Id: {id} não foi encontrado");
            }

                colaboradorId.Nome = colaborador.Nome;

            _dbContext.Colaboradores.Update(colaboradorId);
            await _dbContext.SaveChangesAsync();

            return colaboradorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            ColaboradorModel colaboradorId = await BuscarPorId(Id);

                if (colaboradorId == null)
            {
                throw new Exception($"Colaborador do referente Id: {Id} não foi encontrado");
            }

                _dbContext.Colaboradores.Remove(colaboradorId);
                await _dbContext.SaveChangesAsync();
                return true;
        }

        public async Task<List<ColaboradorModel>> BuscarColaboradores()
        {
            return await _dbContext.Colaboradores.ToListAsync();
        }

        public async Task<ColaboradorModel> BuscarPorId(int id)
        {
            return await _dbContext.Colaboradores.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
