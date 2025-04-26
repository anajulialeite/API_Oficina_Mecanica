namespace MinhaApi.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Mensagem { get; set; }
        public T Dados { get; set; }

        public ApiResponse(bool success, string mensagem, T dados = default)
        {
            Success = success;
            Mensagem = mensagem;
            Dados = dados;
        }
    }
}
