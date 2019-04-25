using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int USUARIOID { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string TIPOUSUARIO { get; set; }
    }
}
