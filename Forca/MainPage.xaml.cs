using Forca.LIbraries.Text;
using Forca.Models;
using Forca.Repositories;

namespace Forca
{
    public partial class MainPage : ContentPage
    {
        private Word? word;
        private int errors = 0;

        public MainPage()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            var repository = new WordReposistory();
            word = repository.GetRandomWord();

            lblTips.Text = word.Tips;
            lblText.Text = new String('_', word.Text.Length);
        }

        private void btnReiniciar_Clicked(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private async void OnLetterClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            button.IsEnabled = false;
            string letter = button.Text;
            var positions = word.Text.GetPositions(letter);

            if (positions.Count == 0)
            {
                errors++;

                imgEnforcado.Source = ImageSource.FromFile($"forca{errors + 1}.png");
                button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Fail"] as Style;

                if (errors == 6)
                {
                    await DisplayAlert("Você perdeu!", "Você foi enforcado e esgotou todas as tentativas", "Novo Jogo");
                    ResetScreen();
                }
            }
            else
            {
                foreach (var position in positions)
                {
                    lblText.Text = lblText.Text.Remove(position, 1).Insert(position, letter);
                }

                button.Style = App.Current.Resources.MergedDictionaries.ElementAt(1)["Success"] as Style;

                if (!lblText.Text.Contains('_'))
                {
                    await DisplayAlert("Parabéns!", "Você venceu o jogo", "Novo Jogo");
                    ResetScreen();
                }
            }
        }

        private void ResetScreen()
        {
            errors = 0;
            imgEnforcado.Source = ImageSource.FromFile("forca1.png");

            InitializeData();
            ResetVirtualKeyboard();
        }

        private void ResetVirtualKeyboard()
        {
            foreach (HorizontalStackLayout line in vslKeyboardContainer.Children)
            {
                ResetLineVirtualKeyBoard(line);
            }
        }

        private void ResetLineVirtualKeyBoard(HorizontalStackLayout line)
        {
            foreach (Button key in line.Children)
            {
                key.IsEnabled = true;
                key.Style = null;
            }
        }
    }

}
