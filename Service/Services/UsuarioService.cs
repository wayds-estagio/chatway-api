using Domain.Entities;
using Infrastructure.Repository;
using System.Collections.Generic;

namespace Service.Services {

    public class UsuarioService {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuario) {
            this._usuarioRepository = usuario;
        }

        public List<Usuario> Get() {
            return _usuarioRepository.Get();
        }

        public Usuario Get(string id) {
            return _usuarioRepository.Get(id);
        }

        public void Create(Usuario usuario) {
            _usuarioRepository.Create(usuario);
        }

        public void Update(string id, Usuario usuario) {
            _usuarioRepository.Update(id, usuario);
        }

        public void Remove(string id) {
            _usuarioRepository.Remove(id);
        }
    }
}