using Services.DAL.Implementations.SqlServer.Mappers;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DAL.Contracts;
using Services.DAL.Tools.Helpers;
using Services.DAL.Contracts.UnitOfWork;
using Services.Domain.Enums;

namespace Services.DAL.Implementations.SqlServer
{
    public sealed class PatenteRepository : Repository, IPatenteRepository<Patente>
    {
        public PatenteRepository(SqlConnection context, SqlTransaction _transaction, IUnitOfWorkRepository unitOfWorkRepository)
            : base(context, _transaction, unitOfWorkRepository)
        {

        }
        public void Add(Patente obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Patente obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Patente GetById(Guid id)
        {
            Patente patente = default;

            string query = $"SELECT * FROM Patentes WHERE IdPatente = @IdPatente";

            using (var reader = base.ExecuteReader(query, CommandType.Text,
              new SqlParameter[] { new SqlParameter("@IdPatente", id) }))
            {
                //Mientras tenga algo en mi tabla de Customers
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    patente = PatenteMapper.Current.Fill(data);
                }
            }

            return patente;
        }
        
        public List<Patente> GetAll()
        {
            List<Patente> patentes = new List<Patente>();

            string query = $"SELECT * FROM Patentes";

            using (var reader = base.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    patentes.Add(PatenteMapper.Current.Fill(data));
                }
            }

            return patentes;
        }

        public void AddMany(IEnumerable<Patente> patentes)
        {
            var list = patentes?.ToList() ?? new List<Patente>();
            if (list.Count == 0) return;

            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Patentes (IdPatente, Estado, Descripcion, DataKey) VALUES");

            var parametros = new List<SqlParameter>(list.Count * 3);
            for (int i = 0; i < list.Count; i++)
            {
                var p = list[i];
                var suf = i.ToString();
                sb.Append(i == 0 ? "(" : ",(");
                sb.Append($"@IdPatente{suf}, @Estado{suf}, @Descripcion{suf}, @DataKey{suf})");

                parametros.Add(new SqlParameter($"@IdPatente{suf}", p.Id));
                parametros.Add(new SqlParameter($"@Estado{suf}", (int)p.Estado));
                parametros.Add(new SqlParameter($"@Descripcion{suf}", p.Descripcion));
                parametros.Add(new SqlParameter($"@DataKey{suf}", (int)p.DataKey));
            }
            sb.Append(";");

            base.ExecuteNonQuery(sb.ToString(), CommandType.Text, parametros.ToArray());
        }

        public void Restore(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
