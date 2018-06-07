using System;
using System.Collections.Generic;
using System.Linq;
using bruno.pmsp.domain.Contracts;
using bruno.pmsp.repository.Context;
using Microsoft.EntityFrameworkCore;

namespace bruno.pmsp.repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly PmspContext _context;

        public BaseRepository(PmspContext context)
        {
            _context = context;
        }
        
        public int Atualizar(T dados)
        {
            try
            {
                _context.Set<T>().Update(dados);
                return _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro a atualizar registro. " + ex.Message);
            }
        }

        public T BuscarPorId(int id, string[] includes = null)
        {
            try 
            {
                var chavePrimaria = _context.Model.FindEntityType (typeof (T)).FindPrimaryKey ().Properties[0];
                var query = _context.Set<T>().AsQueryable();

                if(includes == null) return query.FirstOrDefault (e => EF.Property<int> (e, chavePrimaria.Name) == id);

                foreach(var include in includes)
                {   
                    query = query.Include(include);
                }

                return query.FirstOrDefault (e => EF.Property<int> (e, chavePrimaria.Name) == id);
            }
            catch(Exception ex)
            {
                throw new Exception("erro oa buscar registro. " + ex.Message);
            }
        }

        public int Deletar(T dados)
        {
            try 
            {
                _context.Set<T>().Remove(dados);
                return _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao deletar registro. " + ex.Message);
            }
        }

        public int Inserir(T dados)
        {
            try
            {
                _context.Set<T>().Add(dados);
                return _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao salvar registro na base de dados. " + ex.Message);
            }
        }

        public IEnumerable<T> Listar(string[] includes = null)
        {
            try 
            {
                var query = _context.Set<T>().AsQueryable();
                if(includes == null) return query.ToList(); 
                
                foreach(var include in includes)
                {   
                    query = query.Include(include);
                }

                return query.ToList();
            }
            catch(Exception ex) 
            {
                throw new Exception("Erro ao listar dados. " + ex.Message);
            }
        }
    }
}