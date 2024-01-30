using Microsoft.EntityFrameworkCore;
using System;
using Workshops.Data;
using Workshops.Models;
using Workshops.Repositórios.Interfaces;

namespace Workshops.Repositorios
{
    public class WorkshopRepositorio : IWorkshop
    {

        private readonly WorkshopsDB _dbContext;

        public WorkshopRepositorio(WorkshopsDB workshopsDB)
        {
            _dbContext = workshopsDB;
        }

        public async Task<WorkshopModel> Adicionar(WorkshopModel workshop)
        {
            await _dbContext.Workshops.AddAsync(workshop);
            await _dbContext.SaveChangesAsync();

            return workshop;
        }

        public async Task<WorkshopModel> Atualizar(WorkshopModel workshop, int id)
        {
            WorkshopModel workshopId = await BuscarPorId(id);

            if (workshopId != null)
            {
                workshopId.Nome = workshop.Nome;

                _dbContext.Workshops.Update(workshopId);
                await _dbContext.SaveChangesAsync();

                return workshopId;
            }

            throw new Exception($"Workshop referente ao Id: {id} não foi encontrado");
        }

        public async Task<bool> Apagar(int Id)
        {
            WorkshopModel workshopId = await BuscarPorId(Id);

            if (workshopId != null)
            {
                _dbContext.Workshops.Remove(workshopId);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            throw new Exception($"Workshop referente ao Id: {Id} não foi encontrado");
        }

        public async Task<List<WorkshopModel>> BuscarColaboradores()
        {
            return await _dbContext.Workshops.ToListAsync();
        }

        public async Task<WorkshopModel> BuscarPorId(int id)
        {
            return await _dbContext.Workshops.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<WorkshopModel>> BuscarWorkshops()
        {
            return await _dbContext.Workshops.ToListAsync();
        }

    }
}


