using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace bruno.pmsp.domain.Entities
{
    public class Login : Base
    {

        public static string EncriptarSenha(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        [Required]
        [StringLength(50, MinimumLength=9)]
        public string CredenciaisAcesso { get; set; }
        
        [Required]
        [StringLength(128, MinimumLength=8)]
        public string Senha { get; set; }
        public Servidor Servidor { get; set; }
        public Login() { }
        public Login(string CredenciaisAcesso, string Senha)
        {
            this.CredenciaisAcesso = CredenciaisAcesso;
            this.Senha = EncriptarSenha(Senha);
        }
    }
}