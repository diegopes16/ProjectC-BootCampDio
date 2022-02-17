// See https://aka.ms/new-console-template for more information
using ProjectSeries;
using ProjectSeries.Classes;

MidiaRepositorio repositorioSerie = new MidiaRepositorio();
MidiaRepositorio repositorioFilme = new MidiaRepositorio();


string opcaoUsuario = ObterOpcaoUsuario();
while(opcaoUsuario.ToUpper() != "X")
{
	if (opcaoUsuario == "1")
	{
		string opcaoUsuarioSeries = ObterOpcaoUsuarioSerie();
		while (opcaoUsuarioSeries.ToUpper() != "X")
		{
			switch (opcaoUsuarioSeries)
			{
				case "1":
					ListarMidia(repositorioSerie);
					break;
				case "2":
					InserirMidia(repositorioSerie);
					break;
				case "3":
					AtualizarMidia(repositorioSerie);
					break;
				case "4":
					ExcluirMidia(repositorioSerie);
					break;
				case "5":
					VisualizarMidia(repositorioSerie);
					break;
				case "C":
					Console.Clear();
					break;

				default:
					Console.WriteLine("Opção Inválida. Por favor selecione outra opção");
					break;
			}

			opcaoUsuarioSeries = ObterOpcaoUsuarioSerie();
		}
		opcaoUsuario = ObterOpcaoUsuario();
	}
    else if(opcaoUsuario == "2")
    {
		string opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
		while (opcaoUsuarioFilme.ToUpper() != "X")
        {
			switch (opcaoUsuarioFilme)
			{
				case "1":
					ListarMidia(repositorioFilme);
					break;
				case "2":
					InserirMidia(repositorioFilme);
					break;
				case "3":
					AtualizarMidia(repositorioFilme);
					break;
				case "4":
					ExcluirMidia(repositorioFilme);
					break;
				case "5":
					VisualizarMidia(repositorioFilme);
					break;
				case "C":
					Console.Clear();
					break;

				default:
					Console.WriteLine("Opção Inválida. Por favor selecione outra opção");
					break;
			}

			opcaoUsuarioFilme = ObterOpcaoUsuarioFilme();
		}
		opcaoUsuario = ObterOpcaoUsuario();
	}
    else
    {
		Console.WriteLine("Opção Inválida. Por favor selecione outra opção");
		opcaoUsuario = ObterOpcaoUsuario();
	}
}
Console.WriteLine("Obrigado por utilizar nossos serviços.");



static string ObterOpcaoUsuario()
{
	Console.WriteLine();
	Console.WriteLine("Bem vindo ao seu programa favorito");
	Console.WriteLine("Informe a opção desejada:");

	Console.WriteLine("1- Séries");
	Console.WriteLine("2- Filmes");
	Console.WriteLine("X- Sair");
	Console.WriteLine();

	string opcaoUsuario = Console.ReadLine().ToUpper();
	Console.WriteLine();
	return opcaoUsuario;
}

static string ObterOpcaoUsuarioSerie()
{
	Console.WriteLine();
	Console.WriteLine("Bem vindo a sua escolha de series");
	Console.WriteLine("Informe a opção desejada:");

	Console.WriteLine("1- Listar séries");
	Console.WriteLine("2- Inserir nova série");
	Console.WriteLine("3- Atualizar série");
	Console.WriteLine("4- Excluir série");
	Console.WriteLine("5- Visualizar série");
	Console.WriteLine("C- Limpar Tela");
	Console.WriteLine("X- Sair");
	Console.WriteLine();

	string opcaoUsuarioSerie = Console.ReadLine().ToUpper();
	Console.WriteLine();
	return opcaoUsuarioSerie;
}

static string ObterOpcaoUsuarioFilme()
{
	Console.WriteLine();
	Console.WriteLine("Bem vindo a sua escolha de filmes");
	Console.WriteLine("Informe a opção desejada:");

	Console.WriteLine("1- Listar filmes");
	Console.WriteLine("2- Inserir novo filme");
	Console.WriteLine("3- Atualizar filme");
	Console.WriteLine("4- Excluir filme");
	Console.WriteLine("5- Visualizar filme");
	Console.WriteLine("C- Limpar Tela");
	Console.WriteLine("X- Sair");
	Console.WriteLine();

	string opcaoUsuarioFilme = Console.ReadLine().ToUpper();
	Console.WriteLine();
	return opcaoUsuarioFilme;
}

void ListarMidia(MidiaRepositorio repositorio)
{
	var listaMidia = repositorio.Lista();
	bool listaVazia = (listaMidia.Count == 0);
	if (opcaoUsuario == "1")
    {
		Console.WriteLine("Lista de séries:");

		if (listaVazia)
		{
			Console.WriteLine("Nenhuma série cadastrada.");
			return;
		}
	}
    else
    {
		Console.WriteLine("Lista de filmes:");

		if (listaVazia)
		{
			Console.WriteLine("Nenhum filme cadastrado.");
			return;
		}
	}
	

	foreach (var midia in listaMidia)
	{
		var excluido = midia.RetornaExcluido();

		Console.WriteLine("#ID {0}: - {1} {2}", midia.retornaId(), midia.retornaTitulo(), (excluido ? "*Excluído*" : ""));
	}
}

void ExcluirMidia(MidiaRepositorio repositorio)
{
	if (opcaoUsuario == "1")
    {
		Console.WriteLine("Digite o id da série:");
    }
    else
    {
		Console.WriteLine("Digite o id do filme:");
	}
	bool indiceValido = int.TryParse(Console.ReadLine(), out int indiceMidia);
    if (indiceValido)
    {
		bool idexiste = (indiceMidia < repositorio.Lista().Count());
		if (idexiste)
		{
			repositorio.Exclui(indiceMidia);
		}
		else
		{
			Console.WriteLine("Não existe nenhum registro com esse ID.");
			ListarMidia(repositorio);
		}
    }
    else
    {
		Console.WriteLine("Por favor digite um número");
		ExcluirMidia(repositorio);
    }
	
}

void VisualizarMidia(MidiaRepositorio repositorio)
{
	if (opcaoUsuario == "1")
	{
		Console.WriteLine("Digite o id da série:");
	}
	else
	{
		Console.WriteLine("Digite o id do filme:");
	}
	bool indiceValido = int.TryParse(Console.ReadLine(), out int indiceMidia);
	if (indiceValido)
	{
		var midia = repositorio.RetornaPorId(indiceMidia);
		Console.WriteLine(midia);
    }
    else
    {
		Console.WriteLine("Por favor digite um número");
		VisualizarMidia(repositorio);
	}
}

void AtualizarMidia(MidiaRepositorio repositorio)
{
	if (opcaoUsuario == "1")
	{
		Console.WriteLine("Digite o id da série:");
	}
	else
	{
		Console.WriteLine("Digite o id do filme:");
	}
	bool indiceValido = int.TryParse(Console.ReadLine(), out int indiceMidia);
	if (indiceValido)
	{
		bool idexiste = (indiceMidia < repositorio.Lista().Count());
		if (idexiste)
		{
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o número do gênero entre as opções acima: ");
			bool entradaGeneroValido = int.TryParse(Console.ReadLine(), out int entradaGenero);
			while (!entradaGeneroValido || entradaGenero < 1 ||entradaGenero > 13 ) //valores validos para genero
            {
				Console.WriteLine("Por favor digite um número válido ");
				entradaGeneroValido = int.TryParse(Console.ReadLine(), out entradaGenero);
			}

			Console.WriteLine("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o Ano de Início/Lançamento: ");
			bool entradaAnoValido = int.TryParse(Console.ReadLine(), out int entradaAno);
			while (!entradaAnoValido || entradaAno < 1)  //valores validos para ano
			{
				Console.WriteLine("Por favor digite um ano válido ");
				entradaAnoValido = int.TryParse(Console.ReadLine(), out entradaAno);
			}

			Console.WriteLine("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();

			Midia atualizaMidia = new Midia(id: indiceMidia,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			repositorio.Atualiza(indiceMidia, atualizaMidia);
		}
		else
		{
			Console.WriteLine("Não existe nenhum registro com esse ID.");
			ListarMidia(repositorio);
		}
    }
    else
    {
		Console.WriteLine("Digite um número.");
		AtualizarMidia(repositorio);
	}
}

void InserirMidia(MidiaRepositorio repositorio)
{
	if (opcaoUsuario == "1")
	{
		Console.WriteLine("Inserir nova série:");
	}
	else
	{
		Console.WriteLine("Inserir novo filme:");
	}
	foreach (int i in Enum.GetValues(typeof(Genero)))
	{
		Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
	}
	Console.Write("Digite o gênero entre as opções acima: ");
	bool entradaGeneroValido = int.TryParse(Console.ReadLine(), out int entradaGenero);
	while (!entradaGeneroValido || entradaGenero < 1 || entradaGenero > 13) //valores validos para genero
	{
		Console.WriteLine("Por favor digite um número válido ");
		entradaGeneroValido = int.TryParse(Console.ReadLine(), out entradaGenero);
	}


	Console.Write("Digite o Título : ");
	string entradaTitulo = Console.ReadLine();

	Console.Write("Digite o Ano de Início/Lançamento: ");
	bool entradaAnoValido = int.TryParse(Console.ReadLine(), out int entradaAno);
	while (!entradaAnoValido || entradaAno < 1) //valores validos para ano
	{
		Console.WriteLine("Por favor digite um ano válido ");
		entradaAnoValido = int.TryParse(Console.ReadLine(), out entradaAno);
	}

	Console.Write("Digite a Descrição: ");
	string entradaDescricao = Console.ReadLine();

	Midia novaMidia = new Midia(id: repositorio.ProximoId(),
								genero: (Genero)entradaGenero,
								titulo: entradaTitulo,
								ano: entradaAno,
								descricao: entradaDescricao);
	repositorio.Insere(novaMidia);
}