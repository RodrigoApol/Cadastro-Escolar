using CadastroEscolar.Models;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace CadastroEscolar;

internal class Program
{
    static void Main(string[] args)
    {
        List<Curso> cursos = new()
        {
        new(1, "Inglês", new List<Aluno>()),
        new Curso(2, "Informática", new List<Aluno>()),
        new Curso(3, "ADM", new List<Aluno>())
        };

        Menu(cursos);
    }

    public static void Menu(List<Curso> cursos)
    {
        Console.Clear();
        Console.WriteLine("Bem Vindo! O que deseja fazer hoje?");
        Console.WriteLine("");
        Console.WriteLine("1 - Adicionar aluno");
        Console.WriteLine("2 - Remover aluno");
        Console.WriteLine("3 - Listar alunos");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("");
        Console.Write("→  ");

        try
        {
            var opcao = short.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                case 2:
                case 3:
                    MenuCursos(opcao, cursos);
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Saindo do programa...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Você não selecionou uma opção válida. Tente Novamente!");
                    Thread.Sleep(2500);
                    Menu(cursos);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Opção inválida. Por favor tente novamente! ERRO: {ex}");
            Thread.Sleep(2500);
            Menu(cursos);
        }
    }

    public static void MenuCursos(short opcao, List<Curso> cursos)
    {
        Console.Clear();
        Console.WriteLine("Escolha o curso:");
        Console.WriteLine("");
        Console.WriteLine("1 - Inglês (ID = 1)");
        Console.WriteLine("2 - Informática (ID = 2)");
        Console.WriteLine("3 - ADM (ID = 3)");
        Console.WriteLine("0 - Retronar ao menu");
        Console.WriteLine("");
        Console.Write("→  ");

        try
        {
            var opCurso = short.Parse(Console.ReadLine()!);

            if (opCurso >= 1 && opCurso <= 3)
            {
                // Subtrai 1 do opCurso para obter o índice correto na lista
                Curso cursoSelecionado = cursos[opCurso - 1];
                GerenciarCursos(cursoSelecionado, opcao, cursos);
            }
            else if (opCurso == 0)
            {
                Menu(cursos);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Você não selecionou uma opção válida. Tente Novamente!");
                Thread.Sleep(2500);
                Menu(cursos);
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Opção inválida. Por favor tente novamente! ERRO: {ex}");
            Thread.Sleep(2500);
            Menu(cursos);
        }
    }

    static void GerenciarCursos(Curso curso, short opcao, List<Curso> cursos)
    {
        if (opcao == 1)
        {
            Console.Clear();
            Console.WriteLine($"Digite o ID do aluno(a) que deseja adicionar no curso de {curso.NomeCurso}:");
            Console.WriteLine("");
            int idAluno = Convert.ToInt32(Console.ReadLine()!);

            Console.Clear();
            Console.WriteLine($"Digite o nome do aluno(a) que deseja adicionar no curso de {curso.NomeCurso}:");
            Console.WriteLine("");
            string nomeAluno = Console.ReadLine()!;

            Console.Clear();
            Console.WriteLine($"Digite a idade do aluno(a) que deseja adicionar no curso de {curso.NomeCurso}:");
            Console.WriteLine("");
            int idadeAluno = Convert.ToInt32(Console.ReadLine()!);

            Aluno aluno = new(id: idAluno, nome: nomeAluno, idade: idadeAluno);

            curso.AddAluno(aluno);

            Console.Clear();
            Console.WriteLine($"Aluno(a): {aluno.Nome} adicionado no curso de {curso.NomeCurso}");
            Thread.Sleep(2500);
            Menu(cursos);
        }
        else if (opcao == 2)
        {
            Console.Clear();
            Console.WriteLine($"Digite o ID do aluno(a) que deseja remover do curso de {curso.NomeCurso}:");
            Console.WriteLine("");
            int idAluno = Convert.ToInt32(Console.ReadLine()!);

            Aluno? aluno = curso.Alunos!.FirstOrDefault(a => a.Id == idAluno);

            if (curso.Alunos!.Contains(aluno!))
            {
                curso.RemoverAluno(aluno!);
                Console.Clear();
                Console.WriteLine($"Aluno(a): {aluno!.Nome} removido do curso de {curso.NomeCurso}");
                Thread.Sleep(2500);
                Menu(cursos);
            }
            else
            {
                Console.WriteLine("Este ID não existe");
                Thread.Sleep(2500);
                Menu(cursos);
            }
        }
        // else if (opcao == 3)
        else
        {
            curso.ListarAlunos();
            Console.ReadKey();
            Menu(cursos);
        }
    }
}