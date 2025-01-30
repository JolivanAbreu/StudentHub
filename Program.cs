using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;

class Jesuita
{
    private static List<Alunos> listaAlunos = new List<Alunos>();

    static void Main()
    {

        while (true)
        {
            Console.WriteLine("\n Escola Jesuítas");
            Console.WriteLine("\n Menu principal");
            Console.WriteLine("1. Cadastrar aluno");
            Console.WriteLine("2. Listar alunos");
            Console.WriteLine("3. Buscar aluno");
            Console.WriteLine("4. Remover aluno");
            Console.WriteLine("5. Editar alunos");
            Console.WriteLine("6. Relatório de notas");
            Console.WriteLine("7. Sair");

            Console.Write("\n Escolha uma opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1)
            {
                CadastroAlunos();
            }
            else if (opcao == 2)
            {
                ListarAlunos();
            }
            else if (opcao == 3)
            {
                BuscarAluno();
            }
            else if (opcao == 4)
            {
                RemoverAluno();
            }
            else if (opcao == 5)
            {
                EditarAluno();
            } else if (opcao == 6) 
            {
                RelatorioNotas();
            }
            else if (opcao == 7)
            {
                Console.WriteLine("\n Saindo...");
                return;
            }
        }
    }

    private static void CadastroAlunos()
    {
        Alunos alunos = new Alunos();

        Console.WriteLine("Cadastro de Aluno \n ");
        Console.Write("Nome: ");
        alunos.Name = Console.ReadLine();
        Console.Write("Matricula: ");
        alunos.Matricula = int.Parse(Console.ReadLine());
        Console.Write("Nota 1: ");
        alunos.Nota1 = double.Parse(Console.ReadLine());
        Console.Write("Nota 2: ");
        alunos.Nota2 = double.Parse(Console.ReadLine());
        Console.Write("Nota 3: ");
        alunos.Nota3 = double.Parse(Console.ReadLine());

        listaAlunos.Add(alunos);

        Console.WriteLine("\n✅ Cadastro realizado com sucesso!\n");

    }

    private static void ListarAlunos()
    {
        Alunos alunos = new Alunos();
        if (listaAlunos.Count == 0)
        {
            Console.Write("\n❌ Não existe alunos cadastrados no sistema...");
        }
        else
        {
            Console.WriteLine("Lista de Alunos");
            foreach (var aluno in listaAlunos)
            {
                Console.WriteLine($"\n Nome: {aluno.Name} \n Matricula: {aluno.Matricula} \n Nota 1: {aluno.Nota1} \n Nota 2: {aluno.Nota2} \n Nota 3: {aluno.Nota3}");
            }
        }

    }

    private static void RemoverAluno()
    {
        if (listaAlunos.Count == 0)
        {
            Console.WriteLine("\n�� Nenhum aluno cadastrado para remover.");
            return;
        }

        Console.Write("Digite a matricula do aluno: ");
        int matricula;

        while (!int.TryParse(Console.ReadLine(), out matricula)) {
            Console.Write("Número de inválido! Digite uma matrícula válida: ");
        }

        Alunos aluno = listaAlunos.Find(a => a.Matricula == matricula);

        if (aluno == null)
        {
            Console.WriteLine("\n�� Matrícula não encontrada.");
            return;
        }

        listaAlunos.Remove(aluno);
        Console.WriteLine("\n�� Aluno removido com sucesso!");

    }

    private static void BuscarAluno()
    {
        Console.Write("Digite a matricula do aluno: ");
        int matricula;

        while (!int.TryParse(Console.ReadLine(), out matricula)) {
            Console.Write("Número de inválido! Digite uma matrícula válida: ");
        }

        Alunos aluno = listaAlunos.Find(a => a.Matricula == matricula);

        if (aluno == null)
        {
            Console.WriteLine("\n�� Matrícula não encontrada.");
            return;
        }

        Console.WriteLine($"\nNome: {aluno.Name} \nMatricula: {aluno.Matricula} \nNota 1: {aluno.Nota1} \nNota 2: {aluno.Nota2} \nNota 3: {aluno.Nota3}");
    }

    private static void EditarAluno()
    {
            if (listaAlunos.Count == 0)
        {
            Console.WriteLine("\n❌ Nenhum aluno cadastrado para editar.");
            return;
        }

        Console.Write("\nDigite a matrícula do aluno que deseja editar: ");
        int matricula;
        
        while (!int.TryParse(Console.ReadLine(), out matricula))
        {
            Console.Write("Número inválido! Digite uma matrícula válida: ");
        }

        // Busca o aluno pela matrícula
        Alunos aluno = listaAlunos.Find(a => a.Matricula == matricula);

        if (aluno == null)
        {
            Console.WriteLine("\n❌ Matrícula não encontrada.");
            return;
        }

        Console.WriteLine($"\nAluno encontrado: {aluno.Name}");
        Console.WriteLine("\nO que deseja alterar?");
        Console.WriteLine("1 - Nome");
        Console.WriteLine("2 - Nota 1");
        Console.WriteLine("3 - Nota 2");
        Console.WriteLine("4 - Nota 3");
        Console.WriteLine("5 - Sair");
        Console.Write("Escolha uma opção: ");

        int edit;
        while (!int.TryParse(Console.ReadLine(), out edit) || edit < 1 || edit > 5)
        {
            Console.Write("Opção inválida! Escolha entre 1 e 5: ");
        }

        switch (edit)
        {
            case 1:
                Console.Write("Digite o novo nome: ");
                string novoNome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoNome)) aluno.Name = novoNome;
                break;
            case 2:
                Console.Write("Digite a nova Nota 1: ");
                if (double.TryParse(Console.ReadLine(), out double novaNota1) && novaNota1 >= 0 && novaNota1 <= 10)
                    aluno.Nota1 = novaNota1;
                else
                    Console.WriteLine("Nota inválida! Deve estar entre 0 e 10.");
                break;
            case 3:
                Console.Write("Digite a nova Nota 2: ");
                if (double.TryParse(Console.ReadLine(), out double novaNota2) && novaNota2 >= 0 && novaNota2 <= 10)
                    aluno.Nota2 = novaNota2;
                else
                    Console.WriteLine("Nota inválida! Deve estar entre 0 e 10.");
                break;
            case 4:
                Console.Write("Digite a nova Nota 3: ");
                if (double.TryParse(Console.ReadLine(), out double novaNota3) && novaNota3 >= 0 && novaNota3 <= 10)
                    aluno.Nota3 = novaNota3;
                else
                    Console.WriteLine("Nota inválida! Deve estar entre 0 e 10.");
                break;
            case 5:
                Console.WriteLine("\nSaindo...");
                return;
        }

        Console.WriteLine("\n✅ Dados atualizados com sucesso!\n");

    }   

    private static void RelatorioNotas()
    {
        double media = 0;
        double somaNotas = 0;

        Console.Write("\n=============== Emissão de Relatório ===================");
        Console.WriteLine("======================================================");
        Console.WriteLine("Matricula | Nome | Nota 1 | Nota 2 | Nota 3 | Media");
        Console.WriteLine("======================================================");

    }

}