using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace DirectoryTree.Models.New
{
    public class ProjectsDataAccessLayer
    {
        //string connectionString = @"Data Source=LG-S-SQL02;Initial Catalog='PortalEIPS';User ID=PortalEIPS; Password=7dmu-dj96-kjw3; Integrated Security=false;";
        string connectionString = ConfigurationManager.ConnectionStrings["WorkerConnection"].ConnectionString;

        public IEnumerable<MaterialsParameters> GetMaterialsParameters(int id)
        {
            List<MaterialsParameters> MaterialsParameters = new List<MaterialsParameters>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [MaterialsParameters].[Id] AS [Id] " +
                    ",[MaterialsParameters].[IdMaterial] AS [MaterialId] " +
                    ",[MaterialsParameters].[IdParameter] AS [ParameterId] " +
                    ",[TechnicalParameters].[Name] AS [ParameterName] " +
                    ",[MaterialsParameters].[Value] AS [Value] " +
                    ",[MaterialsParameters].[Unit] AS [Unit] " +
                    "FROM [dbo].[MaterialsParameters] as [MaterialsParameters] " +
                    "LEFT OUTER JOIN [dbo].[TechnicalParameters] as [TechnicalParameters] ON [TechnicalParameters].[Id] = [MaterialsParameters].[IdParameter] " +
                    "Where [MaterialsParameters].[IdMaterial] = '" + id + "' " +
                    "Order by [TechnicalParameters].[Name] ", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MaterialsParameters _materialsParameters = new MaterialsParameters();
                    _materialsParameters.Id = Convert.ToInt32(rdr["Id"]);
                    _materialsParameters.MaterialId = Convert.ToInt32(rdr["MaterialId"]);
                    _materialsParameters.ParameterId = Convert.ToInt32(rdr["ParameterId"]); 
                    _materialsParameters.ParameterName = Convert.ToString(rdr["ParameterName"]);
                    _materialsParameters.Value = Convert.ToString(rdr["Value"]);
                    _materialsParameters.Unit = Convert.ToString(rdr["Unit"]);
                    MaterialsParameters.Add(_materialsParameters);
                }
            }
            return MaterialsParameters;
        }

        /// <summary>
        /// Выборка поставщиков материала
        /// </summary>
        /// <param name="id">Ид материала</param>
        /// <returns>Список поставщиков</returns>
        public IEnumerable<MaterialsMakers> GetSubdivisions(int id)
        {            
            List<MaterialsMakers> MaterialsMakers = new List<MaterialsMakers>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [MaterialsMakers].[Id] As [Id]" +
                    ",[MaterialsMakers].[IdMaterial] As [MaterialId]" +
                    ",[Subdivisions].[Name] as [Subdivision]" +
                    ",[MaterialsMakers].[Price] as [Price]" +
                    ",[MaterialsMakers].[Currency] as [Currency] " +
                    "FROM [dbo].[MaterialsMakers] as [MaterialsMakers] " +
                    "LEFT OUTER JOIN [dbo].[Materials] as [Materials] on [Materials].[id] = [MaterialsMakers].[IdMaterial] " +
                    "LEFT OUTER JOIN [dbo].[Subdivisions] as [Subdivisions] on [Subdivisions].[id] = [MaterialsMakers].[IdMaker] " +
                    "Where [MaterialsMakers].[IdMaterial] = '" + id + "'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MaterialsMakers _materialsMakers = new MaterialsMakers();
                    _materialsMakers.Id = Convert.ToInt32(rdr["Id"]);
                    if (!DBNull.Value.Equals(rdr["MaterialId"]))
                        _materialsMakers.MaterialId = Convert.ToInt32(rdr["MaterialId"]);
                    if (!DBNull.Value.Equals(rdr["Subdivision"]))
                        _materialsMakers.Subdivision = Convert.ToString(rdr["Subdivision"]);
                    if (!DBNull.Value.Equals(rdr["Price"]))
                        _materialsMakers.Price = Convert.ToDouble(rdr["Price"]);
                    if (!DBNull.Value.Equals(rdr["Currency"]))
                        _materialsMakers.Currency = Convert.ToString(rdr["Currency"]);
                    MaterialsMakers.Add(_materialsMakers);
                }
            }
            return MaterialsMakers;
        }

        /// <summary>
        /// Выборка материалов по IdClass
        /// </summary>
        /// <param name="id">Id MaterialsClasses</param>
        /// <returns>Список материалов</returns>
        public IEnumerable<Materials> GetMaterials(int id)
        {
            List<Materials> Materials = new List<Materials>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //SqlCommand cmd = new SqlCommand("SELECT * FROM [PortalEIPS].[dbo].[Materials] Where IdClass='" + id + "'", con);
                SqlCommand cmd = new SqlCommand("SELECT [Materials].[Id] AS [Id]" +
                    ",[Materials].[Number] AS [Number]" +
                    ",[Materials].[IdClass] AS [IdClass]" +
                    ",[MaterialsClasses].[Name] AS [MaterialsClassesName]" +
                    ",[Materials].[Mark]" +
                    ",[Materials].[Name]" +
                    ",[Materials].[NormDoc]" +
                    ",[Materials].[NumberOZM] " +
                    "FROM [dbo].[Materials] as [Materials] " +
                    "LEFT OUTER JOIN [dbo].[MaterialsClasses] AS [MaterialsClasses] ON [MaterialsClasses].Id = [Materials].IdClass " +
                    "Where [Materials].[IdClass] = '" + id + "'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Materials _materials = new Materials();
                    _materials.Id = Convert.ToInt32(rdr["Id"]);
                    _materials.Number = Convert.ToString(rdr["Number"]);
                    _materials.IdClass = Convert.ToInt32(rdr["IdClass"]);
                    _materials.MaterialsClassesName = Convert.ToString(rdr["MaterialsClassesName"]);
                    _materials.Mark = Convert.ToString(rdr["Mark"]);
                    _materials.Name = Convert.ToString(rdr["Name"]);
                    _materials.NormDoc = Convert.ToString(rdr["NormDoc"]);
                    _materials.NumberOZM = Convert.ToString(rdr["NumberOZM"]);
                    Materials.Add(_materials);
                }
            }
            return Materials;
        }        

        /// <summary>
        /// Выборка материалf по Id
        /// </summary>
        /// <param name="id">Id Материала</param>
        /// <returns>Список полей матерала</returns>
        public IEnumerable<Materials> GetMaterial(int id)
        {
            //Materials material = new Materials();
            List<Materials> Material = new List<Materials>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [Materials].[Id]" +
                    ",[Materials].[IdClass]" +
                    ",[MaterialsClasses].[Name] as [MaterialsClassesName]" +
                    ",[Materials].[Stage]" +
                    ",[Stage].[Description] as [StageDescription]" +
                    ",[Materials].[Number]" +
                    ",[Materials].[NumberOZM]" +
                    ",[Materials].[NumberMaker]" +
                    ",[Materials].[Mark]" +
                    ",[Materials].[Name]" +
                    ",[Materials].[Type]" +
                    ",[Materials].[Unit]" +
                    ",[Materials].[Weight]" +
                    ",[Materials].[Currency]" +
                    ",[Materials].[Price]" +
                    ",[Materials].[IdMaker]" +
                    ",[Materials].[RequireAlternativeMaker]" +
                    ",[Materials].[NormDoc]" +
                    ",[Materials].[NormDocMaterial]" +
                    ",[Materials].[Info]" +
                    ",[Materials].[Has2DDraw]" +
                    ",[Materials].[Has3DModel]" +
                    ",[Materials].[Stock]" +
                    ",[Materials].[IdUpdater]" +
                    ",[IdUpdater].[Name] as [IdUpdaterName]" +
                    ",[Materials].[DateOfUpdate]" +
                    ",[Materials].[IdStatus]" +
                    ",[IdStatus].[Value] as [StatusValue]" + 
                    ",[Materials].[IdWorkFlowCurrentNode]" +
                    ",[Materials].[IdDBCreator]" +
                    ",[IdDBCreator].[Name] as [IdDBCreatorName]" +
                    ",[Materials].[DBDateOfCreate]" +
                    ",[Materials].[IdDBUpdater]" +
                    ",[IdDBUpdater].[Name] as [IdDBUpdaterName]" +
                    ",[Materials].[DBDateOfUpdate]" +
                    ",[Materials].[DBUpdaterCompName]" +
                    ",[Materials].[DBStatus]" +
                    ",[Materials].[DeleteReason]" +
                    ",[Materials].[IdReplacedMaterial]" +
                    ",[Materials].[SapLoaded]" +
                    ",[Materials].[UsedOnNLMK]" +
                    ",[Materials].[Price_old]" +
                "FROM [dbo].[Materials] as [Materials] " +
                "LEFT OUTER JOIN [dbo].[MaterialsClasses] as [MaterialsClasses] on [MaterialsClasses].Id = [Materials].IdClass " +
                "LEFT OUTER JOIN [dbo].[Workers] as [IdDBCreator] on [IdDBCreator].Id = [Materials].IdDBCreator " +
                "LEFT OUTER JOIN [dbo].[Workers] as [IdDBUpdater] on [IdDBUpdater].Id = [Materials].IdDBUpdater " +
                "LEFT OUTER JOIN [dbo].[Workers] as [IdUpdater] on [IdUpdater].Id = [Materials].IdUpdater " +
                "LEFT OUTER JOIN [dbo].[Constants] as [Stage] on [Stage].[Id] = [Materials].[Stage] " +
                "LEFT OUTER JOIN [dbo].[Constants] as [IdStatus] on [IdStatus].id = [Materials].IdStatus " +
                "Where [Materials].[Id]='" + id + "'", con);

                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();                
                while (rdr.Read())
                {
                    Materials material = new Materials();
                    material.Id = Convert.ToInt32(rdr["Id"]);
                    material.Name = Convert.ToString(rdr["Name"]);
                    if (!DBNull.Value.Equals(rdr["IdClass"]))
                        material.IdClass = Convert.ToInt32(rdr["IdClass"]);
                    if (!DBNull.Value.Equals(rdr["Stage"]))
                        material.Stage = Convert.ToInt32(rdr["Stage"]);
                    material.StageDescription = Convert.ToString(rdr["StageDescription"]);
                    if (!DBNull.Value.Equals(rdr["Number"]))
                        material.Number = Convert.ToString(rdr["Number"]);
                    if (!DBNull.Value.Equals(rdr["NumberOZM"]))
                        material.NumberOZM = Convert.ToString(rdr["NumberOZM"]);
                    if (!DBNull.Value.Equals(rdr["NumberMaker"]))
                        material.NumberMaker = Convert.ToString(rdr["NumberMaker"]);
                    if (!DBNull.Value.Equals(rdr["Mark"]))
                        material.Mark = Convert.ToString(rdr["Mark"]);
                    if (!DBNull.Value.Equals(rdr["Name"]))
                        material.Name = Convert.ToString(rdr["Name"]);
                    if (!DBNull.Value.Equals(rdr["Type"]))
                        material.Type = Convert.ToString(rdr["Type"]);
                    if (!DBNull.Value.Equals(rdr["Unit"]))
                        material.Unit = Convert.ToString(rdr["Unit"]);
                    if (!DBNull.Value.Equals(rdr["Weight"]))
                        material.Weight = Convert.ToDouble(rdr["Weight"]);
                    if (!DBNull.Value.Equals(rdr["Currency"]))
                        material.Currency = Convert.ToString(rdr["Currency"]);
                    if (!DBNull.Value.Equals(rdr["Price"]))
                        material.Price = Convert.ToDouble(rdr["Price"]);
                    if (!DBNull.Value.Equals(rdr["IdMaker"]))
                        material.IdMaker = Convert.ToInt32(rdr["IdMaker"]);
                    if (!DBNull.Value.Equals(rdr["RequireAlternativeMaker"]))
                        material.RequireAlternativeMaker = Convert.ToBoolean(rdr["RequireAlternativeMaker"]);
                    if (!DBNull.Value.Equals(rdr["NormDoc"]))
                        material.NormDoc = Convert.ToString(rdr["NormDoc"]);
                    if (!DBNull.Value.Equals(rdr["NormDocMaterial"]))
                        material.NormDocMaterial = Convert.ToString(rdr["NormDocMaterial"]);
                    if (!DBNull.Value.Equals(rdr["Info"]))
                        material.Info = Convert.ToString(rdr["Info"]);
                    if (!DBNull.Value.Equals(rdr["Has2DDraw"]))
                        material.Has2DDraw = Convert.ToBoolean(rdr["Has2DDraw"]);
                    if (!DBNull.Value.Equals(rdr["Has3DModel"]))
                        material.Has3DModel = Convert.ToBoolean(rdr["Has3DModel"]);
                    if (!DBNull.Value.Equals(rdr["Stock"]))
                        material.Stock = Convert.ToDouble(rdr["Stock"]);
                    if (!DBNull.Value.Equals(rdr["IdUpdater"]))
                        material.IdUpdater = Convert.ToInt32(rdr["IdUpdater"]);
                    if (!DBNull.Value.Equals(rdr["DateOfUpdate"]))
                        material.DateOfUpdate = Convert.ToDateTime(rdr["DateOfUpdate"]);
                    if (!DBNull.Value.Equals(rdr["IdStatus"]))
                        material.IdStatus = Convert.ToInt32(rdr["IdStatus"]);
                    if (!DBNull.Value.Equals(rdr["StatusValue"]))
                    {
                        string str = Convert.ToString(rdr["StatusValue"]);
                        if (str != "")
                        {
                            material.StatusValue = str.Substring(0, str.IndexOf('|'));
                        }
                    }

                    if (!DBNull.Value.Equals(rdr["IdWorkFlowCurrentNode"]))
                        material.IdWorkFlowCurrentNode = Convert.ToInt32(rdr["IdWorkFlowCurrentNode"]);
                    if (!DBNull.Value.Equals(rdr["IdDBCreator"]))
                        material.IdDBCreator = Convert.ToInt32(rdr["IdDBCreator"]);
                    if (!DBNull.Value.Equals(rdr["DBDateOfCreate"]))
                        material.DBDateOfCreate = Convert.ToDateTime(rdr["DBDateOfCreate"]);
                    if (!DBNull.Value.Equals(rdr["IdDBUpdater"]))
                        material.IdDBUpdater = Convert.ToInt32(rdr["IdDBUpdater"]);
                    if (!DBNull.Value.Equals(rdr["DBDateOfUpdate"]))
                        material.DBDateOfUpdate = Convert.ToDateTime(rdr["DBDateOfUpdate"]);
                    if (!DBNull.Value.Equals(rdr["DBUpdaterCompName"]))
                        material.DBUpdaterCompName = Convert.ToString(rdr["DBUpdaterCompName"]);
                    if (!DBNull.Value.Equals(rdr["DBStatus"]))
                        material.DBStatus = Convert.ToInt32(rdr["DBStatus"]);
                    if (!DBNull.Value.Equals(rdr["DeleteReason"]))
                        material.DeleteReason = Convert.ToString(rdr["DeleteReason"]);
                    if (!DBNull.Value.Equals(rdr["IdReplacedMaterial"]))
                        material.IdReplacedMaterial = Convert.ToInt32(rdr["IdReplacedMaterial"]);
                    if (!DBNull.Value.Equals(rdr["SapLoaded"]))
                        material.SapLoaded = Convert.ToBoolean(rdr["SapLoaded"]);
                    if (!DBNull.Value.Equals(rdr["UsedOnNLMK"]))
                        material.UsedOnNLMK = Convert.ToBoolean(rdr["UsedOnNLMK"]);
                    if (!DBNull.Value.Equals(rdr["Price_old"]))
                        material.Price_old = Convert.ToDouble(rdr["Price_old"]);
                    material.MaterialsClassesName = Convert.ToString(rdr["MaterialsClassesName"]);
                    material.IdUpdaterName = Convert.ToString(rdr["IdUpdaterName"]);
                    material.IdDBCreatorName = Convert.ToString(rdr["IdDBCreatorName"]);
                    material.IdDBUpdaterName = Convert.ToString(rdr["IdDBUpdaterName"]);
                    Material.Add(material);
                }                
            }
            return Material;
        }

        public IEnumerable<Materials> GetMaterialSearch(string filter)
        {
            List<Materials> Material = new List<Materials>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select [Id], [NumberOZM], [Mark], [Name], [NumberMaker], [NormDoc] " +
                    "from [dbo].[Materials] " +
                    "Where [Id] like '%" + filter + "%' " +
                    "Or [NumberOZM] like '%" + filter + "%' " +
                    "Or [Mark] like '%" + filter + "%' " +
                    "Or [Name] like '%" + filter + "%' " +
                    "Or [NumberMaker] like '%" + filter + "%' " +
                    "Or [NormDoc] like '%" + filter + "%'", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Materials material = new Materials();
                    material.Id = Convert.ToInt32(rdr["Id"]);
                    material.Name = Convert.ToString(rdr["Name"]);
                    material.NumberOZM = Convert.ToString(rdr["NumberOZM"]);
                    material.Mark = Convert.ToString(rdr["Mark"]);
                    material.NumberMaker = Convert.ToString(rdr["NumberMaker"]);
                    material.NormDoc = Convert.ToString(rdr["NormDoc"]);
                    Material.Add(material);
                }
            }
            return Material;
        }
    }
}