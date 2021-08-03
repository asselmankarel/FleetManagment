﻿using Fleetmanagement.Admin.WPF.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Fleetmanagement.Admin.WPF.ViewModels
{
    public class RequestViewModel : ObservableValidator
    {
        private readonly Services.RequestService _requestService;

        private RequestModel _selectedRequest;
        public RequestModel SelectedRequest
        {
            get => _selectedRequest;
            set => SetProperty(ref _selectedRequest, value, true);
        }

        public ObservableCollection<RequestModel> Requests { get; set; } = new ObservableCollection<RequestModel>();

        public RequestViewModel()
        {
            _requestService = new Services.RequestService();
            LoadRequests();
        }

        private async void LoadRequests()
        {
            Requests.Clear();
            var requests = await _requestService.GetRequestsFromGrpcApi();
            requests.ForEach(r => Requests.Add(r));
        } 
    }
}