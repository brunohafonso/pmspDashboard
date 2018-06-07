using bruno.pmsp.repository.Context;
using bruno.pmsp.domain.Entities;
using System;
using System.Linq;

namespace bruno.pmsp.MVC
{
    public class IniciarBanco
    {
        public static void Inicializar(PmspContext _context)
        {
            _context.Database.EnsureCreated();
            if(_context.Servidores.Any()) {
                return;
            }

            var login = new Login("828.720.1", "bbc259521");
            _context.Logins.Add(login);
            
            var servidor = new Servidor(login.Id, "Bruno Henrique Afonso", "Solteiro", "Masculino", "828.720.1", DateTime.Parse("25/04/1995"), "brunohafonso@gmail.com", "WhatsApp");
            _context.Servidores.Add(servidor);
            
            var telefone = new Telefone(servidor.Id, "(11) 2053-1053", "(11) 94855-2364", "(11) 94855-2364", "(11) 96071-8515", "(11) 2334-2999");
            var endereco = new Endereco(servidor.Id, "04187-160" ,"Rua do capitarizinho", 33, "casa 05", "Vila Liviero", "São Paulo", "SP");
            var vinculo = new Vinculo(servidor.Id, 1, "Auxiliar Técnico de Educação", "Cei Jardim Climax II", "Cei Jardim Climax II", "03A", DateTime.Parse("25/04/2016"), "Efetivo / Ativo", "J40", "DRE IPIRANGA");

            _context.Telefones.Add(telefone);
            _context.Enderecos.Add(endereco);
            _context.Vinculos.Add(vinculo);
            _context.SaveChanges(); 
        }
    }
}