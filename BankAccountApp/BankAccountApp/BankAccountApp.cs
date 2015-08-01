using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class BankAccountApp : Form
    {
        private BankAccount bankAccount1;
        private string accountNo;
        private string customerName;
        private double amount;
        private double currentBalance;
        public BankAccountApp()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            accountNo = txtAccountNo.Text;
            customerName = txtCustomerName.Text;
            bankAccount1 = new BankAccount(accountNo,customerName);
            MessageBox.Show(@"Account Created");
            txtAccountNo.Text = String.Empty;
            txtCustomerName.Text = String.Empty;
            btnSave.Enabled = false;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (bankAccount1 != null && txtAmount.Text!= String.Empty)
            {
                amount = Convert.ToDouble(txtAmount.Text);
                bankAccount1.Deposit(Convert.ToDouble(amount));
                //currentBalance += amount;
                currentBalance = bankAccount1.Balance;
                MessageBox.Show(amount + " has been deposited;"+" Now Current balance: " + currentBalance);
            }
            else
            {
                MessageBox.Show("Insert amount");
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (bankAccount1 != null && txtAmount.Text != String.Empty && currentBalance>0 )
            {
                amount = Convert.ToDouble(txtAmount.Text);
                if (currentBalance >= amount)
                {
                    bankAccount1.Withdraw(Convert.ToDouble(amount));
                    currentBalance= bankAccount1.Balance;
                    MessageBox.Show(amount + " has been withdrawn;" + " Now Current balance:" + currentBalance);
                }
                else
                {
                    MessageBox.Show("Insufficient balance, you have only "+ currentBalance);
                }
            }
            else
            {
                MessageBox.Show("withdraw failed");
            }
        }
    }
}
