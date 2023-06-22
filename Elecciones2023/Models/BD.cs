using System.Data.SqlClient;
using Dapper;
namespace Elecciones2023.Models;
public static class BD
{
    private static string ConnectionString { get; set; } = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
    
    public static void AgregarCandidato(Candidato can)
    {   
        string SQL= "INSERT INTO Candidato(IdCandidato, IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pIdCandidato, @pIdPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute(SQL, new {pIdCandidato=can.IdCandidato, pIPartido= can.IdPartido, pApellido=can.Apellido, pNombre=can.Nombre, pFechaNacimiento=can.FechaNacimiento, pFoto=can.Foto, pPostulacion=can.Postulacion});
        } 
    }
    public static int EliminarCandidato(int idCandidato)
    {
        int RegistrosEliminados=0;
        string sql= "DELETE FROM Candidato WHERE IdCandidato=@idCandidato";
        using(SqlConnection db= new SqlConnection(ConnectionString))
        {
            RegistrosEliminados= db.Execute(sql, new{IdCandidato=idCandidato});
        }
        return RegistrosEliminados;
    }
    public static Partido VerInfoPartido(int idPartido)
    {   
        Partido partidito = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuarios WHERE IdPartido = @pidPartido";
            partidito = db.QueryFirstOrDefault<Partido>(sql, new { pidPartido = partidito.IdPartido});
        }
        return partidito;
    }
    public static Candidato VerInfoCandidato(int idcandidato)
    {   
        Candidato candidate = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM candidato WHERE IdCandidato = @pidcandidato";
            candidate = db.QueryFirstOrDefault<Candidato>(sql, new { pidcandidato = candidate.IdCandidato});
        }
        return candidate;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> ListadoPartidos= null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM partido";
            ListadoPartidos=db.Query<Partido>(sql).ToList();
        }
        return ListadoPartidos;
    }
    public static List<Candidato> ListarCandidatos(int idPartido)
    {
        List<Candidato> ListadoCandidato= new List<Candidato>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM candidato WHERE IdCandidato=@pidPartido";
           ListadoCandidato= db.Query<Candidato>(sql).ToList();
        }
        return ListadoCandidato;
    }
}