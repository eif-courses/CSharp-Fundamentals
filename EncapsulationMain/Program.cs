namespace EncapsulationMain {
    class Program 
    { 
      static void Main(string[] args)
      {
        Encapsulation.Customer customer = new Encapsulation.Customer();
        customer.Name = "Marius";
        customer.Code = "s007";

        // Is complicated for user which try to implement something using Encapsulation component
        // Why I need to use and when Validate, CreateDBObjects and other methods???
        customer.Validate();
        customer.CreateDBObjects();
        customer.Add();

      Encapsulation.CustomerWithEncapsulation customerEncapsulated = new Encapsulation.CustomerWithEncapsulation();
      
      // You exposing data which is important and easier to managing permissions / data hiding process
      // You don't need to see or call all methods which is implemented inside CustomerWithEncapsulation class.
      customerEncapsulated.Name = "Tom";
      customerEncapsulated.Code = "s021315";
      customerEncapsulated.Add();
      


    }
  }
}

