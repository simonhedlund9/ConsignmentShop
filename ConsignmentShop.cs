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
        public ConsignmentShop()
        {
            InitializeComponent();
        }

        private void SetupData()
        {
            Vendor demoVendor1 = new Vendor("Bill", "Smith");
            Vendor demoVendor2 = new Vendor("Snoop", "Dog");

            store.Vendors.Add(demoVendor1);
            store.Vendors.Add(demoVendor2);

        }

        private void shoppingCartListboxLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
