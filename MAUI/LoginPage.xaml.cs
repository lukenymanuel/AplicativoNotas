using MAUI.Repository;
using MAUI.Model;
using System;
using MAUI.Models;

namespace MAUI
{
    public partial class LoginPage : ContentPage
    {
        readonly IAlunoRepository alunoRepository = new AlunoServices();
       
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            try
            {
                string username = usuario.Text;
                string password = senha.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    await Shell.Current.DisplayAlert("Erro", "Todos os campos são obrigatórios", "Ok");
                    return;
                }

                Aluno aluno = await alunoRepository.Login(username, password);
                Professor professor = await alunoRepository.LoginProf(username, password);

                if (aluno != null)
                {
              var notas =  await alunoRepository.VerNotas(aluno.Id);
                    await Navigation.PushAsync(new AlunoPage(aluno,notas));
                    await DisplayAlert("Login", "Logado com sucesso", "Ok");
                }else if (professor != null) 
                {   
                    await Navigation.PushAsync(new ProfessorPage(professor));
                    await DisplayAlert("Login", "Logado com sucesso", "Ok");

                }
                else 
                {
                    await DisplayAlert("Erro", "Credenciais incorretas", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
