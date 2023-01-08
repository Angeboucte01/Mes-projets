using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemeCaisse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnReinitialiser_Click(object sender, EventArgs e) // le nom spécifique de la méthode Réinitialiser doit s’ecrire avec un R au lieu de r
        {

            rtfReceipt.Clear();
            txtLatte.Text = "000";
            txtEspresso.Text = "000";
            txtMocha.Text = "000";    // la valeur precedente de Mocha n'etait pas initialiser à 000
            txtValeCoffee.Text = "000";
            txtCappu.Text = "000";
            txtAfricanCoffee.Text = "000";
            txtMilkTea.Text = "000";
            txtChineseTea.Text = "000";
            txtCoffeCake.Text = "000";
            txtRedValvetCake.Text = "000";
            txtBlackForestCake.Text = "000";
            txtBostonCream.Text = "000";
            txtLagosChoco.Text = "000";
            txtKillburnChoco.Text = "000";
            txtCheeseCake.Text = "000";
            txtRainbowCake.Text = "000";
            lblCakeCost.Text = "000";
            lblDrinkCost.Text = "000";
            lblTax.Text = "000";
            lblSubTotal.Text = "000";
            lblTotal.Text = "000";
        }

        /// <summary>
        /// gestionnaire d’événement Click du bouton Total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTotal_Click(object sender, EventArgs e)
        {
            double lat, mocha, espr, vale, cappu, afri, mTea, cTea;
            double cCake, rValvet, bFor, bCream, lChoco, kChoco, cheese, rain;
            double tax = 0.25;
            double charge = 2;

            //initialiser les prix
            lat = 1.20; mocha = 1.29; espr = 1.29; vale = 1.45; cappu = 1.70; afri = 1.50; mTea = 1.45; cTea = 1.10; //prix des cafés
            cCake = 1.30; rValvet = 1.20; bFor = 1.30; bCream = 1.90; lChoco = 1.50; kChoco = 1.40; cheese = 1.30; rain = 1.10; //prix des gateaux


            //Café
            double latteeCof = Convert.ToDouble(txtLatte.Text);
            double mochaCof = Convert.ToDouble(txtMocha.Text);
            double espressoCof = Convert.ToDouble(txtEspresso.Text);
            double valeCoffee = Convert.ToDouble(txtValeCoffee.Text);
            double cappCof = Convert.ToDouble(txtCappu.Text);
            double afriCof = Convert.ToDouble(txtAfricanCoffee.Text);
            double miTea = Convert.ToDouble(txtMilkTea.Text);
            double cineseTea = Convert.ToDouble(txtChineseTea.Text);
            //Gateau
            double cofCake = Convert.ToDouble(txtCoffeCake.Text);
            double redValvet = Convert.ToDouble(txtRedValvetCake.Text);
            double bForest = Convert.ToDouble(txtBlackForestCake.Text);
            double bostonCream = Convert.ToDouble(txtBostonCream.Text);
            double lqgoschoco = Convert.ToDouble(txtLagosChoco.Text);
            double kilbChoco = Convert.ToDouble(txtKillburnChoco.Text);            
            double cheeseCak = Convert.ToDouble(txtCheeseCake.Text);
            double rainbow = Convert.ToDouble(txtRainbowCake.Text);

            //Calculer le coût des boissons  
            double drinkCosts = (latteeCof * lat) + (espressoCof * espr) + (valeCoffee * vale) + (cappCof * cappu) + (afriCof * afri) + (miTea * mTea) + (cineseTea * cTea)+(mochaCof*mocha); // Ajout du mocha au total
            lblDrinkCost.Text = Convert.ToString(drinkCosts);
            //Calculer le coût des gateaux
            double cakeCosts = (cofCake * cCake) + (redValvet * rValvet) + (bForest * bFor) + (bostonCream * bCream) + (lqgoschoco * lChoco) + (kilbChoco * kChoco) + (cheeseCak * cheese) + (rainbow * rain);
            lblCakeCost.Text = Convert.ToString(cakeCosts);

                        
            double subTotal = cakeCosts + drinkCosts + charge;
            double lesTaxes = subTotal * tax ;

            
            //Afficher les résultats
            lblDrinkCost.Text = String.Format("{0:C}", drinkCosts);
            lblCakeCost.Text = String.Format("{0:C}", cakeCosts);
            lblSvcCharge.Text = String.Format("{0:C}", charge); // Ajout du :C manquant permettant d'afficher le signe $
            lblSubTotal.Text = String.Format("{0:C}", subTotal);
            lblTax.Text = String.Format("{0:C}", lesTaxes);
            lblTotal.Text = String.Format("{0:C}", (subTotal + lesTaxes));
        }


        /// <summary>
        /// Méthode pour générer le reçu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecu_Click(object sender, EventArgs e) 
        {
            //btnReceipt
            rtfReceipt.Clear();
            //Retrait des commentaire pour l'affichage du reçu
            
            rtfReceipt.AppendText("-------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("\t\t" + "Café Lacité" + Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Latte : " + txtLatte.Text + Environment.NewLine);
            rtfReceipt.AppendText("Espresso : " + txtEspresso.Text + Environment.NewLine);
            rtfReceipt.AppendText("Mocha : " + txtMocha.Text + Environment.NewLine);
            rtfReceipt.AppendText("ValeCoffe : " + txtValeCoffee.Text + Environment.NewLine);
            rtfReceipt.AppendText("Capuucino : " + txtCappu.Text + Environment.NewLine);
            rtfReceipt.AppendText("Café glacé : " + txtAfricanCoffee.Text + Environment.NewLine);
            rtfReceipt.AppendText("Thé au lait : " + txtMilkTea.Text + Environment.NewLine);
            rtfReceipt.AppendText("Thé : " + txtChineseTea.Text + Environment.NewLine);
            rtfReceipt.AppendText("Gâteau au café : " + txtCoffeCake.Text + Environment.NewLine);
            rtfReceipt.AppendText("Gâteau rouge velours : " + txtRedValvetCake.Text + Environment.NewLine);
            rtfReceipt.AppendText("Forêt-noire : " + txtBlackForestCake.Text + Environment.NewLine);
            rtfReceipt.AppendText("Tarte crème de Boston : " + txtBostonCream.Text + Environment.NewLine);
            rtfReceipt.AppendText("Gâteau chocolat Lagos : " + txtLagosChoco.Text + Environment.NewLine);
            rtfReceipt.AppendText("Gâteau chocolat Kilburn : " + txtKillburnChoco.Text + Environment.NewLine);
            rtfReceipt.AppendText("Gâteau au fromage : " + txtCheeseCake.Text + Environment.NewLine);
            rtfReceipt.AppendText("Gâteau arc-en-ciel : " + txtRainbowCake.Text + Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Frais de service : " + lblSvcCharge.Text + Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Taxe : " + lblTax.Text + Environment.NewLine);
            rtfReceipt.AppendText("Sous-Total : " + lblSubTotal.Text + Environment.NewLine);
            rtfReceipt.AppendText("Total : " + lblTotal.Text + Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------------------" + Environment.NewLine);

        }


        /// <summary>
        /// Méthode de chargement de formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        { 

            txtLatte.Text = "000";
            txtEspresso.Text = "000";
            txtMocha.Text = "000";
            txtValeCoffee.Text = "000";
            txtCappu.Text = "000";
            txtAfricanCoffee.Text = "000";
            txtMilkTea.Text = "000";
            txtChineseTea.Text = "000";
            txtCoffeCake.Text = "000";
            txtRedValvetCake.Text = "000";
            txtBlackForestCake.Text = "000";
            txtBostonCream.Text = "000";
            txtLagosChoco.Text = "000";
            txtKillburnChoco.Text = "000";
            txtCheeseCake.Text = "000";
            txtRainbowCake.Text = "000";
            lblCakeCost.Text = "000";
            lblDrinkCost.Text = "000";
            lblTax.Text = "000";
            lblSubTotal.Text = "000";
            lblTotal.Text = "000";
            lblSvcCharge.Text = "1,75";

            rtfReceipt.Clear();

        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLatte_Click(object sender, EventArgs e)
        {
            txtLatte.Text = "";
            txtLatte.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEspresso_Click(object sender, EventArgs e)
        {
            txtEspresso.Text = "";
            txtEspresso.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMocha_Click(object sender, EventArgs e)
        {
            txtMocha.Text = "";
            txtMocha.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValeCoffee_Click(object sender, EventArgs e)
        {
            txtValeCoffee.Text = "";
            txtValeCoffee.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCappu_Click(object sender, EventArgs e)
        {
            txtCappu.Text = "";
            txtCappu.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAfricanCoffee_Click(object sender, EventArgs e)
        {
            txtAfricanCoffee.Text = "";
            txtAfricanCoffee.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMilkTea_Click(object sender, EventArgs e)
        {
            txtMilkTea.Text = "";
            txtMilkTea.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChineseTea_Click(object sender, EventArgs e)
        {
            txtChineseTea.Text = "";
            txtChineseTea.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCoffeCake_Click(object sender, EventArgs e)
        {
            txtCoffeCake.Text = "";
            txtCoffeCake.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRedValvetCake_Click(object sender, EventArgs e)
        {
            txtRedValvetCake.Text = "";
            txtRedValvetCake.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBlackForestCake_Click(object sender, EventArgs e)
        {
            txtBlackForestCake.Text = "";
            txtBlackForestCake.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBostonCream_Click(object sender, EventArgs e)
        {
            txtBostonCream.Text = "";
            txtBostonCream.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLagosChoco_Click(object sender, EventArgs e)
        {
            txtLagosChoco.Text = "";
            txtLagosChoco.Focus();
        }



        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKillburnChoco_Click(object sender, EventArgs e)
        {
            txtKillburnChoco.Text = "";
            txtKillburnChoco.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCheeseCake_Click(object sender, EventArgs e)
        {
            txtCheeseCake.Text = "";
            txtCheeseCake.Focus();
        }


        /// <summary>
        /// gestionnaire d’événement Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRainbowCake_Click(object sender, EventArgs e)
        {
            txtRainbowCake.Text = "";
            txtRainbowCake.Focus();
        }

        

        //Méthode pour imprimer le reçu
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtfReceipt.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        /// <summary>
        /// gestionnaire d’événement click du bouton imprimer du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        /// <summary>
        /// gestionnaire d’événement click du bouton nouveau du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Clear();
        }

        /// <summary>
        /// gestionnaire d’événement click du bouton couper du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Cut();
        }

        /// <summary>
        /// gestionnaire d’événement click du bouton copier du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Copy();
        }

        /// <summary>
        /// gestionnaire d’événement click du bouton Coller du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Paste();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //Ouvrir le fichier
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtfReceipt.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        /// <summary>
        /// gestionnaire d’événement click du bouton sauvegarde du menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //sauvegarder le texte
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";


            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile.FileName))
                    sw.WriteLine(rtfReceipt.Text);
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRainbowCake_Leave(object sender, EventArgs e)
        {
            if (txtRainbowCake.Text.Length == 0)
            {
                txtRainbowCake.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCheeseCake_Leave(object sender, EventArgs e)
        {
            if (txtCheeseCake.Text.Length == 0)
            {
                txtCheeseCake.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKillburnChoco_Leave(object sender, EventArgs e)
        {
            if (txtKillburnChoco.Text.Length == 0)
            {
                txtKillburnChoco.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLagosChoco_Leave(object sender, EventArgs e)
        {
            if (txtLagosChoco.Text.Length == 0)
            {
                txtLagosChoco.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBostonCream_Leave(object sender, EventArgs e)
        {
            if (txtBostonCream.Text.Length == 0)
            {
                txtBostonCream.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBlackForestCake_Leave(object sender, EventArgs e)
        {
            if (txtBlackForestCake.Text.Length == 0)
            {
                txtBlackForestCake.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRedValvetCake_Leave(object sender, EventArgs e)
        {
            if (txtRedValvetCake.Text.Length == 0)
            {
                txtRedValvetCake.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCoffeCake_Leave(object sender, EventArgs e)
        {
            if (txtCoffeCake.Text.Length == 0)
            {
                txtCoffeCake.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLatte_Leave(object sender, EventArgs e)
        {
            if (txtLatte.Text.Length == 0)
            {
                txtLatte.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEspresso_Leave(object sender, EventArgs e)
        {
            if (txtEspresso.Text.Length == 0)
            {
                txtEspresso.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMocha_Leave(object sender, EventArgs e)
        {
            if (txtMocha.Text.Length == 0)
            {
                txtMocha.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValeCoffee_Leave(object sender, EventArgs e)
        {
            if (txtValeCoffee.Text.Length == 0)
            {
                txtValeCoffee.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCappu_Leave(object sender, EventArgs e)
        {
            if (txtCappu.Text.Length == 0)
            {
                txtCappu.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAfricanCoffee_Leave(object sender, EventArgs e)
        {
            if (txtAfricanCoffee.Text.Length == 0) // Nous avons changer l'operateur != en ==
            {
                txtAfricanCoffee.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMilkTea_Leave(object sender, EventArgs e)
        {
            if (txtMilkTea.Text.Length == 0)
            {
                txtMilkTea.Text = "000";
            }
        }

        /// <summary>
        /// gestionnaire d’événement quand le curseur quitte le contrôle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChineseTea_Leave(object sender, EventArgs e)
        {
            if (txtChineseTea.Text.Length == 0)
            {
                txtChineseTea.Text = "000";
            }
        }
        /// <summary>
        /// Methode pour sortir de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortir_Click(object sender, EventArgs e) 
        {
            Application.Exit();
        }

        
    }
}
