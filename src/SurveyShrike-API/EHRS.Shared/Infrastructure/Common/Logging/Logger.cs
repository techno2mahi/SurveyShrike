using System;
using log4net;

namespace EHRS.Shared
{
    /// <summary>
    /// Represents Logger Implementation,
    /// Author		: EHRS
    /// </summary>
    public sealed class Logger : ILogger
    {
        //The variable is declared to be volatile to ensure that assignment to the 
        //_instance variable completes before the instance variable can be accessed.
        private static volatile Logger _instance;
        private static object _syncObject = new object();

        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly bool _isDebugEnabled;// = _log.IsDebugEnabled;
        private readonly bool _isInfoEnabled;// = _log.IsInfoEnabled;
        private readonly bool _isWarnEnabled;// = _log.IsWarnEnabled;
        private readonly bool _isErrorEnabled;// = _log.IsErrorEnabled;

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        private Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            _isDebugEnabled = _log.IsDebugEnabled;
            _isInfoEnabled = _log.IsInfoEnabled;
            _isWarnEnabled = _log.IsWarnEnabled;
            _isErrorEnabled = _log.IsErrorEnabled;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of class pattern is used.
        /// </summary>
        public static Logger Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_instance == null)
                {
                    //Use a _syncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_syncObject)
                    {
                        //Again check if _instance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }

        #endregion

        #region ILogger Members

        public void LogDebug(object message)
        {
            if (_isDebugEnabled)
                _log.Debug(message);
        }

        public void LogInfo(object message)
        {
            if (_isInfoEnabled)
                _log.Info(message);
        }

        public void LogWarning(object message)
        {
            if (_isWarnEnabled)
                _log.Warn(message);
        }

        public void LogError(object message)
        {
            if (_isErrorEnabled)
                _log.Error(message);
        }

        public void LogError(object message, Exception exception)
        {
            if (_isErrorEnabled)
                _log.Error(message, exception);
        }

        #endregion
    }
}
