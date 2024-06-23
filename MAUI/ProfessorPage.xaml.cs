using MAUI.Models;
using MAUI.Repository;

namespace MAUI
{
    public partial class ProfessorPage : ContentPage
    {
        private readonly IAlunoRepository _alunoRepository;
        private Professor _professor;
        private string _turma;
        private int _alunoid;
        private int _professorId;
        private string _trimestre;
        private int _valor;
        private string _prova;

        public ProfessorPage(Professor professor)
        {
            InitializeComponent();
            _professor = professor;
            _turma = turma.Text;
            _alunoid = Convert.ToInt32(aluno.Text);
            _prova = prova.Text;
            _trimestre =trimestre.Text; // Convert to string
            _valor = Convert.ToInt32(nota.Text);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var nota = new Nota
                {
                    Turma = _turma,
                    AlunoId = _alunoid,
                    Prova = _prova,
                    Trimestre = Convert.ToInt32(_trimestre),
                    Valor = _valor,
                    ProfessorId = _professor.Id,
                    DisciplinaId = _professor.DisciplinaId
                };

                var response = await _alunoRepository.LancarNota(nota);
                if (response != null) 
                {
                    await DisplayAlert("Sucesso!", "Notas lançadas com sucesso.", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}
