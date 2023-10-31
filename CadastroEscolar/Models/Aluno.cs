using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEscolar.Models;

public class Aluno
{
    public Aluno(int id, string nome, int idade)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
    }

    private int _id;
    private string? _nome;
    private int _idade;
    public int Id
    {
        get => _id;
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("valor inválido");
            }
            else
            {
                _id = value;
            }
        }
    }
    public string Nome
    {
        get => _nome!;
        set
        {
            if (value == "")
            {
                Console.WriteLine("valor inválido");
            }
            else
            {
                _nome = value!;
            }
        }
    }
    public int Idade
    {
        get => _idade;
        set
        {
            if (value <= 15)
            {
                Console.WriteLine("valor inválido");
            }
            else
            {
                _idade = value;
            }
        }
    }
}
