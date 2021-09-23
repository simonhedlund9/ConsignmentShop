using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsignmentShop
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();

        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();
        private decimal storeProfit = 0;
        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            itemsListbox.DataSource = itemsBinding;

            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListbox.DataSource = cartBinding;

            shoppingCartListbox.DisplayMember = "Display";
            shoppingCartListbox.ValueMember = "Display";

            vendorsBinding.DataSource = store.Vendors;
            vendorListbox.DataSource = vendorsBinding;

            vendorListbox.DisplayMember = "Display";
            vendorListbox.ValueMember = "Display";
        }

        private void SetupData()
        {
            Vendor demoVendor1 = new Vendor("Bill", "Gates");
            Vendor demoVendor2 = new Vendor("Snoop", "Dog");

            store.Vendors.Add(demoVendor1);
            store.Vendors.Add(demoVendor2);

            Item item1 = new Item("CS GO", "FPS game", 20, demoVendor1);
            Item item2 = new Item("World of warcraft", "MMO RPG, one of the worlds most popular game!", 15, demoVendor1);
            Item item3 = new Item("Minecraft", "Survival game for every age", 12, demoVendor2);
            Item item4 = new Item("Final fantasy", "MMO RPG", 25, demoVendor2);


            store.Items.Add(item1);
            store.Items.Add(item2);
            store.Items.Add(item3);

            store.Name = "Simons Loppis";

        }

        private void shoppingCartListboxLabel_Click(object sender, EventArgs e)
        {

        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            // Lista ut vad som är valt från Items listan
            // Kopiera de till min Shopping Cart
            // Borde vi ta bort items från items listan när de läggs till i Shopping Cart? - Nej
            Item selectedItem = (Item)itemsListbox.SelectedItem;

            // MessageBox.Show(selectedItem.Title);

            shoppingCartData.Add(selectedItem);

            cartBinding.ResetBindings(false);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            // Markera varje item i listan som Sold
            // Rensa listan 

            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (Decimal)item.Owner.Commission * item.Price;
                storeProfit += (1 - (decimal)item.Owner.Commission) * item.Price;
            }

            shoppingCartData.Clear();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            storeProfitValue.Text = string.Format("${0}", storeProfit);

            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorsBinding.ResetBindings(false);
        }
    }
}
