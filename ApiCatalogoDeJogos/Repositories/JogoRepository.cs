using ApiCatalogoDeJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("4bec3422-2ba1-45f8-b857-3c8feb12dadd"), new Jogo{ Id=Guid.Parse("4bec3422-2ba1-45f8-b857-3c8feb12dadd"), Nome="Battlefield", Produtora= "EA", Preco=199.99}},
            {Guid.Parse("a1c66a62-2375-40c1-882e-387bd6523602"), new Jogo{ Id=Guid.Parse("a1c66a62-2375-40c1-882e-387bd6523602"), Nome="Forza", Produtora= "Xbox Studios", Preco=499.99}},
            {Guid.Parse("c2be2e43-cf89-4baf-be0d-a59fd768207d"), new Jogo{ Id=Guid.Parse("c2be2e43-cf89-4baf-be0d-a59fd768207d"), Nome="It takes two", Produtora= "Activision", Preco=99.99}},
            {Guid.Parse("5a69c09c-2e6d-4e74-89ac-2f1991ca90b4"), new Jogo{ Id=Guid.Parse("5a69c09c-2e6d-4e74-89ac-2f1991ca90b4"), Nome="Diablo", Produtora= "Blizzard", Preco=129.99}},
            {Guid.Parse("62feb333-8a14-4b09-a124-e015158a9131"), new Jogo{ Id=Guid.Parse("62feb333-8a14-4b09-a124-e015158a9131"), Nome="Star Wars", Produtora= "Activision", Preco=299.99}},
            {Guid.Parse("155434a4-6788-45cf-a05b-b0dffd4bcb5e"), new Jogo{ Id=Guid.Parse("155434a4-6788-45cf-a05b-b0dffd4bcb5e"), Nome="This War of Mine", Produtora= "Indie", Preco=59.99}}
        };

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fecha conexão com o banco
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
            {
                return null;

            }

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {


            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
    }
}
