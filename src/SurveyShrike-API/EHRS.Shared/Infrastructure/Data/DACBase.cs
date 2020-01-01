namespace EHRS.Shared
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.Objects;
    using System.Diagnostics.CodeAnalysis;
    using EHRS.Shared.Factories;
    using System.Data.EntityClient;

    public abstract class DACBase : IDataAccessComponent
    {

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="DACBase"/> class.
        /// </summary>
        /// <param name="dacType">Type of the dac.</param>
        protected DACBase(DACType dacType)
        {
            this.Type = dacType;
        }
        #endregion

        #region IDataAccessComponent Members

        /// <summary>
        /// private gets the type of the DAC.
        /// </summary>
        /// <value>The type of the DAC.</value>
        public DACType Type { get; private set; }

        #endregion

        #region Factory Access

        /// <summary>
        /// Gets the factory of data access component.
        /// </summary>
        /// <value>The data access component.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected DACFactory DataAccessComponent
        {
            get
            {
                return DACFactory.Instance;
            }
        }

        /// <summary>
        /// Gets the factory of data transfer object.
        /// </summary>
        /// <value>The data transfer object.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected DTOFactory DataTransferObject
        {
            get
            {
                return DTOFactory.Instance;
            }
        }


        public DataTable ExecuteCommand(ObjectContext db, string commandText, SqlParameter[] parameters,
                                        CommandType commandType)
        {
            var entityConnection = (EntityConnection)db.Connection;
            var conn = entityConnection.StoreConnection;
            var initialState = conn.State;
            var dt = new DataTable();

            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DACException(ex.Message, ex);
            }
            finally
            {
                if (initialState != ConnectionState.Closed) //fixed here to check for closed instead of open
                    conn.Close();
            }
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            return dt;
        }

        #endregion
    }
}
