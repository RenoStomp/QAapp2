using QAapp.CMD.Menu;
using QAapp.Data.Model.Entities;
using QAapp.Data.Repositories.Implementations;
using QAapp.Data.SqlServer;

Console.WriteLine("Loading...");


var ctx = new AppDbContext();
var orderController = new DbRepository<Order>(ctx);
var clientController = new DbRepository<Client>(ctx);

var mainMenu = new MainMenu(orderController, clientController);
mainMenu.Execute();