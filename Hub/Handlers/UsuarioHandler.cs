using System.Collections.Concurrent;

namespace Hub.Handlers {

    public class UsuarioHandler {
        private ConcurrentDictionary<string, string> _idToUsuario = new ConcurrentDictionary<string, string>();
        private ConcurrentDictionary<string, string> _usuarioToId = new ConcurrentDictionary<string, string>();

        public string GetUsuario(string connectionId) {
            return _idToUsuario[connectionId];
        }

        public string GetId(string usuario) {
            return _usuarioToId[usuario];
        }

        public void Registrar(string connectionId, string usuario) {
            if (_usuarioToId.ContainsKey(usuario)) {
                _idToUsuario.TryRemove(_usuarioToId[usuario], out usuario);
                _idToUsuario.TryAdd(connectionId, usuario);

                _usuarioToId[usuario] = connectionId;
            }
            else {
                _idToUsuario.TryAdd(connectionId, usuario);
                _usuarioToId.TryAdd(usuario, connectionId);
            }
        }

        public void Remover(string connectionId) {
            _usuarioToId.TryRemove(_idToUsuario[connectionId], out _);
            _idToUsuario.TryRemove(connectionId, out _);
        }
    }
}