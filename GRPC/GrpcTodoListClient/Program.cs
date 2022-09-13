using System.Diagnostics;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcTodoList;
using Google.Protobuf.WellKnownTypes;

Stopwatch Watch = new Stopwatch();

Console.WriteLine("GrpcTodoListClient");
Console.WriteLine("--------------------------------\n");

// Etablir le communication avec le serveur de GRPC
Watch.Start(); 
using var channel = GrpcChannel.ForAddress("https://localhost:7260");
TodoList.TodoListClient client = new TodoList.TodoListClient(channel);
Watch.Stop();
Console.WriteLine($"Watch #1 {Watch.ElapsedMilliseconds} ms {Watch.ElapsedTicks} ticks");

int iNbIteration = 1500;

// Boucle d'itérations sur les données
Console.WriteLine($"BOUCLE de création ");
Console.WriteLine($"Début des [{iNbIteration}] Iterations");
for (int i = 1; i <= iNbIteration; i++)
{
    Console.Write($"# {i} ");

    // creer les criteres de la requete
    var CreateRequest = new CreateTodoItemRequest { Titre = $"Item {i}", Description = $"Description Item {i}" };

    Console.WriteLine($"Demande de création {CreateRequest.Titre}");
    // Lancer la demande de service avec les criteres
    Watch.Restart();
    TodoItem CreateReply = await client.CreateTodoItemAsync(CreateRequest);
    Watch.Stop();

    // Afficher les résulats
    Console.Write($"Réponse ID : {CreateReply.Id} ");
    Console.WriteLine($"Titre : {CreateReply.Titre}");
    Console.WriteLine($"Watch CreateTodoItemAsync {Watch.ElapsedMilliseconds} ms {Watch.ElapsedTicks} ticks");
}

Console.WriteLine("--------------------------------");
Console.WriteLine($"READ ");
int IdToRead = 1;

// creer les criteres de la requete
var GetRequest = new GetTodoItemRequest { Id= IdToRead };

Console.WriteLine($"Demande de lecture {GetRequest.Id}");
// Lancer la demande de service avec les criteres
Watch.Restart();
TodoItem TodoItemReply = await client.GetTodoItemAsync(GetRequest);
Watch.Stop();

// Afficher les résulats
Console.Write($"Réponse ID : {TodoItemReply.Id} ");
Console.WriteLine($"Titre : {TodoItemReply.Titre}");
Console.WriteLine($"Description : {TodoItemReply.Description}");
Console.WriteLine($"Watch GetTodoItemAsync {Watch.ElapsedMilliseconds} ms {Watch.ElapsedTicks} ticks");

Console.WriteLine("--------------------------------");
Console.WriteLine($"LIST Recuperer la listes des items");

// creer les criteres de la requete
//$$$var requestGetTodoList = new GetTodoListRequest { SeachText="TODO" };

Console.WriteLine($"Demande de la liste");
// Lancer la demande de service avec les criteres
Watch.Restart();
GetTodoListReply replyGetTodoList = await client.GetTodoListAsync(new Empty()) ;
Watch.Stop();
Console.WriteLine($"Watch GetTodoListAsync {Watch.ElapsedMilliseconds} ms {Watch.ElapsedTicks} ticks");
Console.WriteLine($"Lecture des [{replyGetTodoList.Items.Count}] items");
Console.ReadKey();
for (int i = 0; i < replyGetTodoList.Items.Count; i++)
{
    Console.Write($"# {i} ");
    
    // Afficher les résulats
    Console.Write($"Réponse ID : {replyGetTodoList.Items[i].Id} ");
    Console.WriteLine($"Titre : {replyGetTodoList.Items[i].Titre}");
    Console.WriteLine($"Description : {replyGetTodoList.Items[i].Description}");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();