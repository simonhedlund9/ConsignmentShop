﻿using ConsignmentShopLibrary;
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
            SetupData();
        }

        private void SetupData()
        {
            Vendor demoVendor1 = new Vendor("Bill", "Smith");
            Vendor demoVendor2 = new Vendor("Snoop", "Dog");

            store.Vendors.Add(demoVendor1);
            store.Vendors.Add(demoVendor2);

            Item item1 = new Item("CS GO", "FPS online game", 150, demoVendor1);
            Item item2 = new Item("Minecraft", "Survival game for every age!", 270, demoVendor1);
            Item item3 = new Item("World Of Warcraft", "MMO RPG with a massive following! Over 100 miljon players registered.", 350, demoVendor2);

            store.Items.Add(item1);
            store.Items.Add(item2);
            store.Items.Add(item3);

        }

        private void shoppingCartListboxLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
