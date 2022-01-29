using Delegates;

namespace DelegatesUI
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    
    private void MessageBox_Click(object sender, EventArgs e)
    {
      var defaultDelegates = new DefaultDelegates();

      decimal total = defaultDelegates.GenerateTotal(
        SubTotalAlert,
        CalculateDiscount,
        PrintDiscountAlert
        );
      MessageBox.Show($"total price is: {total:C2}");

    }

 
    private void PrintDiscountAlert(string message)
    {
      MessageBox.Show(message);
    }
    private void SubTotalAlert(decimal subTotal)
    {
      MessageBox.Show($"Subtotal is {subTotal:C2}");
    }
    private decimal CalculateDiscount(List<Products> products, decimal subTotal)
    {
      if (subTotal > 20)
      {
        return subTotal * 0.85M;
      }
      else if (subTotal > 4)
      {
        return subTotal * 0.98M;
      }
      else if (subTotal > 100)
      {
        return subTotal * 0.70M;
      }
      else
      {
        return subTotal;
      }
    }

    private void FillerButtonTextBox_Click(object sender, EventArgs e)
    {
      var defaultDelegates = new DefaultDelegates();

      decimal total = defaultDelegates.GenerateTotal(
        otherTotal => subtotal.Text = $"{otherTotal:C2}",
        (products, subTotal) => subTotal - (products.Count * 2),
        message => { });

      textBox2Total.Text = $"{total:C2}";
    }
  }



}