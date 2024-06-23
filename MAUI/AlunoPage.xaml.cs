using MAUI.Model;
using MAUI.Models;
using MAUI.Repository;



namespace MAUI;

public partial class AlunoPage : ContentPage
{  private readonly IAlunoRepository _alunoRepository;
 
    public AlunoPage(Aluno dados, IEnumerable<Nota> notas)
	{   

        
		InitializeComponent();
        var _aluno = dados;
       int id = _aluno.Id;
  

       
        Label[] disciplinaLabels = {
                Disciplina1, Disciplina2,Disciplina3,Disciplina4,Disciplina5,Disciplina6,Disciplina7,Disciplina8,Disciplina9,Disciplina10,Disciplina11 , Disciplina12
            };
        Label[] notaP1Labels = {
    NotaP1Disciplina1, NotaP1Disciplina2, NotaP1Disciplina3, NotaP1Disciplina4,
    NotaP1Disciplina5, NotaP1Disciplina6, NotaP1Disciplina7, NotaP1Disciplina8,
    NotaP1Disciplina9, NotaP1Disciplina10, NotaP1Disciplina11, NotaP1Disciplina12
        };
        Label[] notaP2Labels = {
    NotaP2Disciplina1, NotaP2Disciplina2, NotaP2Disciplina3, NotaP2Disciplina4,
    NotaP2Disciplina5, NotaP2Disciplina6, NotaP2Disciplina7, NotaP2Disciplina8,
    NotaP2Disciplina9, NotaP2Disciplina10, NotaP2Disciplina11, NotaP2Disciplina12
};
        Label[] notaPTLabels = {
    NotaProvaTrimestralDisciplina1, NotaProvaTrimestralDisciplina2,
    NotaProvaTrimestralDisciplina3, NotaProvaTrimestralDisciplina4,
    NotaProvaTrimestralDisciplina5, NotaProvaTrimestralDisciplina6,
    NotaProvaTrimestralDisciplina7, NotaProvaTrimestralDisciplina8,
    NotaProvaTrimestralDisciplina9, NotaProvaTrimestralDisciplina10,
    NotaProvaTrimestralDisciplina11, NotaProvaTrimestralDisciplina12
};
        Label[] mediaLabels = {
    MediaDisciplina1, MediaDisciplina2, MediaDisciplina3, MediaDisciplina4,
    MediaDisciplina5, MediaDisciplina6, MediaDisciplina7, MediaDisciplina8,
    MediaDisciplina9, MediaDisciplina10, MediaDisciplina11, MediaDisciplina12 };


       for (int i = 0; i < _aluno.Disciplinas.Count(); i++)
        {
            disciplinaLabels[i].Text = _aluno.Disciplinas[i].Nome;
        }

        foreach (var nota in notas)
        {
            var disciplinaId = nota.DisciplinaId;
            var disciplinaIndex = disciplinaId - 1;

            switch (nota.Prova)
            {
                case "P1":
                    notaP1Labels[disciplinaIndex].Text = nota.Valor.ToString(); // Converte o valor da nota para string
                    break;
                case "P2":
                    notaP2Labels[disciplinaIndex].Text = nota.Valor.ToString();
                    break;
                case "PT":
                    notaPTLabels[disciplinaIndex].Text = nota.Valor.ToString();
                    break;
            }
        }

        for (int i = 0; i < disciplinaLabels.Length; i++)
        {
            double media = (Convert.ToDouble(notaP1Labels[i].Text) + Convert.ToDouble(notaP2Labels[i].Text) + Convert.ToDouble(notaPTLabels[i].Text)) / 3;
            mediaLabels[i].Text = media.ToString("F2"); // Exibe a média com 2 casas decimais
        }

    }
}