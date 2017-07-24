﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseNet.Search
{
    public interface IQueryEngine
    {
        IQueryResult<int> ExecuteQuery(SnQuery query, IPermissionFilter filter);
        IQueryResult<string> ExecuteQueryAndProject(SnQuery query, IPermissionFilter permissionFilter);
    }
    public interface IQueryEngineSelector
    {
        IQueryEngine Select(SnQuery query, QuerySettings settings);
    }

    public interface IPermissionFilter
    {
        bool IsPermitted(int nodeId, bool isLastPublic, bool isLastDraft);
    }
    public interface IPermissionFilterFactory
    {
        IPermissionFilter Create(int userId);
    }

    public interface IQueryResult<out T>
    {
        IEnumerable<T> Hits { get; }
        int TotalCount { get; }
    }

    public interface ISnQueryParser
    {
        SnQuery Parse(string queryText, QuerySettings settings);
    }
    public interface IQueryParserFactory
    {
        ISnQueryParser Create();
    }



    public class DefaultPermissionFilter : IPermissionFilter //UNDONE: Delete DefaultPermissionFilter if the final version is done.
    {
        private readonly int _userId;

        public DefaultPermissionFilter(int userId)
        {
            _userId = userId;
        }
        public bool IsPermitted(int nodeId, bool isLastPublic, bool isLastDraft)
        {
            return true; //UNDONE: fake implementation
        }
    }

    public class DefaultPermissionFilterFactory : IPermissionFilterFactory //UNDONE: Delete DefaultPermissionFilterFactory if the final version is done.
    {
        public IPermissionFilter Create(int userId)
        {
            return new DefaultPermissionFilter(userId);
        }
    }

    public class DefaultQueryEngineSelector : IQueryEngineSelector
    {
        public IQueryEngine Select(SnQuery query, QuerySettings settings)
        {
            return new DefaultQueryEngine();
        }
    }

    public class DefaultQueryEngine : IQueryEngine //UNDONE: Delete DefaultQueryEngine if the final version is done.
    {
        public IQueryResult<int> ExecuteQuery(SnQuery query, IPermissionFilter filter)
        {
            throw new NotImplementedException();
        }
        public IQueryResult<string> ExecuteQueryAndProject(SnQuery query, IPermissionFilter permissionFilter)
        {
            var projection = query.Projection;
            throw new NotImplementedException();
        }
    }

    public class DefaultQueryParserFactory : IQueryParserFactory
    {
        public ISnQueryParser Create()
        {
            return new SnQueryParser();
        }
    }
}