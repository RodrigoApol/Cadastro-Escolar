using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEscolar.Models;

public class Curso
{
    public Curso(int idCurso, string nomeCurso, List<Aluno> alunos)
    {
        Id = idCurso;
        NomeCurso = nomeCurso;
        Alunos = alunos ?? new List<Aluno>();
    }
    public int Id { get; set; }
    public string NomeCurso { get; set; } = "";
    public List<Aluno>? Alunos { get; set; }

    public void AddAluno(Aluno aluno) => Alunos!.Add(aluno);

    public void RemoverAluno(Aluno aluno) => Alunos!.Remove(aluno);

    public void ListarAlunos()
    {
        if (Alunos!.Count == 0)
        {
            Console.WriteLine($"O curso de {NomeCurso} não possuí alunos cadastrados");
        }
        else
        {
            Console.WriteLine($"Os alunos cadastrados no curso de {NomeCurso}, são:");
            foreach (var aluno in Alunos!)
            {
                Console.WriteLine($"ID: {aluno.Id}, Nome: {aluno.Nome}, Idade: {aluno.Idade}");
            }
        }
    }
}
