using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RepoNameCleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_PDFFuse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string defaultText = "Click to write Path to file. Double-click to select.";

                // When all File Path are empty
                if (string.IsNullOrWhiteSpace(Tb_File.Text) || Tb_File.Text.Equals(defaultText))
                {
                    MessageBox.Show("Aucune liste n'est renseignée.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Tb_Directory.Text) || Tb_Directory.Text.Equals(defaultText))
                {
                    MessageBox.Show("Aucun répertoire cible n'est renseigné.");
                    return;
                }

                // Opening list

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Tb_File_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // http://www.ookii.org/software/dialogs/
            try
            {
                OpenFileDialog Tb_File_FileDialog = new OpenFileDialog();

                Tb_File_FileDialog.DefaultExt = ".txt";
                Tb_File_FileDialog.Filter = "Fichier texte|*.txt|Tous les fichiers (*.*)|*.*";
                Tb_File_FileDialog.Title = "Liste d'Expressions à Supprimer";
                if (Tb_File_FileDialog.ShowDialog() == true)
                    ((TextBox)sender).Text = Tb_File_FileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tb_Directory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // http://www.ookii.org/software/dialogs/
            try
            {
                VistaFolderBrowserDialog Tb_Directory_FileDialog = new VistaFolderBrowserDialog();
                Tb_Directory_FileDialog.Description = "Dossier à Nettoyer";
                Tb_Directory_FileDialog.UseDescriptionForTitle = true;

                if (Tb_Directory_FileDialog.ShowDialog() == true)
                    ((TextBox)sender).Text = Tb_Directory_FileDialog.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tb_File_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "Click to write Path to file. Double-click to select.")
                ((TextBox)sender).Text = "";
        }

        private void Tb_File_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                ((TextBox)sender).Text = "Click to write Path to file. Double-click to select.";
        }

        private void Btn_RepoNameCleaner_Click(object sender, RoutedEventArgs e)
        {
            string myListPath = Tb_File.Text;
            string myRepoPath = Tb_Directory.Text;

            // Getting user list of words to be removed
            List<string> readText = File.ReadAllLines(myListPath).ToList();
            // Getting list of file in user's repo
            List<string> filesInRepo = Directory.GetFiles(myRepoPath).ToList();

            MessageBox.Show("Fonction pas encore implémentée.");
            return;
        }
    }
}
