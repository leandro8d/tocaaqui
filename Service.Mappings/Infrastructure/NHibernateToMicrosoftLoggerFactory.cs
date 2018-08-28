﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Infrastructure
{
    public class NHibernateToMicrosoftLoggerFactory : INHibernateLoggerFactory
    {
        private readonly Microsoft.Extensions.Logging.ILoggerFactory _loggerFactory;

        public NHibernateToMicrosoftLoggerFactory(Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public INHibernateLogger LoggerFor(string keyName)
        {
            var msLogger = _loggerFactory.CreateLogger(keyName);
            return new NHibernateToMicrosoftLogger(msLogger);
        }

        public INHibernateLogger LoggerFor(System.Type type)
        {
            return LoggerFor(
                Microsoft.Extensions.Logging.Abstractions.Internal.TypeNameHelper.GetTypeDisplayName(type));
        }
    }
}
