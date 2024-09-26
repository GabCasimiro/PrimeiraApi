namespace Colaboradores.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public string? Menssagem { get; set; } = string.Empty;
        


    }
}
