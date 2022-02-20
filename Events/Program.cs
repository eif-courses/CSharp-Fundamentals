// See https://aka.ms/new-console-template for more information


using Events;

var pub = new Publisher();
var player1 = new Suscriber("player1", 500, pub);
var player2 = new Suscriber("player2", 0, pub);



for (int i = 0; i < 10; i++)
{
  pub.DoSomething();
  Thread.Sleep(1000);
}




