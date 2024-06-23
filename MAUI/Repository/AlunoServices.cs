using MAUI.Model;
using MAUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MAUI.Repository;

public class AlunoServices : IAlunoRepository
{
    public async Task<Aluno> Login(string username, string password)
    {
        var client = new HttpClient();
        string url = "https://localhost:7029/api/Alunos/" + username + "/" + password;
        client.BaseAddress = new Uri(url);
        HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var aluno = JsonConvert.DeserializeObject<Aluno>(content);
            return await Task.FromResult(aluno);
        }
        return null;
    }

    public async Task<IEnumerable<Nota>> VerNotas(int alunoId)
    {
        var client = new HttpClient();
        string url = "https://localhost:7029/api/Notas/Notasdoaluno/" + alunoId;
        client.BaseAddress = new Uri(url);
        HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var notas = JsonConvert.DeserializeObject<IEnumerable<Nota>>(content);
            return notas;
        }
        return null;
    }


    public async Task<Professor> LoginProf(string username, string password) 
    {
        var client = new HttpClient();
        string url = "https://localhost:7029/api/Professores/" + username + "/" + password;
        client.BaseAddress = new Uri(url);
        HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var professor = JsonConvert.DeserializeObject<Professor>(content);
            return await Task.FromResult(professor);
        }
        return null;

     }
    public async Task<Professor> LancarNota(Nota nota)
    {

            var client = new HttpClient();
            string url = "https://localhost:7029/api/Notas"; // Verifique se esta é a URL correta
            client.BaseAddress = new Uri(url);

            // Serializa a nota em formato JSON
            var jsonNota = JsonConvert.SerializeObject(nota);
            var content = new StringContent(jsonNota, Encoding.UTF8, "application/json");

            // Envia a nota para a API
            var response = await client.PostAsync(client.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {
                // Decodifique o conteúdo da resposta para o tipo Professor
                var professorJson = await response.Content.ReadAsStringAsync();
                var professor = JsonConvert.DeserializeObject<Professor>(professorJson);
                return professor;
            }
            else
            {
                // Trate o erro de acordo com a lógica do seu aplicativo
                // Por exemplo, lançar uma exceção ou retornar um valor padrão
                // caso a requisição não seja bem-sucedida.
                // Aqui, estou retornando null como exemplo:
                return null;
            }


    }

}

