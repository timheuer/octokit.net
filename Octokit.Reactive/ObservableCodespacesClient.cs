﻿using System;
using System.Reactive.Threading.Tasks;

namespace Octokit.Reactive
{
    public class ObservableCodespacesClient : IObservableCodespacesClient
    {
        private ICodespacesClient _client;
        private IConnection _connection;

        public ObservableCodespacesClient(IGitHubClient githubClient)
        {
            _client = githubClient.Codespaces;
            _connection = githubClient.Connection;
        }

        public IObservable<Codespace> Get(string codespaceName)
        {
            Ensure.ArgumentNotNull(codespaceName, nameof(codespaceName));
            return _client.Get(codespaceName).ToObservable();
        }

        public IObservable<CodespacesCollection> GetAll()
        {
            return _client.GetAll().ToObservable();
        }

        public IObservable<CodespacesCollection> GetForRepository(string owner, string repo)
        {
            Ensure.ArgumentNotNull(owner, nameof(owner));
            Ensure.ArgumentNotNull(repo, nameof(repo));
            return _client.GetForRepository(owner, repo).ToObservable();
        }

        public IObservable<Codespace> Start(string codespaceName)
        {
            Ensure.ArgumentNotNull(codespaceName, nameof(codespaceName));
            return _client.Start(codespaceName).ToObservable();
        }

        public IObservable<Codespace> Stop(string codespaceName)
        {
            Ensure.ArgumentNotNull(codespaceName, nameof(codespaceName));
            return _client.Stop(codespaceName).ToObservable();
        }
    }
}