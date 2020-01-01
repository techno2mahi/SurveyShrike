
namespace EHRS.Shared
{
    using System.Web;

    /// <summary>
    /// Represents Cache (Asp.net server cache) manager,
    /// Author		: @techno2mahi
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class CacheManager<T> : StateManagerBase<T> where T : StateEntityBase, new()
    {        
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheManager&lt;T&gt;"/> class.
        /// </summary>
        private CacheManager()
        {
        }
        #endregion

        #region Single Instance

        //The variable is declared to be volatile to ensure that assignment to the 
        //mInstance variable completes before the instance variable can be accessed.
        //[ThreadStatic]
        private static volatile CacheManager<T> _instance;
        private static object _syncObject = new object();

        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of Class pattern is used.
        /// </summary>
        private static CacheManager<T> Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_instance == null)
                {
                    //Use a mSyncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_syncObject)
                    {
                        //Again check if mInstance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_instance == null)
                        {
                            _instance = new CacheManager<T>();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }
        #endregion

        #region StateEntity

        /// <summary>
        /// Gets or sets the state entity.
        /// </summary>
        /// <value>The state entity.</value>
        public override T StateEntity
        {
            get
            {
                T tState = null;
                if (HttpContext.Current.Cache != null)
                {
                    if (HttpContext.Current.Cache[Key] == null)
                    {
                        this.Initialize(false);
                    }
                    tState = (T)HttpContext.Current.Cache[Key];
                }
                return tState;
            }
            set
            {
                if (HttpContext.Current.Cache != null)
                {
                    HttpContext.Current.Cache[Key] = value;
                }
            }
        }
        #endregion

        #region Clear
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            HttpContext.Current.Cache.Remove(Key);
        }
        #endregion

        /// <summary>
        /// Gets the data of cache entity.
        /// </summary>
        /// <value>The data.</value>
        public static T Data
        {
            get { return Instance.StateEntity; }
        }

        /// <summary>
        /// Clears the data of cache entity.
        /// </summary>
        public static void ClearData()
        {
            Instance.Clear();
        }
    }
}
