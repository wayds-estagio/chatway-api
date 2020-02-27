using Domain.Entities;
using Infrastructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository {

    public class UsuarioRepository {
        private readonly IMongoCollection<Usuario> _usuario;

        public UsuarioRepository(ContextDB contextDB) {
            _usuario = contextDB.GetCollection<Usuario>("usuario");
        }

        public Usuario Create(Usuario usuario) {
            usuario.DataCriacao = DateTime.Now;
            _usuario.InsertOne(usuario);
            return usuario;
        }

        public List<Usuario> Get() => _usuario.Find(u => true).ToList();

        public Usuario Get(string id) => _usuario.Find<Usuario>(u => u.Id == id).FirstOrDefault();

        public void Update(string id, Usuario usuario) => _usuario.ReplaceOne(u => u.Id == id, usuario);

        public void Remove(string id) => _usuario.DeleteOne(u => u.Id == id);
    }
}