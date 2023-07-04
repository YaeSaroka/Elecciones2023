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
            db.Execute(SQL, new {pIdCandidato=can.Id_Candidato, pIPartido= can.FK_Partido, pApellido=can.Apellido, pNombre=can.Nombre, pFechaNacimiento=can.FechaNacimiento, pFoto=can.Foto, pPostulacion=can.Postulacion});
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
        Partido par;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Partido WHERE Id_Partido = @idPartido";
            par = db.QueryFirstOrDefault<Partido>(sql, new{ idPartido = idPartido});
        }
        return par;
    }
    public static Candidato VerInfoCandidato(int idcandidato)
    {   
        Candidato candidate;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM candidato WHERE Id_Candidato = @idcandidato ";
            candidate = db.QueryFirstOrDefault<Candidato>(sql, new { idcandidato = idcandidato});
        }
        return candidate;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> ListadoPartidos;
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
            string sql = "SELECT * FROM Candidato WHERE FK_Partido = @idpartido ";
            ListadoCandidato= db.Query<Candidato>(sql, new { idpartido = idPartido}).ToList();
        }
        return ListadoCandidato;
    }
}